using S360Entity;
using S360Model;
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
        private ObservableCollection<StudentBaseModel> _studentsList = null;

        /// <summary>
        /// Variable to store selected student
        /// </summary>
        private StudentBaseModel _selectedStudent = null;

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

        /// <summary>
        /// Gets or sets string keyword to find student
        /// </summary>
        public string FindString
        {
            get { return _findString; }
            set { _findString = value; }
        }

        /// <summary>
        /// Gets students list to bind on data grid
        /// </summary>
        public ObservableCollection<StudentBaseModel> StudentsList
        {
            get
            {
                if (_studentsList == null)
                    _studentsList = new ObservableCollection<StudentBaseModel>();
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

        public StudentBaseModel SelectedStudent
        {
            get
            {
                if (_selectedStudent == null)
                    _selectedStudent = new StudentBaseModel();
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
            this._studentsList = new ObservableCollection<StudentBaseModel>();
            _studentsList.Add(new StudentBaseModel()
            {
                RegNo = "1",
                StudentId = 1,
                Name = "Mathew",
                SurName = "Markose",
                Father = "Markose"
            });
            _studentsList.Add(new StudentBaseModel()
            {
                RegNo = "2",
                StudentId = 2,
                Name = "Martin",
                SurName = "Markose",
                Father = "Markose"
            });
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
            
        }

        #endregion
    }
}
