using S360Entity;
using S360Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;
using System.Data;

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
        private ObservableCollection<PromoteStudentModel> _studentsList = null;

        /// <summary>
        /// Variable to store selected student
        /// </summary>
        private PromoteStudentModel _selectedStudent = null;

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

        /// <summary>
        /// command to select item on mouse doubleclick
        /// </summary>
        private ICommand _listViewDoubleClickCommand = null;

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
        public ObservableCollection<PromoteStudentModel> StudentsList
        {
            get
            {
                if (_studentsList == null)
                    _studentsList = new ObservableCollection<PromoteStudentModel>();
                return _studentsList;
            }
            set { _studentsList = value; }
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

        public PromoteStudentModel SelectedStudent
        {
            get
            {
                if (_selectedStudent == null)
                    _selectedStudent = new PromoteStudentModel();
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

        public ICommand ListViewDoubleClickCommand
        {
            get
            {
                if (_listViewDoubleClickCommand == null)
                    _listViewDoubleClickCommand = new RelayCommand<object>(this.ExecuteListViewDoubleClickCommand, this.CanExecuteListViewDoubleClickCommand);
                return _listViewDoubleClickCommand;
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
            if (this._studentsList == null)
                this._studentsList = new ObservableCollection<PromoteStudentModel>();
            _studentsList.Add(new PromoteStudentModel()
            {
                RegNo = "1",
                StudentId = 1,
                Name = "Mathew",
                SurName = "Markose",
                Father = "Markose",
                Standard = "10",
                Division = "D"
            });
            _studentsList.Add(new PromoteStudentModel()
            {
                RegNo = "2",
                StudentId = 2,
                Name = "Martin",
                SurName = "Markose",
                Father = "Markose",
                Standard = "12",
                Division = "B"
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
            SelectStudent();
        }

        private bool CanExecuteListViewDoubleClickCommand(object sender)
        {
            return true;
        }

        private void ExecuteListViewDoubleClickCommand(object sender)
        {

        }

        #endregion

        #region [ Private Methods ]

        private void SelectStudent()
        {
            foreach (System.Windows.Window wind in System.Windows.Application.Current.Windows)
            {
                if (wind.GetType() == typeof(View.Student.UC_FindStudentScreen))
                {
                    wind.DialogResult = true;
                    wind.Close();
                    break;
                }
            }
        }

        #endregion
    }
}
