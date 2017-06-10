using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S360Entity;
using System.Collections.ObjectModel;
using S360BusinessLogic;

namespace S360.ViewModel.Student
{
    public class AllotDivisionViewModel : ViewModelBase
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
        /// Command to change division
        /// </summary>
        private System.Windows.Input.ICommand _changeDivisionCommand = null;

        /// <summary>
        /// Command to cancel
        /// </summary>
        private System.Windows.Input.ICommand _cancelCommand = null;

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
        /// Gets or sets Change Division Command
        /// </summary>
        public System.Windows.Input.ICommand ChangeDivisionCommand
        {
            get
            {
                if (_changeDivisionCommand == null)
                    _changeDivisionCommand = new RelayCommand<object>(ExecuteChangeDivisionCommand, CanExecuteChangeDivisionCommand);
                return _changeDivisionCommand;
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

                    Result = string.Empty;
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
                Result = string.Empty;
            }
        }

        private bool CanExecuteChangeDivisionCommand(object sender)
        {
            if (CurrentStudent.StudentId > 0 && !string.IsNullOrEmpty(CurrentStudent.NewDivision))
                return true;
            return false;
        }

        private void ExecuteChangeDivisionCommand(object sender)
        {
            StudentBusinessLogic business = new StudentBusinessLogic();
            STUD_Students_Master student = business.GetAllStudents().Where(S => S.Student_ID == this.CurrentStudent.StudentId).FirstOrDefault();
            STUD_StudentAcademic_Details Acc = business.GetAllStudentsAccademicDetails().Where(A => A.Student_ID == this.CurrentStudent.StudentId
                                                && A.AcademicDet_ID == this.CurrentStudent.AccDetId).FirstOrDefault();

            student.CurrentDiv = CurrentStudent.NewDivision.ToUpper();
            Acc.Division = CurrentStudent.NewDivision.ToUpper();

            business.UpdateStudent(student);
            business.UpdateStudentAcademics(Acc);

            //Result = string.Format(SelectedSection.Name.Substring(0, 1) + " " + CurrentStudent.RegNo + " - " + CurrentStudent.Fullname + "\t\t" + "Division Changed from " + CurrentStudent.OldDivision + " to " + CurrentStudent.NewDivision);
            Result = string.Format("{0} {1} - {2} \t\tDivision changed from {3} to {4}", SelectedSection.Name.Substring(0, 1), CurrentStudent.RegNo,
                    CurrentStudent.Fullname, CurrentStudent.OldDivision, CurrentStudent.NewDivision);
        }

        private bool CanExecuteCancelCommand(object sender)
        {
            return true;
        }

        private void ExecuteCancelCommand(object sender)
        {
            App.CancelPage(sender);
        }

        #endregion
    }
}
