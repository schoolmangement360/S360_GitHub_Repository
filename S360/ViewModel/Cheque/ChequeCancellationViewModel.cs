using S360BusinessLogic;
using S360Entity;
using S360Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace S360.ViewModel.Cheque
{
    public class ChequeCancellationViewModel : ViewModelBase
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
        /// Variable to hold selected active cheque details from list
        /// </summary>
        private ChequeInwardsModel _selectedActiveChq = null;

        /// <summary>
        /// Variable to hold selected cancelled cheque details from list
        /// </summary>
        private ChequeInwardsModel _selectedCancelledChq = null;

        /// <summary>
        /// Variable to hold all active cheques
        /// </summary>
        private System.Collections.ObjectModel.ObservableCollection<ChequeInwardsModel> _activeChequeList = null;

        /// <summary>
        /// Variable to hold all cancelled cheques
        /// </summary>
        private System.Collections.ObjectModel.ObservableCollection<ChequeInwardsModel> _cancelledChequeList = null;

        /// <summary>
        /// Variable to hold flag for whether to list cancelled cheques or not
        /// </summary>
        private bool _isListCancelled = false;

        /// <summary>
        /// Command to load cheques
        /// </summary>
        private ICommand _loadChequesCommand = null;

        /// <summary>
        /// Command to load cancelled cheques
        /// </summary>
        private ICommand _loadCancelledChequesCommand = null;

        /// <summary>
        /// Command to add all active cheques to cancelled cheque list
        /// </summary>
        private ICommand _addAllCommand = null;

        /// <summary>
        /// Command to add selected active cheque to cancelled cheque list
        /// </summary>
        private ICommand _addCommand = null;

        /// <summary>
        /// Command to remove selected cheque from cancelled cheque list
        /// </summary>
        private ICommand _removeCommand = null;

        /// <summary>
        /// Command to remove all cancelled cheques from list
        /// </summary>
        private ICommand _removeAllCommand = null;

        /// <summary>
        /// Command to save changes done
        /// </summary>
        private ICommand _saveChangesCommand = null;

        /// <summary>
        /// Command to cancel page
        /// </summary>
        private ICommand _cancelCommand = null;

        private bool _isSaveEnable = false;

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
        /// gets or sets _selectedActiveChq
        /// </summary>
        public ChequeInwardsModel SelectedActiveChq
        {
            get
            {
                if (_selectedActiveChq == null)
                    _selectedActiveChq = new ChequeInwardsModel();
                return _selectedActiveChq;
            }
            set { _selectedActiveChq = value; }
        }

        /// <summary>
        /// get or sets _selectedCancelledChq
        /// </summary>
        public ChequeInwardsModel SelectedCancelledChq
        {
            get
            {
                if (_selectedCancelledChq == null)
                    _selectedCancelledChq = new ChequeInwardsModel();
                return _selectedCancelledChq;
            }
            set { _selectedCancelledChq = value; }
        }

        /// <summary>
        /// gets or sets _activeChequeList
        /// </summary>
        public ObservableCollection<ChequeInwardsModel> ActiveChequeList
        {
            get
            {
                if (_activeChequeList == null)
                    _activeChequeList = new ObservableCollection<ChequeInwardsModel>();
                return _activeChequeList;
            }
            set
            {
                _activeChequeList = value;
                RaisePropertyChanged("ActiveChequeList");
            }
        }

        /// <summary>
        /// gets or sets _cancelledChequeList
        /// </summary>
        public ObservableCollection<ChequeInwardsModel> CancelledChequeList
        {
            get
            {
                if (_cancelledChequeList == null)
                    _cancelledChequeList = new ObservableCollection<ChequeInwardsModel>();
                return _cancelledChequeList;
            }
            set
            {
                _cancelledChequeList = value;
                RaisePropertyChanged("CancelledChequeList");
            }
        }

        /// <summary>
        /// gets or sets _isListCancelled
        /// </summary>
        public bool IsListCancelled
        {
            get { return _isListCancelled; }
            set { _isListCancelled = value; }
        }

        /// <summary>
        /// gets _loadChequesCommand
        /// </summary>
        public ICommand LoadChequesCommand
        {
            get
            {
                if (_loadChequesCommand == null)
                    _loadChequesCommand = new RelayCommand<object>(ExecuteLoadChequesCommand, CanExecuteLoadChequesCommand);
                return _loadChequesCommand;
            }
        }

        /// <summary>
        /// gets _loadCancelledChequesCommand
        /// </summary>
        public ICommand LoadCancelledChequesCommand
        {
            get
            {
                if (_loadCancelledChequesCommand == null)
                    _loadCancelledChequesCommand = new RelayCommand<object>(ExecuteLoadCancelledChequesCommand, CanExecuteLoadCancelledChequesCommand);
                return _loadCancelledChequesCommand;
            }
        }

        /// <summary>
        /// gets _addAllCommand
        /// </summary>
        public ICommand AddAllCommand
        {
            get
            {
                if (_addAllCommand == null)
                    _addAllCommand = new RelayCommand<object>(ExecuteAddAllCommand, CanExecuteAddAllCommand);
                return _addAllCommand;
            }
        }

        /// <summary>
        /// gets _addCommand
        /// </summary>
        public ICommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                    _addCommand = new RelayCommand<object>(ExecuteAddCommand, CanExecuteAddCommand);
                return _addCommand;
            }
        }

        /// <summary>
        /// gets _removeCommand
        /// </summary>
        public ICommand RemoveCommand
        {
            get
            {
                if (_removeCommand == null)
                    _removeCommand = new RelayCommand<object>(ExecuteRemoveCommand, CanExecuteRemoveCommand);
                return _removeCommand;
            }
        }

        /// <summary>
        /// gets _removeAllCommand
        /// </summary>
        public ICommand RemoveAllCommand
        {
            get
            {
                if (_removeAllCommand == null)
                    _removeAllCommand = new RelayCommand<object>(ExecuteRemoveAllCommand, CanExecuteRemoveAllCommand);
                return _removeAllCommand;
            }
        }

        /// <summary>
        /// gets _saveChangesCommand
        /// </summary>
        public ICommand SaveChangesCommand
        {
            get
            {
                if (_saveChangesCommand == null)
                    _saveChangesCommand = new RelayCommand<object>(ExecuteSaveChangesCommand, CanExecuteSaveChangesCommand);
                return _saveChangesCommand;
            }
        }

        /// <summary>
        /// gets _cancelCommand
        /// </summary>
        public ICommand CancelCommand
        {
            get
            {
                if (_cancelCommand == null)
                    _cancelCommand = new RelayCommand<object>(ExecuteCancelCommand, CanExecuteCancelCommand);
                return _cancelCommand;
            }
        }

        #endregion

        #region [ Public Methods ]

        #endregion

        #region [ Events ]

        private bool CanExecuteLoadChequesCommand(object sender)
        {
            if (!string.IsNullOrEmpty(SelectedSection.Name))
                return true;
            return false;
        }

        private void ExecuteLoadChequesCommand(object sender)
        {
            _isSaveEnable = true;
        }

        private bool CanExecuteLoadCancelledChequesCommand(object sender)
        {
            if (!string.IsNullOrEmpty(SelectedSection.Name))
                return true;
            return false;
        }

        private void ExecuteLoadCancelledChequesCommand(object sender)
        {
            _isSaveEnable = true;
        }

        private bool CanExecuteAddAllCommand(object sender)
        {
            if (ActiveChequeList != null && ActiveChequeList.Count > 0)
                return true;
            return false;
        }

        private void ExecuteAddAllCommand(object sender)
        {

        }

        private bool CanExecuteAddCommand(object sender)
        {
            if ((ActiveChequeList != null && ActiveChequeList.Count > 0) && !string.IsNullOrEmpty(SelectedActiveChq.ChequeNo))
                return true;
            return false;
        }

        private void ExecuteAddCommand(object sender)
        {

        }

        private bool CanExecuteRemoveCommand(object sender)
        {
            if ((CancelledChequeList != null && CancelledChequeList.Count > 0) && !string.IsNullOrEmpty(SelectedCancelledChq.ChequeNo))
                return true;
            return false;
        }

        private void ExecuteRemoveCommand(object sender)
        {

        }

        private bool CanExecuteRemoveAllCommand(object sender)
        {
            if (CancelledChequeList != null && CancelledChequeList.Count > 0)
                return true;
            return false;
        }

        private void ExecuteRemoveAllCommand(object sender)
        {

        }

        private bool CanExecuteSaveChangesCommand(object sender)
        {
            return _isSaveEnable;
        }

        private void ExecuteSaveChangesCommand(object sender)
        {

        }

        private bool CanExecuteCancelCommand(object sender)
        {
            return true;
        }

        private void ExecuteCancelCommand(object sender)
        {
            base.CancelPage(sender);
        }

        #endregion

        #region [ Private Methods ]

        #endregion
    }
}
