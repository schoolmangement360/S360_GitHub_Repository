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
        #endregion
    }
}
