using S360.View.Student;
using S360BusinessLogic;
using S360Entity;
using S360Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S360.ViewModel.Student
{
    public class DetainStudentViewModel : ViewModelBase
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
        /// Variable to store old section of selected student
        /// </summary>
        private GEN_Sections_Lookup _oldSection = null;

        /// <summary>
        /// Variable to store current student details
        /// </summary>
        private DetainStudentModel _currentStudent = null;

        /// <summary>
        /// Variable to store student to remove from detain list
        /// </summary>
        private DetainStudentModel _currentRemovableStudent = null;

        /// <summary>
        /// Variable to store list of student to detain
        /// </summary>
        private ObservableCollection<DetainStudentModel> _detainStudentList = null;

        /// <summary>
        /// Command to find student
        /// </summary>
        private System.Windows.Input.ICommand _findStudentCommand = null;

        /// <summary>
        /// Command to add selected student to detain list
        /// </summary>
        private System.Windows.Input.ICommand _addToListCommand = null;

        /// <summary>
        /// Command to cancel the page
        /// </summary>
        private System.Windows.Input.ICommand _cancelCommand = null;

        /// <summary>
        /// Command to clear all controls in page
        /// </summary>
        private System.Windows.Input.ICommand _clearAllCommand = null;

        /// <summary>
        /// Command to remove selected student from detain list
        /// </summary>
        private System.Windows.Input.ICommand _removeCommand = null;

        /// <summary>
        /// Command to detain selected students
        /// </summary>
        private System.Windows.Input.ICommand _detainStudentCommand = null;

        /// <summary>
        /// Command to find student with GR number
        /// </summary>
        private System.Windows.Input.ICommand _findStudentWithGRCommand = null;

        /// <summary>
        /// Variable to hold detain standard
        /// </summary>
        private string _detainStd = null;

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
        /// Gets or sets Old Section of selected student
        /// </summary>
        public GEN_Sections_Lookup OldSection
        {
            get
            {
                if (_oldSection == null)
                    _oldSection = new GEN_Sections_Lookup();
                return _oldSection;
            }
            set
            {
                _oldSection = value;
                RaisePropertyChanged("OldSection");
            }
        }

        /// <summary>
        /// Gets or sets current student
        /// </summary>
        public DetainStudentModel CurrentStudent
        {
            get
            {
                if (_currentStudent == null)
                    _currentStudent = new DetainStudentModel();
                return _currentStudent;
            }
            set
            {
                _currentStudent = value;
                RaisePropertyChanged("CurrentStudent");
            }
        }

        /// <summary>
        /// Gets or sets student to remove from detain list
        /// </summary>
        public DetainStudentModel CurrentRemovableStudent
        {
            get
            {
                if (_currentRemovableStudent == null)
                    _currentRemovableStudent = new DetainStudentModel();
                return _currentRemovableStudent;
            }
            set { _currentRemovableStudent = value; }
        }

        /// <summary>
        /// gets or sets the old standard to be detained
        /// </summary>
        public string DetainStd
        {
            get
            {
                if (string.IsNullOrEmpty(OldSection.Name))
                    return string.Empty;
                else if (string.IsNullOrEmpty(_detainStd))
                    _detainStd = "Detain in std " + OldSection.Name;
                return _detainStd;
            }
            set
            {
                _detainStd = "Detain in std " + value;
                RaisePropertyChanged("DetainStd");
            }
        }

        /// <summary>
        /// Gets or sets List of students to detain
        /// </summary>
        public ObservableCollection<DetainStudentModel> DetainStudentList
        {
            get
            {
                if (_detainStudentList == null)
                    _detainStudentList = new ObservableCollection<DetainStudentModel>();
                return _detainStudentList;
            }
        }

        /// <summary>
        /// Command to find student
        /// </summary>
        public System.Windows.Input.ICommand FindStudentCommand
        {
            get
            {
                if (_findStudentCommand == null)
                    _findStudentCommand = new RelayCommand<object>(this.ExecuteFindStudent, this.CanExecuteFindStudent);
                return _findStudentCommand;
            }
        }

        /// <summary>
        /// Command to add selected student to detain list
        /// </summary>
        public System.Windows.Input.ICommand AddtToListCommand
        {
            get
            {
                if (_addToListCommand == null)
                    _addToListCommand = new RelayCommand<object>(this.ExecuteAddToListCommand, this.CanExecuteAddToListCommand);
                return _addToListCommand;
            }
        }

        /// <summary>
        /// Command to cancel the UI
        /// </summary>
        public System.Windows.Input.ICommand CancelCommand
        {
            get
            {
                if (_cancelCommand == null)
                    _cancelCommand = new RelayCommand<object>(this.ExecuteCancelCommand, this.CanExecuteCancelCommand);
                return _cancelCommand;
            }
        }

        /// <summary>
        /// Command to clear all control's values
        /// </summary>
        public System.Windows.Input.ICommand ClearAllCommand
        {
            get
            {
                if (_clearAllCommand == null)
                    _clearAllCommand = new RelayCommand<object>(this.ExecuteClearAllCommand, this.CanExecuteClearAllCommand);
                return _clearAllCommand;
            }
        }

        /// <summary>
        /// Command to remove selected student from detain list
        /// </summary>
        public System.Windows.Input.ICommand RemoveCommand
        {
            get
            {
                if (_removeCommand == null)
                    _removeCommand = new RelayCommand<object>(this.ExecuteRemoveCommand, this.CanExecuteRemoveCommand);
                return _removeCommand;
            }
        }

        /// <summary>
        /// Command to detain selected students
        /// </summary>
        public System.Windows.Input.ICommand DetainStudentCommand
        {
            get
            {
                if (_detainStudentCommand == null)
                    _detainStudentCommand = new RelayCommand<object>(this.ExecuteDetainStudentCommand, this.CanExecuteDetainStudentCommand);
                return _detainStudentCommand;
            }
        }

        public System.Windows.Input.ICommand FindStudentWithGRCommand
        {
            get
            {
                if (_findStudentWithGRCommand == null)
                    _findStudentWithGRCommand = new RelayCommand<object>(this.ExecuteFindStudentWithGRCommand, this.CanExecuteFindStudentWithGRCommand);
                return _findStudentWithGRCommand;
            }
        }

        #endregion

        #region [ Events ]

        private bool CanExecuteDetainStudentCommand(object sender)
        {
            if (this._detainStudentList.Count > 0)
                return true;
            return false;
        }

        private void ExecuteDetainStudentCommand(object sender)
        {
            StudentBusinessLogic StBusiness = new StudentBusinessLogic();

            IEnumerable<STUD_Students_Master> students = (from st in StBusiness.GetAllStudents()
                                                          join ds in this._detainStudentList on st.Student_ID equals ds.StudentId
                                                          select st);

            IEnumerable<STUD_StudentAcademic_Details> accDetails = StBusiness.GetAllStudentsAccademicDetails().Where(S => S.IsActive == true);
            List<STUD_StudentAcademic_Details> detainstudentsacc = new List<STUD_StudentAcademic_Details>();
            IEnumerable<STUD_DetainingOrPromotions_Details> detorpromo = StBusiness.GetAllStudentsDetainOrPromotion();
            List<STUD_DetainingOrPromotions_Details> detainorpromotion = new List<STUD_DetainingOrPromotions_Details>();
            foreach (STUD_Students_Master detainst in students)
            {
                detainstudentsacc.AddRange((from stacc in accDetails
                                            where stacc.Student_ID == detainst.Student_ID && stacc.AcademicDet_ID == detainst.CurrentAcaDetail_ID
                                            select stacc));

                detainorpromotion.AddRange((from dop in detorpromo
                                            where dop.Student_ID == detainst.Student_ID && dop.CurrentAcadDetail_ID == detainst.CurrentAcaDetail_ID
                                            select dop));
            }

            foreach (DetainStudentModel ds in this._detainStudentList)
            {
                detainstudentsacc.Where(S => S.Student_ID == ds.StudentId).Select(A =>
                  {
                      A.Section_ID = ds.SectionId;
                      A.Standard_ID = ds.StandardID;
                      return A;
                  }).ToList();

                students.Where(S => S.Student_ID == ds.StudentId).Select(A =>
                  {
                      A.CurrentStd_ID = ds.StandardID;
                      return A;
                  }).ToList();

                detainorpromotion.Where(A => A.Student_ID == ds.StudentId).Select(S =>
                 {
                     S.Status_ID = 0;
                     S.EnteredBy = S360Model.S360Configuration.Instance.UserID;
                     S.Login_ID = S360Model.S360Configuration.Instance.LoginID;
                     return S;
                 }).ToList();
            }

            StBusiness.DetainStudents(students, detainstudentsacc, detainorpromotion);
        }

        private bool CanExecuteRemoveCommand(object sender)
        {
            DetainStudentModel detainStudent = this.DetainStudentList.Where(S => S.StudentId == this.CurrentRemovableStudent.StudentId).FirstOrDefault();
            if (detainStudent != null)
                return true;
            return false;
        }

        private void ExecuteRemoveCommand(object sender)
        {
            this.DetainStudentList.Remove(this.CurrentRemovableStudent);
        }

        private bool CanExecuteClearAllCommand(object sender)
        {
            return true;
        }

        private void ExecuteClearAllCommand(object sender)
        {
            this.DetainStudentList.Clear();
            this.CurrentStudent = null;
            this.CurrentRemovableStudent = null;
            this.OldSection = null;
            this.DetainStd = string.Empty;
        }

        private bool CanExecuteCancelCommand(object sender)
        {
            return true;
        }

        private void ExecuteCancelCommand(object sender)
        {
            foreach (System.Windows.Window currentWindow in System.Windows.Application.Current.Windows)
            {
                if (currentWindow.GetType() == typeof(UC_DetainScreen))
                {
                    currentWindow.Close();
                    break;
                }
            }
        }

        private bool CanExecuteAddToListCommand(object sender)
        {
            if (string.IsNullOrEmpty(this._currentStudent.Name))
                return false;

            DetainStudentModel existingStudent = this.DetainStudentList.Where(S => S.StudentId == this.CurrentStudent.StudentId).FirstOrDefault();
            if (existingStudent != null)
                return false;

            return true;
        }

        private void ExecuteAddToListCommand(object sender)
        {
            StudentBusinessLogic stBusiness = new StudentBusinessLogic();
            IEnumerable<GEN_Standards_Lookup> standards = stBusiness.GetAllStandards();
            _currentStudent.StandardID = (_currentStudent.StandardID == 1) ? (short)102 : (short)(_currentStudent.StandardID - 1);
            _currentStudent.Standard = standards.Where(S => S.Standard_Id == _currentStudent.StandardID).FirstOrDefault().Name;
            _currentStudent.SectionId = (short)standards.Where(S => S.Standard_Id == _currentStudent.StandardID).FirstOrDefault().Section_Id;
            _currentStudent.Section = stBusiness.GetAllSections().Where(S => S.Section_Id == _currentStudent.SectionId).FirstOrDefault().Name;

            this.DetainStudentList.Add(this._currentStudent);
            //this.DetainStudentList.Add(new DetainStudentModel()
            //{
            //    StudentId = _currentStudent.StudentId,
            //    RegNo = _currentStudent.RegNo,
            //    Name = _currentStudent.Name,
            //    SurName = _currentStudent.SurName,
            //    Father = _currentStudent.Father,
            //    SectionId = _currentStudent.SectionId,
            //    Section = _currentStudent.Section,
            //    StandardID = _currentStudent.StandardID,
            //    Standard = _currentStudent.Standard,
            //    User = _currentStudent.User
            //});
        }

        private bool CanExecuteFindStudent(object sender)
        {
            if (!string.IsNullOrEmpty(_selectedSection.Name))
                return true;
            return false;
        }

        private void ExecuteFindStudent(object sender)
        {
            UC_FindStudentScreen findStuent = new UC_FindStudentScreen();
            findStuent.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            FindStudentViewModel findStudentVM = new FindStudentViewModel();
            findStudentVM.SelectedSection = this._selectedSection;
            findStuent.DataContext = findStudentVM;
            if (findStuent.ShowDialog() == true)
            {
                findStudentVM = findStuent.DataContext as FindStudentViewModel;
                if (findStudentVM.SelectedStudent != null && findStudentVM.SelectedStudent.StudentId > 0)
                {
                    CurrentStudent = new DetainStudentModel()
                    {
                        StudentId = findStudentVM.SelectedStudent.StudentId,
                        RegNo = findStudentVM.SelectedStudent.RegNo,
                        Name = findStudentVM.SelectedStudent.Name,
                        SurName = findStudentVM.SelectedStudent.SurName,
                        Father = findStudentVM.SelectedStudent.Father,
                        Section = findStudentVM.SelectedSection.Name,
                        SectionId = findStudentVM.SelectedSection.Section_Id,
                        StandardID = findStudentVM.SelectedStudent.StandardID,
                        Standard = findStudentVM.SelectedStudent.Standard
                    };
                    IEnumerable<GEN_Standards_Lookup> stds = new StudentBusinessLogic().GetAllStandards();
                    DetainStd = stds.Where(S => S.Standard_Id == (this.CurrentStudent.StandardID - 1)).FirstOrDefault().Name;

                    OldSection = _sections.Where(Sec => Sec.Section_Id == stds.Where(S => S.Standard_Id == (this.CurrentStudent.StandardID - 1))
                                    .FirstOrDefault().Section_Id).FirstOrDefault();
                }
            }
        }

        private void ExecuteFindStudentWithGRCommand(object obj)
        {
            if (String.IsNullOrEmpty(SelectedSection.Name))
            {
                WPFCustomMessageBox.CustomMessageBox.ShowOK("Please Select Any Section", "Warning", "OK");
                return;
            }
            //StudentBusinessLogic business = new StudentBusinessLogic();

            //STUD_Students_Master student = (from st in business.GetAllStudents()
            //                                join ac in business.GetAllStudentsAccademicDetails() on st.CurrentAcaDetail_ID equals ac.AcademicDet_ID
            //                                where st.RegNo.ToUpper() == this._currentStudent.RegNo.ToUpper() && ac.Section_ID == this.SelectedSection.Section_Id && st.IsActive == true
            //                                select st).Distinct<STUD_Students_Master>().FirstOrDefault();

            S360Model.PromoteStudentModel student = new StudentBusinessLogic().GetStudentWithRegNoAndSection(this.CurrentStudent.RegNo, this.SelectedSection.Section_Id);

            if (student == null)
            {
                WPFCustomMessageBox.CustomMessageBox.ShowOK("No Records Found", "Message", "OK");
                this.CurrentStudent.RegNo = string.Empty;
                this.CurrentStudent = null;
                OldSection = null;
                DetainStd = null;
            }
            else
            {
                IEnumerable<GEN_Standards_Lookup> stds = new StudentBusinessLogic().GetAllStandards();
                CurrentStudent = new DetainStudentModel()
                {
                    StudentId = student.StudentId,
                    RegNo = student.RegNo,
                    Name = student.Name,
                    SurName = student.SurName,
                    Father = student.Father,
                    Section = SelectedSection.Name,
                    SectionId = SelectedSection.Section_Id,
                    StandardID = student.StandardID,
                    Standard = student.Standard
                };

                OldSection = _sections.Where(Sec => Sec.Section_Id == stds.Where(S => S.Standard_Id == (this.CurrentStudent.StandardID - 1))
                                .FirstOrDefault().Section_Id).FirstOrDefault();

                DetainStd = stds.Where(S => S.Standard_Id == (this.CurrentStudent.StandardID - 1)).FirstOrDefault().Name;
            }
        }

        private bool CanExecuteFindStudentWithGRCommand(object obj)
        {
            if (!String.IsNullOrEmpty(CurrentStudent.RegNo) && SelectedSection.Section_Id >= 0)
                return true;
            return false;
        }

        #endregion
    }
}
