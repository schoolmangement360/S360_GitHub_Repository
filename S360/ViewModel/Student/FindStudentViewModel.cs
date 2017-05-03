using S360Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace S360.ViewModel.Student
{
    public class FindStudentViewModel : ViewModelBase
    {
        #region [ Private Variables ]

        /// <summary>
        /// variable to store findstring value
        /// </summary>
        private string _findString = null;

        /// <summary>
        /// variable to store selected section value
        /// </summary>
        private GEN_Sections_Lookup _selectedSection = null;

        /// <summary>
        /// collection variable to store all search result students
        /// </summary>
        private ICollection<STUD_Students_Master> _studentsList = null;

        private STUD_Students_Master _selectedStudent = null;

        /// <summary>
        /// command to search students
        /// </summary>
        private ICommand _searchCommand = null;

        /// <summary>
        /// command to cancel the form
        /// </summary>
        private ICommand _cancelCommand = null;

        /// <summary>
        /// command to select a student
        /// </summary>
        private ICommand _selectCommand = null;

        #endregion

        #region [ Constructor ]

        #endregion

        #region [ Public Properties ]

        public string FindString
        {
            get { return _findString; }
            set { _findString = value; }
        }

        public ICollection<STUD_Students_Master> StudentsList
        {
            get
            {
                if (_studentsList == null)
                    _studentsList = new ObservableCollection<STUD_Students_Master>();
                return _studentsList;
            }
        }

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

        public STUD_Students_Master SelectedStudent
        {
            get
            {
                if (_selectedStudent == null)
                    _selectedStudent = new STUD_Students_Master();
                return _selectedStudent;
            }
            set { _selectedStudent = value; }
        }

        public ICommand SearchCommand
        {
            get
            {
                if (_searchCommand == null)
                    this._searchCommand = new RelayCommand<object>(this.ExecuteSearchCommand, this.CanExecuteSearchCommand);
                return _searchCommand;
            }
        }

        public ICommand CancelCommand
        {
            get
            {
                if (_cancelCommand == null)
                    _cancelCommand = new RelayCommand<object>(this.ExecuteCancelCommand, this.CanExecuteCancelCommand);
                return _cancelCommand;
            }
        }

        public ICommand SelectCommand
        {
            get
            {
                if (_selectCommand == null)
                    _selectCommand = new RelayCommand<object>(this.ExecuteSelectCommand, this.CanExecuteSelectCommand);
                return _selectCommand;
            }
        }

        #endregion

        #region  [ Events ]

        private bool CanExecuteSearchCommand(object sender)
        {
            return true;
        }

        private void ExecuteSearchCommand(object sender)
        {
            
        }

        private bool CanExecuteCancelCommand(object sender)
        {
            return true;
        }

        private void ExecuteCancelCommand(object sender)
        {
            System.Windows.MessageBox.Show("Cancelling");
        }

        private bool CanExecuteSelectCommand(object sender)
        {
            return true;
        }

        private void ExecuteSelectCommand(object sender)
        {
            System.Windows.MessageBox.Show("Selecting");
        }

        #endregion
    }
}
