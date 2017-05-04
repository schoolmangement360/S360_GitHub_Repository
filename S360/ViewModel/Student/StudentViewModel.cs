using S360BusinessLogic;
using S360Entity;
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
        /// Command TO Clear All
        /// </summary>
        private ICommand _clearAllCommand;

        /// <summary>
        /// Command TO Clear All
        /// </summary>
        private ICommand _saveCommand;

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

        #endregion

        #region Events

        private bool CanExecuteClearAllCommand(object sender)
        {
            return true;
        }

        private void ExecuteClearAllCommand(object sender)
        {

        }

        private bool CanExecuteSaveCommand(object sender)
        {
            return true;
        }

        private void ExecuteSaveCommand(object sender)
        {
            UserControl ucStudentAdd = sender as UserControl;
            foreach (TextBox tb in FindVisualChildren<TextBox>(ucStudentAdd))
            {
                if (tb.Text == string.Empty)
                {
                    tb.Focus();
                    tb.Background = System.Windows.Media.Brushes.IndianRed;
                    return;
                }
            }

            STUD_Students_Master studentDetails = new STUD_Students_Master
            {
                RegNo = GRNO,
                Name = StudentName,
                FatherName = FatherName,
                Surname = SurName,
                Address = StudentAddress,
                Remarks = StudentRemarks,
                MotherTongue = MotherTongue,
                CurrentDiv = StudentDivision,
                DOB = DateOfBirth,
                Caste = Cast,
                Mobile1 = Mobile1,
                Mobile2 = Mobile2,
                Mobile3 = Mobile3,
                HomePh = HomeNo,
                WorkPh = WorkNo,
                Email = Email,
                RFIDTag = RFID,
                AadharNo = AadharNo,
                PrimaryContact = Contact1,
                Category_ID = SelectedCategory.Category_Id,
                CurrentStd_ID = SelectedStandard.Standard_Id,
                Language_ID = SelectedLanguage.Language_Id,
                Gender = "",
                Religion_ID = SelectedReligion.Religion_Id,
                CurrentAcaDetail_ID = 0
            };

            STUD_Students_Master result = studentBusinessLogic.SaveStudent(studentDetails);
        }

        #endregion

        #region Private Functions

        private ObservableCollection<GEN_Standards_Lookup> Std_Sec(int sectionID)
        {
            IEnumerable<GEN_Standards_Lookup> Standards = studentBusinessLogic.GetAllStandards().Where(l => l.Section_Id == sectionID);
            return new ObservableCollection<GEN_Standards_Lookup>(Standards);
        }

        private static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < System.Windows.Media.VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = System.Windows.Media.VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        #endregion
    }
}
