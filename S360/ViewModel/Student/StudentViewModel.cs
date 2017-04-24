using S360BusinessLogic;
using S360Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S360
{
    public class StudentViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Property Changed Event

        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Private Variables

        /// <summary>
        /// Student BusinessLogic Object Initialization
        /// </summary>
        private StudentBusinessLogic studentBusinessLogic;

        private ObservableCollection<GEN_Sections_Lookup> _sections;

        private GEN_Sections_Lookup _selectedSection;

        #endregion

        #region Constructor

        /// <summary>
        /// StudentViewModel Constructor
        /// </summary>
        public StudentViewModel()
        {
            studentBusinessLogic = new StudentBusinessLogic();

            this.Sections = studentBusinessLogic.GetAllSections();
        }

        #endregion

        #region Public Properties

        public ObservableCollection<GEN_Sections_Lookup> Sections
        {
            get
            {
                return _sections;
            }

            set
            {
                _sections = value;
                OnPropertyChanged("Sections");
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
            }

        }
    }

    #endregion

    #region Events
    #endregion

    #region Private Functions
    #endregion

}
