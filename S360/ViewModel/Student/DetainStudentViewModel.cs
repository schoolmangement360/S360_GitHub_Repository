using S360.View.Student;
using S360BusinessLogic;
using S360Entity;
using S360Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S360.ViewModel.Student
{
    public class DetainStudentViewModel
    {
        #region [ Private Variables ]

        /// <summary>
        /// Variable to store Section Lookup values
        /// </summary>
        private ObservableCollection<GEN_Sections_Lookup> _sections = null;

        /// <summary>
        /// Variable to hold selected value from Section Lookup
        /// </summary>
        private GEN_Sections_Lookup _selectedSection = null;

        /// <summary>
        /// Variable to store G.Reg No os selected student
        /// </summary>
        private string _RegNum = null;

        /// <summary>
        /// Variable to store Name of selected student
        /// </summary>
        private string _name = null;

        /// <summary>
        /// Variable to store old section of selected student
        /// </summary>
        private GEN_Sections_Lookup _oldSection = null;

        /// <summary>
        /// Variable to store list of student to detain
        /// </summary>
        private List<DetainStudentModel> _detainStudentList = null;

        /// <summary>
        /// Command to find student
        /// </summary>
        private System.Windows.Input.ICommand _findStudentCommand = null;

        /// <summary>
        /// Command to add selected student to detain list
        /// </summary>
        private System.Windows.Input.ICommand _addtToListCommand = null;

        /// <summary>
        /// Command to cancel the page
        /// </summary>
        private System.Windows.Input.ICommand _cancelCommand = null;

        /// <summary>
        /// Command to clear all controls in page
        /// </summary>
        private System.Windows.Input.ICommand _clearAllCommand = null;

        /// <summary>
        /// Command to remove selected student from detain list
        /// </summary>
        private System.Windows.Input.ICommand _removeCommand = null;

        /// <summary>
        /// Command to detain selected students
        /// </summary>
        private System.Windows.Input.ICommand _detainStudentCommand = null;

        #endregion

        #region [ Constructor ]

        #endregion

        #region [ Public Properties ]

        /// <summary>
        /// Gets Sections for Lookup
        /// </summary>
        public ObservableCollection<GEN_Sections_Lookup> Sections
        {   
            get
            {
                if (_sections == null)
                    _sections = new ObservableCollection<GEN_Sections_Lookup>(((SectionRepository)S360RepositoryFactory.GetRepository("SECTION")).GetAll());
                return _sections;
            }
        }

        /// <summary>
        /// Gets or sets selected value of section lookup
        /// </summary>
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

        /// <summary>
        /// Gets or sets RegNo
        /// </summary>
        public string RegNo
        {
            get { return _RegNum; }
            set { _RegNum = value; }
        }

        /// <summary>
        /// Gets or sets Student Name
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Gets or sets Old Section of selected student
        /// </summary>
        public GEN_Sections_Lookup OldSection
        {
            get
            {
                if (_oldSection == null)
                    _oldSection = new GEN_Sections_Lookup();
                return _oldSection;
            }
            set { _oldSection = value; }
        }

        /// <summary>
        /// Gets or sets List of students to detain
        /// </summary>
        public List<DetainStudentModel> DetainStudentList
        {
            get
            {
                if (_detainStudentList == null)
                    _detainStudentList = new List<DetainStudentModel>();
                return _detainStudentList;
            }
            set { _detainStudentList = value; }
        }

        /// <summary>
        /// Command to find student
        /// </summary>
        public System.Windows.Input.ICommand FindStudentCommand
        {
            get
            {
                if (_findStudentCommand == null)
                    _findStudentCommand = new RelayCommand<object>(this.ExecuteFindStudent, this.CanExecuteFindStudent);
                return _findStudentCommand;
            }
        }

        /// <summary>
        /// Command to add selected student to detain list
        /// </summary>
        public System.Windows.Input.ICommand AddtToListCommand
        {
            get
            {
                if (_addtToListCommand == null)
                    _addtToListCommand = new RelayCommand<object>(this.ExecuteAddToListCommand, this.CanExecuteAddToListCommand);
                return _addtToListCommand;
            }
        }

        /// <summary>
        /// Command to cancel the UI
        /// </summary>
        public System.Windows.Input.ICommand CancelCommand
        {
            get
            {
                if (_cancelCommand == null)
                    _cancelCommand = new RelayCommand<object>(this.ExecuteCancelCommand, this.CanExecuteCancelCommand);
                return _cancelCommand;
            }
        }

        /// <summary>
        /// Command to clear all control's values
        /// </summary>
        public System.Windows.Input.ICommand ClearAllCommand
        {
            get
            {
                if (_clearAllCommand == null)
                    _clearAllCommand = new RelayCommand<object>(this.ExecuteClearAllCommand, this.CanExecuteClearAllCommand);
                return _clearAllCommand;
            }
        }

        /// <summary>
        /// Command to remove selected student from detain list
        /// </summary>
        public System.Windows.Input.ICommand RemoveCommand
        {
            get
            {
                if (_removeCommand == null)
                    _removeCommand = new RelayCommand<object>(this.ExecuteRemoveCommand, this.CanExecuteRemoveCommand);
                return _removeCommand;
            }
        }

        /// <summary>
        /// Command to detain selected students
        /// </summary>
        public System.Windows.Input.ICommand DetainStudentCommand
        {
            get
            {
                if (_detainStudentCommand == null)
                    _detainStudentCommand = new RelayCommand<object>(this.ExecuteDetainStudentCommand, this.CanExecuteDetainStudentCommand);
                return _detainStudentCommand;
            }
        }

        #endregion

        #region [ Events ]

        private bool CanExecuteDetainStudentCommand(object sender)
        {
            return true;
        }

        private void ExecuteDetainStudentCommand(object sender)
        {
            
        }

        private bool CanExecuteRemoveCommand(object sender)
        {
            return true;
        }

        private void ExecuteRemoveCommand(object sender)
        {
            
        }

        private bool CanExecuteClearAllCommand(object sender)
        {
            return true;
        }

        private void ExecuteClearAllCommand(object sender)
        {
            
        }

        private bool CanExecuteCancelCommand(object sender)
        {
            return true;
        }

        private void ExecuteCancelCommand(object sender)
        {
            
        }

        private bool CanExecuteAddToListCommand(object sender)
        {
            return true;
        }

        private void ExecuteAddToListCommand(object sender)
        {
            
        }

        private bool CanExecuteFindStudent(object sender)
        {
            return true;
        }

        private void ExecuteFindStudent(object sender)
        {
            UC_FindStudentScreen findStuent = new UC_FindStudentScreen();
            findStuent.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            FindStudentViewModel findStudentVM = new FindStudentViewModel();
            findStuent.DataContext = findStudentVM;
            findStuent.ShowDialog();
        }

        #endregion
    }
}
