using S360BusinessLogic;
using S360Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        /// Command TO Clear All
        /// </summary>
        private ICommand _clearAllCommand;

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

        #endregion

        #region Events

        private bool CanExecuteClearAllCommand(object sender)
        {
            return true;
        }

        private void ExecuteClearAllCommand(object sender)
        {
            System.Windows.MessageBox.Show("Clear All Button Clicked");
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
