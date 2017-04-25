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

        private ObservableCollection<GEN_Sections_Lookup> _sections;

        private GEN_Sections_Lookup _selectedSection;

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
        }

        #endregion

        #region Public Properties

        public ICommand ClearAllCommand
        {
            get { return _clearAllCommand; }
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
            }

        }

        #endregion

        #region Events

        private bool ClearAllCommand_CanExecute()
        {
            return true;
        }

        private void ClearAllCommand_Execute()
        {
            
        }

        #endregion

        #region Private Functions
        #endregion
    }
}
