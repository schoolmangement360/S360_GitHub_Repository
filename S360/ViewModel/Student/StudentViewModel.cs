using S360BusinessLogic;
using S360Controlls.BasicControls;
using S360Entity;
using S360Exceptions;
using S360Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace S360
{
    public class StudentViewModel : ViewModelBase
    {
        #region Private Variables

        /// <summary>
        /// Student BusinessLogic Object Initialization
        /// </summary>
        private StudentBusinessLogic studentBusinessLogic;

        /// <summary>
        /// Variable To Store Collection Of Sections
        /// </summary>
        private ObservableCollection<GEN_Sections_Lookup> _sections;

        /// <summary>
        /// Variable to Store Selected Section
        /// </summary>
        private GEN_Sections_Lookup _selectedSection;

        /// <summary>
        /// Variable To Store Collection Of Standards
        /// </summary>
        private ObservableCollection<GEN_Standards_Lookup> _standards;

        /// <summary>
        /// Variable to Store Selected Standard
        /// </summary>
        private GEN_Standards_Lookup _selectedStandard;

        /// <summary>
        /// Variable To Store Collection Of Languages
        /// </summary>
        private ObservableCollection<GEN_Languages_Lookup> _languages;

        /// <summary>
        /// Variable to Store Selected Language
        /// </summary>
        private GEN_Languages_Lookup _selectedLanguage;

        /// <summary>
        /// Variable To Store Collection Of Religions
        /// </summary>
        private ObservableCollection<GEN_Religions_Lookup> _religions;

        /// <summary>
        /// Variable to Store Selected Religion
        /// </summary>
        private GEN_Religions_Lookup _selectedReligion;

        /// <summary>
        /// Variable To Store Collection Of Categorys
        /// </summary>
        private ObservableCollection<GEN_StudentCategory_Lookup> _studentcategorys;

        /// <summary>
        /// Variable to Store Selected Category
        /// </summary>
        private GEN_StudentCategory_Lookup _selectedCategory;

        /// <summary>
        /// Variable to Store Property
        /// </summary>
        private string _studentGRNo;

        /// <summary>
        /// Variable to Store Property
        /// </summary>
        private string _studentName;

        /// <summary>
        /// Variable to Store Property
        /// </summary>
        private string _fatherName;

        /// <summary>
        /// Variable to Store Property
        /// </summary>
        private string _motherName;

        /// <summary>
        /// Variable to Store Property
        /// </summary>
        private string _surName;

        /// <summary>
        /// Variable to Store Property
        /// </summary>
        private string _studentAddress;

        /// <summary>
        /// Variable to Store Property
        /// </summary>
        private string _studentRemarks;

        /// <summary>
        /// Variable to Store Property
        /// </summary>
        private string _motherTongue;

        /// <summary>
        /// Variable to Store Property
        /// </summary>
        private string _studentDivision;

        /// <summary>
        /// Variable to Store Property
        /// </summary>
        private DateTime _dateOfBirth;

        /// <summary>
        /// Variable to Store Property
        /// </summary>
        private string _cast;

        /// <summary>
        /// Variable to Store Property
        /// </summary>
        private string _religiontext;

        /// <summary>
        /// Variable to Store Property
        /// </summary>
        private string _gender;

        /// <summary>
        /// Variable to Store Property
        /// </summary>
        private string _mobile1;

        /// <summary>
        /// Variable to Store Property
        /// </summary>
        private string _mobile2;

        /// <summary>
        /// Variable to Store Property
        /// </summary>
        private string _mobile3;

        /// <summary>
        /// Variable to Store Property
        /// </summary>
        private string _homeNo;

        /// <summary>
        /// Variable to Store Property
        /// </summary>
        private string _workNo;

        /// <summary>
        /// Variable to Store Property
        /// </summary>
        private string _email;

        /// <summary>
        /// Variable to Store Property
        /// </summary>
        private string _RFIDCard;

        /// <summary>
        /// Variable to Store Property
        /// </summary>
        private string _aadharNo;

        /// <summary>
        /// Variable to Store Property
        /// </summary>
        private string _contact1;

        /// <summary>
        /// Variable to store value for displaying Cancel button
        /// </summary>
        private Visibility _iscancelVisible = Visibility.Visible;

        /// <summary>
        /// Command TO Clear All
        /// </summary>
        private ICommand _clearAllCommand;

        /// <summary>
        /// Command TO Clear All
        /// </summary>
        private ICommand _saveCommand;

        /// <summary>
        /// Command TO Cancel
        /// </summary>
        private ICommand _cancelCommand;

        #endregion

        #region Constructor

        /// <summary>
        /// StudentViewModel Constructor
        /// </summary>
        public StudentViewModel()
        {
            studentBusinessLogic = new StudentBusinessLogic();

            this.Sections = studentBusinessLogic.GetAllSections();
            this.Religions = studentBusinessLogic.GetAllStudentReligion();
            this.Languages = studentBusinessLogic.GetAllLanguages();
            this.StudentCategorys = studentBusinessLogic.GetAllStudentCategory();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Clear Button Click
        /// </summary>
        public ICommand ClearAllCommand
        {
            get
            {
                if (this._clearAllCommand == null)
                {
                    this._clearAllCommand = new RelayCommand<object>(this.ExecuteClearAllCommand, this.CanExecuteClearAllCommand);
                }

                return this._clearAllCommand;
            }
        }

        /// <summary>
        /// Cancel Button Click
        /// </summary>
        public ICommand CancelCommand
        {
            get
            {
                if (this._cancelCommand == null)
                {
                    this._cancelCommand = new RelayCommand<object>(this.ExecuteCancelCommand, this.CanExecuteCancelCommand);
                }

                return this._cancelCommand;
            }
        }

        /// <summary>
        /// Save Button Click
        /// </summary>
        public ICommand SaveCommand
        {
            get
            {
                if (this._saveCommand == null)
                {
                    this._saveCommand = new RelayCommand<object>(this.ExecuteSaveCommand, this.CanExecuteSaveCommand);
                }

                return this._saveCommand;
            }
        }

        public ObservableCollection<GEN_Sections_Lookup> Sections
        {
            get
            {
                return _sections;
            }

            set
            {
                _sections = value;
            }

        }

        public GEN_Sections_Lookup SelectedSection
        {
            get
            {
                return _selectedSection;
            }

            set
            {
                _selectedSection = value;
                if (_selectedSection != null)
                {
                    this.Standards = this.Std_Sec(_selectedSection.Section_Id);
                }
            }

        }

        public ObservableCollection<GEN_Standards_Lookup> Standards
        {
            get
            {
                return _standards;
            }

            set
            {
                _standards = value;
                RaisePropertyChanged("Standards");
            }

        }

        public GEN_Standards_Lookup SelectedStandard
        {
            get
            {
                return _selectedStandard;
            }

            set
            {
                _selectedStandard = value;
            }

        }

        public ObservableCollection<GEN_Languages_Lookup> Languages
        {
            get
            {
                return _languages;
            }

            set
            {
                _languages = value;
            }

        }

        public GEN_Languages_Lookup SelectedLanguage
        {
            get
            {
                return _selectedLanguage;
            }

            set
            {
                _selectedLanguage = value;
            }

        }

        public ObservableCollection<GEN_Religions_Lookup> Religions
        {
            get
            {
                return _religions;
            }

            set
            {
                _religions = value;
            }

        }

        public GEN_Religions_Lookup SelectedReligion
        {
            get
            {
                return _selectedReligion;
            }

            set
            {
                _selectedReligion = value;
            }

        }

        public ObservableCollection<GEN_StudentCategory_Lookup> StudentCategorys
        {
            get
            {
                return _studentcategorys;
            }

            set
            {
                _studentcategorys = value;
            }

        }

        public GEN_StudentCategory_Lookup SelectedCategory
        {
            get
            {
                return _selectedCategory;
            }

            set
            {
                _selectedCategory = value;
            }

        }

        public string GRNO
        {
            get
            {
                return _studentGRNo;
            }

            set
            {
                _studentGRNo = value;
            }

        }

        public string FatherName
        {
            get
            {
                return _studentName;
            }

            set
            {
                _studentName = value;
            }

        }

        public string StudentName
        {
            get
            {
                return _fatherName;
            }

            set
            {
                _fatherName = value;
            }

        }

        public string MotherName
        {
            get
            {
                return _motherName;
            }

            set
            {
                _motherName = value;
            }

        }

        public string SurName
        {
            get
            {
                return _surName;
            }

            set
            {
                _surName = value;
            }

        }

        public string StudentAddress
        {
            get
            {
                return _studentAddress;
            }

            set
            {
                _studentAddress = value;
            }

        }

        public string StudentRemarks
        {
            get
            {
                return _studentRemarks;
            }

            set
            {
                _studentRemarks = value;
            }

        }

        public string MotherTongue
        {
            get
            {
                return _motherTongue;
            }

            set
            {
                _motherTongue = value;
            }

        }

        public string StudentDivision
        {
            get
            {
                return _studentDivision;
            }

            set
            {
                _studentDivision = value;
            }

        }

        public DateTime DateOfBirth
        {
            get
            {
                return _dateOfBirth;
            }

            set
            {
                _dateOfBirth = value;
            }

        }

        public string Cast
        {
            get
            {
                return _cast;
            }

            set
            {
                _cast = value;
            }

        }

        public string ReligionText
        {
            get
            {
                return _religiontext;
            }

            set
            {
                _religiontext = value;
            }

        }

        public string SelectedGender
        {
            get
            {
                return _gender;
            }

            set
            {
                _gender = value;
            }

        }

        public string Mobile1
        {
            get
            {
                return _mobile1;
            }

            set
            {
                _mobile1 = value;
            }

        }

        public string Mobile2
        {
            get
            {
                return _mobile2;
            }

            set
            {
                _mobile2 = value;
            }

        }

        public string Mobile3
        {
            get
            {
                return _mobile3;
            }

            set
            {
                _mobile3 = value;
            }

        }

        public string HomeNo
        {
            get
            {
                return _homeNo;
            }

            set
            {
                _homeNo = value;
            }

        }

        public string WorkNo
        {
            get
            {
                return _workNo;
            }

            set
            {
                _workNo = value;
            }

        }

        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                _email = value;
            }

        }

        public string RFID
        {
            get
            {
                return _RFIDCard;
            }

            set
            {
                _RFIDCard = value;
            }

        }

        public string AadharNo
        {
            get
            {
                return _aadharNo;
            }

            set
            {
                _aadharNo = value;
            }

        }

        public string Contact1
        {
            get
            {
                return _contact1; ;
            }

            set
            {
                _contact1 = value;
            }

        }

        public Visibility IscancelVisible
        {
            get { return _iscancelVisible; }
            set { _iscancelVisible = value; }
        }

        #endregion

        #region Events

        private bool CanExecuteCancelCommand(object sender)
        {
            return true;
        }

        private void ExecuteCancelCommand(object sender)
        {
            this.CancelPage(sender);
        }

        private bool CanExecuteClearAllCommand(object sender)
        {
            return true;
        }

        private void ExecuteClearAllCommand(object sender)
        {

            MessageBoxResult result = WPFCustomMessageBox.CustomMessageBox.ShowOKCancel("Do you want to clear this page ?", "S360 Application", "OK", "Cancel");
            if (result == MessageBoxResult.OK)
            {
                bool clearAll = ValidateControls.ClearAllControls(sender);
            }
        }

        private bool CanExecuteSaveCommand(object sender)
        {
            return true;
        }

        private void ExecuteSaveCommand(object sender)
        {
            try
            {
                ControlValidationStatus controlValidationStatus = ValidateControls.ValidateAllControls(sender);

                if (controlValidationStatus != null && !controlValidationStatus.isValid)
                {
                    WPFCustomMessageBox.CustomMessageBox.ShowOK(controlValidationStatus.ValidationMessage, "S360 Application", "OK");
                    return;
                }

                STUD_Students_Master studentDetails = new STUD_Students_Master();

                if (!string.IsNullOrEmpty(GRNO))
                    studentDetails.RegNo = GRNO;

                if (!string.IsNullOrEmpty(ReligionText))
                    studentDetails.Religion = ReligionText;

                if (!string.IsNullOrEmpty(StudentName))
                    studentDetails.Name = StudentName;

                if (!string.IsNullOrEmpty(FatherName))
                    studentDetails.FatherName = FatherName;

                if (!string.IsNullOrEmpty(SurName))
                    studentDetails.Surname = SurName;

                if (!string.IsNullOrEmpty(StudentAddress))
                    studentDetails.Address = StudentAddress;

                if (!string.IsNullOrEmpty(StudentRemarks))
                    studentDetails.Remarks = StudentRemarks;

                if (!string.IsNullOrEmpty(MotherTongue))
                    studentDetails.MotherTongue = MotherTongue;

                if (!string.IsNullOrEmpty(MotherName))
                    studentDetails.MotherName = MotherName;

                if (!string.IsNullOrEmpty(StudentDivision) && StudentDivision.Length < 3)
                {
                    studentDetails.CurrentDiv = StudentDivision;
                }
                else
                {
                    WPFCustomMessageBox.CustomMessageBox.ShowOK("Invalid Division", "S360 Application", "OK");
                    return;
                }

                if (DateOfBirth != null)
                    studentDetails.DOB = DateOfBirth;

                if (!string.IsNullOrEmpty(Cast))
                    studentDetails.Caste = Cast;

                if (!string.IsNullOrEmpty(Mobile1))
                    studentDetails.Mobile1 = Mobile1;

                if (!string.IsNullOrEmpty(Mobile2))
                    studentDetails.Mobile2 = Mobile2;

                if (!string.IsNullOrEmpty(Mobile3))
                    studentDetails.Mobile3 = Mobile3;

                if (!string.IsNullOrEmpty(HomeNo))
                    studentDetails.HomePh = HomeNo;

                if (!string.IsNullOrEmpty(WorkNo))
                    studentDetails.WorkPh = WorkNo;

                if (!string.IsNullOrEmpty(Email))
                    studentDetails.Email = Email;

                if (!string.IsNullOrEmpty(RFID))
                    studentDetails.RFIDTag = RFID;

                if (!string.IsNullOrEmpty(AadharNo))
                    studentDetails.AadharNo = AadharNo;

                if (!string.IsNullOrEmpty(Contact1))
                    studentDetails.PrimaryContact = Contact1;

                if (SelectedCategory != null)
                    studentDetails.Category_ID = SelectedCategory.Category_Id;

                if (SelectedStandard != null)
                    studentDetails.CurrentStd_ID = SelectedStandard.Standard_Id;

                if (SelectedLanguage != null)
                    studentDetails.Language_ID = SelectedLanguage.Language_Id;

                if (!string.IsNullOrEmpty(SelectedGender) && SelectedGender.Length < 2)
                    studentDetails.Gender = SelectedGender;

                if (SelectedReligion != null)
                    studentDetails.Religion_ID = SelectedReligion.Religion_Id;

                studentDetails.CurrentAcaDetail_ID = 1;
                studentDetails.LastModifiedBy_ID = S360Configuration.Instance.UserID;
                studentDetails.LastModifiedOn = DateTime.Now;
                studentDetails.IsActive = true;
                studentDetails.EnteredBy_ID = S360Configuration.Instance.UserID;
                studentDetails.EnteredOn = DateTime.Now;

                STUD_Students_Master studentdetails = studentBusinessLogic.SaveStudent(studentDetails);

                if (studentdetails != null)
                {
                    STUD_StudentAcademic_Details AcademicDetails = new STUD_StudentAcademic_Details();
                    AcademicDetails.Section_ID = SelectedSection.Section_Id;
                    AcademicDetails.AcademicYearStart = S360Configuration.Instance.AcademicYearStart;
                    AcademicDetails.AcademicYearEnd = S360Configuration.Instance.AcademicYearEnd;
                    STUD_StudentAcademic_Details result = studentBusinessLogic.SaveStudentAcademicDetails(studentdetails, AcademicDetails);
                    if (result != null)
                    {
                        WPFCustomMessageBox.CustomMessageBox.ShowOK("Student Saved Sucessfull", "S360 Application", "OK");
                        bool clearAll = ValidateControls.ClearAllControls(sender);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new S360Exception(ex.Message, ex.InnerException);
            }
        }

        #endregion

        #region Private Functions

        private ObservableCollection<GEN_Standards_Lookup> Std_Sec(int sectionID)
        {
            IEnumerable<GEN_Standards_Lookup> Standards = studentBusinessLogic.GetAllStandards().Where(l => l.Section_Id == sectionID);
            return new ObservableCollection<GEN_Standards_Lookup>(Standards);
        }

        #endregion
    }
}
