using S360BusinessLogic;
using S360Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S360.ViewModel.Student
{
    public class StudentTCViewModel : ViewModelBase
    {
        #region [ Private Variables ]

        /// <summary>
        /// Variable to store Section Lookup values
        /// </summary>
        private ObservableCollection<GEN_Sections_Lookup> _sections = null;

        /// <summary>
        /// Variable to hold selected value from Section Lookup
        /// </summary>
        private GEN_Sections_Lookup _selectedSection = null;

        /// <summary>
        /// Variable to store current student details
        /// </summary>
        private S360Model.ChangeDivisionModel _currentStudent = null;

        /// <summary>
        /// Command to find student
        /// </summary>
        private System.Windows.Input.ICommand _findStudentCommand = null;

        /// <summary>
        /// Command to find student with GR number
        /// </summary>
        private System.Windows.Input.ICommand _findStudentWithGRCommand = null;

        /// <summary>
        /// Command to cancel the page
        /// </summary>
        private System.Windows.Input.ICommand _cancelCommand = null;

        /// <summary>
        /// Command to clear all controls09
        /// </summary>
        private System.Windows.Input.ICommand _clearAllCommand = null;

        /// <summary>
        /// Command to remove student from DB
        /// </summary>
        private System.Windows.Input.ICommand _removeStudentCommand = null;

        /// <summary>
        /// Variable to store result of change division
        /// </summary>
        private string _result = null;

        #endregion

        #region [ Constructor ]

        #endregion

        #region [ Public Properties ]

        /// <summary>
        /// Gets Sections for Lookup
        /// </summary>
        public ObservableCollection<GEN_Sections_Lookup> Sections
        {
            get
            {
                if (_sections == null)
                    _sections = new ObservableCollection<GEN_Sections_Lookup>(((SectionRepository)S360RepositoryFactory.GetRepository("SECTION")).GetAll());
                return _sections;
            }
        }

        /// <summary>
        /// Gets or sets selected value of section lookup
        /// </summary>
        public GEN_Sections_Lookup SelectedSection
        {
            get
            {
                if (_selectedSection == null)
                    _selectedSection = new GEN_Sections_Lookup();
                return _selectedSection;
            }
            set { _selectedSection = value; }
        }

        /// <summary>
        /// Gets or sets current student
        /// </summary>
        public S360Model.ChangeDivisionModel CurrentStudent
        {
            get
            {
                if (_currentStudent == null)
                    _currentStudent = new S360Model.ChangeDivisionModel();
                return _currentStudent;
            }
            set
            {
                _currentStudent = value;
                RaisePropertyChanged("CurrentStudent");
            }
        }

        /// <summary>
        /// Gets or sets Find Student Command
        /// </summary>
        public System.Windows.Input.ICommand FindStudentCommand
        {
            get
            {
                if (_findStudentCommand == null)
                    _findStudentCommand = new RelayCommand<object>(ExecuteFindStudentCommand, CanExecuteFindStudentCommand);
                return _findStudentCommand;
            }
        }

        /// <summary>
        /// Gets or sets Find Student with GR No. Command
        /// </summary>
        public System.Windows.Input.ICommand FindStudentWithGRCommand
        {
            get
            {
                if (_findStudentWithGRCommand == null)
                    _findStudentWithGRCommand = new RelayCommand<object>(ExecuteFindStudentWithGRCommand, CanExecuteFindStudentWithGRCommand);
                return _findStudentWithGRCommand;
            }
        }

        /// <summary>
        /// Gets or sets Cancel Command
        /// </summary>
        public System.Windows.Input.ICommand CancelCommand
        {
            get
            {
                if (_cancelCommand == null)
                    _cancelCommand = new RelayCommand<object>(ExecuteCancelCommand, CanExecuteCancelCommand);
                return _cancelCommand;
            }
        }

        /// <summary>
        /// Gets or sets Clear all command
        /// </summary>
        public System.Windows.Input.ICommand ClearAllCommand
        {
            get
            {
                if (_clearAllCommand == null)
                    _clearAllCommand = new RelayCommand<object>(ExecuteClearAllCommand, CanExecuteClearAllCommand);
                return _clearAllCommand;
            }
        }

        /// <summary>
        /// Gets or sets Remove Student command
        /// </summary>
        public System.Windows.Input.ICommand RemoveStudentCommand
        {
            get
            {
                if (_removeStudentCommand == null)
                    _removeStudentCommand = new RelayCommand<object>(ExecuteRemoveStudentCommand, CanExecuteRemoveStudentCommand);
                return _removeStudentCommand;
            }
        }

        /// <summary>
        /// gets or sets the result to display
        /// </summary>
        public string Result
        {
            get { return _result; }
            set
            {
                _result = value;
                RaisePropertyChanged("Result");
            }
        }

        #endregion

        #region [ Events ]

        private bool CanExecuteFindStudentCommand(object sender)
        {
            if (string.IsNullOrEmpty(SelectedSection.Name))
                return false;
            return true;
        }

        private void ExecuteFindStudentCommand(object sender)
        {
            View.Student.UC_FindStudentScreen findStuent = new View.Student.UC_FindStudentScreen();
            findStuent.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            FindStudentViewModel findStudentVM = new FindStudentViewModel();
            findStudentVM.SelectedSection = this._selectedSection;
            findStuent.DataContext = findStudentVM;
            if (findStuent.ShowDialog() == true)
            {
                findStudentVM = findStuent.DataContext as FindStudentViewModel;
                if (findStudentVM.SelectedStudent != null && findStudentVM.SelectedStudent.StudentId > 0)
                {
                    CurrentStudent = new S360Model.ChangeDivisionModel()
                    {
                        StudentId = findStudentVM.SelectedStudent.StudentId,
                        RegNo = findStudentVM.SelectedStudent.RegNo,
                        Name = findStudentVM.SelectedStudent.Name,
                        SurName = findStudentVM.SelectedStudent.SurName,
                        Father = findStudentVM.SelectedStudent.Father,
                        AccDetId = findStudentVM.SelectedStudent.AccDetId,
                        OldDivision = findStudentVM.SelectedStudent.Standard + findStudentVM.SelectedStudent.Division
                    };
                    Result = string.Format("{0}  ({1})", CurrentStudent.Fullname, CurrentStudent.OldDivision);
                }
            }
        }

        private bool CanExecuteFindStudentWithGRCommand(object obj)
        {
            if (!String.IsNullOrEmpty(CurrentStudent.RegNo) && SelectedSection.Section_Id >= 0)
                return true;
            return false;
        }

        private void ExecuteFindStudentWithGRCommand(object obj)
        {
            if (String.IsNullOrEmpty(SelectedSection.Name))
            {
                WPFCustomMessageBox.CustomMessageBox.ShowOK("Please Select Any Section", "Warning", "OK");
                return;
            }

            S360Model.PromoteStudentModel student = new StudentBusinessLogic().GetStudentWithRegNoAndSection(this.CurrentStudent.RegNo, this.SelectedSection.Section_Id);

            if (student == null)
            {
                WPFCustomMessageBox.CustomMessageBox.ShowOK("No Records Found", "Message", "OK");
                this.CurrentStudent.RegNo = string.Empty;
                this.CurrentStudent = null;
                Result = string.Empty;
            }
            else
            {
                CurrentStudent = new S360Model.ChangeDivisionModel()
                {
                    StudentId = student.StudentId,
                    RegNo = student.RegNo,
                    Name = student.Name,
                    SurName = student.SurName,
                    Father = student.Father,
                    AccDetId = student.AccDetId,
                    OldDivision = student.Standard + student.Division
                };
                Result = string.Format("{0}  {1}", CurrentStudent.Fullname, CurrentStudent.OldDivision);
            }
        }

        private bool CanExecuteCancelCommand(object sender)
        {
            return true;
        }

        private void ExecuteCancelCommand(object sender)
        {
            App.CancelPage(sender);
        }

        private bool CanExecuteClearAllCommand(object sender)
        {
            return true;
        }

        private void ExecuteClearAllCommand(object sender)
        {
            CurrentStudent = null;
            Result = string.Empty;
        }

        private bool CanExecuteRemoveStudentCommand(object sender)
        {
            if (string.IsNullOrEmpty(Result))
                return false;
            return true;
        }

        private void ExecuteRemoveStudentCommand(object sender)
        {
            StudentBusinessLogic business = new StudentBusinessLogic();

            STUD_Students_Master student = business.GetAllStudents().Where(S => S.IsActive == true && S.Student_ID == CurrentStudent.StudentId).FirstOrDefault();
            student.IsActive = false;

            STUD_DetainingOrPromotions_Details DetOrPro = new STUD_DetainingOrPromotions_Details()
            {
                Student_ID = CurrentStudent.StudentId,
                CurrentAcadDetail_ID = CurrentStudent.AccDetId,
                LastAcadDetail_ID = CurrentStudent.AccDetId,
                Status_ID = 3, //Status id for TC issue
                EnteredBy = S360Configuration.Instance.UserID,
                Login_ID = S360Configuration.Instance.LoginID
            };

            STUD_Student_TC TC = new STUD_Student_TC()
            {
                Student_ID = CurrentStudent.StudentId,
                RegNo = CurrentStudent.RegNo,
                IssuedOn = DateTimeOffset.Now,
                IssuedBy_ID = S360Configuration.Instance.UserID,
                Login_ID = S360Configuration.Instance.LoginID
            };

            business.UpdateStudent(student);
            business.SaveStudentDetainPromotion(DetOrPro);
            business.SaveIssueTC(TC);

            ExecuteClearAllCommand(null);
        }

        #endregion
    }
}
