using S360Entity;
using S360Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;
using System.Data;
using S360BusinessLogic;

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
            if (!string.IsNullOrEmpty(_findString))
                return true;
            return false;
        }

        private void ExecuteSearchCommand(object sender)
        {
            StudentBusinessLogic studentBussiness = new StudentBusinessLogic();
            _studentsList.Clear();
            System.Collections.Generic.IEnumerable<STUD_Students_Master> students = studentBussiness.GetStudentsBySearchStringAndSection
                (this._findString, this.SelectedSection.Section_Id);
            if (students == null || students.Count() < 1)
            {
                WPFCustomMessageBox.CustomMessageBox.Show("Could Not Find Any Student");
                this._findString = string.Empty;
            }
            else
            {
                foreach (STUD_Students_Master st in students)
                {
                    _studentsList.Add(new PromoteStudentModel()
                    {
                        Division = st.CurrentDiv,
                        Father = st.FatherName,
                        LastAcademicDetID = (long)st.CurrentAcaDetail_ID,
                        Name = st.Name,
                        RegNo = st.RegNo,
                        SatusID = 0,
                        Section = this.SelectedSection.Name,
                        SectionId = this.SelectedSection.Section_Id,
                        Standard = studentBussiness.GetAllStandards().Where(S => S.Standard_Id == st.CurrentStd_ID).FirstOrDefault().Name,
                        StandardID = (short)st.CurrentStd_ID,
                        StudentId = (long)st.Student_ID,
                        SurName = st.Surname
                    });
                }
            }
        }

        private bool CanExecuteCancelCommand(object sender)
        {
            return true;
        }

        private void ExecuteCancelCommand(object sender)
        {
            SelectStudent(false);
        }

        private bool CanExecuteSelectCommand(object sender)
        {
            return true;
        }

        private void ExecuteSelectCommand(object sender)
        {
            SelectStudent(true);
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

        private void SelectStudent(bool DialogueResult)
        {
            foreach (System.Windows.Window wind in System.Windows.Application.Current.Windows)
            {
                if (wind.GetType() == typeof(View.Student.UC_FindStudentScreen))
                {
                    wind.DialogResult = DialogueResult;
                    wind.Close();
                    break;
                }
            }
        }

        #endregion
    }
}
