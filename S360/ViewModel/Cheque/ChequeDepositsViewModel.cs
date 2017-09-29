using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S360BusinessLogic;
using S360Entity;
using System.Collections.ObjectModel;
using S360Model;

namespace S360.ViewModel.Cheque
{
    class ChequeDepositsViewModel : ViewModelBase
    {
        #region [Private Variables]

        /// <summary>
        /// Variable to store Section Lookup values
        /// </summary>
        private ObservableCollection<GEN_Sections_Lookup> _sections = null ;


        /// <summary>
        /// Command to Load Cheques
        /// </summary>
        private System.Windows.Input.ICommand _loadCheques = null ;

        /// <summary>
        /// Command to Load Add all cheques
        /// </summary>
        private System.Windows.Input.ICommand _addAll = null ;

        /// <summary>
        /// Command to Add cheque
        /// </summary>
        private System.Windows.Input.ICommand _add = null ;

        /// <summary>
        /// Command to Remove all cheques
        /// </summary>
        private System.Windows.Input.ICommand _removeAll = null ;

        /// <summary>
        /// Command to Remove cheque
        /// </summary>
        private System.Windows.Input.ICommand _remove = null ;

        /// <summary>
        /// Command to Save Changes
        /// </summary>
        private System.Windows.Input.ICommand _saveChanges = null ;

        /// <summary>
        /// Command to Cancel ChequeDeposit
        /// </summary>
        private System.Windows.Input.ICommand _cancel= null ;

        /// <summary>
        /// Command to Create Statement
        /// </summary>
        private System.Windows.Input.ICommand _createStatement = null ;

        /// <summary>
        /// Variable to hold Section Id
        /// </summary>
        private short _sectionId = short.MinValue ;

        /// <summary>
        /// Variable to hold all cheques added
        /// </summary>
        private System.Collections.ObjectModel.ObservableCollection<ChequeDepositsModel> _chequeList = null;

        #endregion

        #region [Public Properties]

        /// <summary>
        /// Gets Sections for Lookup
        /// </summary>
        public ObservableCollection<GEN_Sections_Lookup> Sections
        {
            get
            {
                if ( _sections == null )
                     _sections = new ObservableCollection<GEN_Sections_Lookup>(((SectionRepository)S360RepositoryFactory.GetRepository("SECTION")).GetAll());
                return _sections;
            }
        }

        /// <summary>
        /// Gets or sets selected value of section lookup
        /// </summary>
        public short SectionID
        {
            get { return _sectionId; }
            set
            {
                _sectionId = value;
                RaisePropertyChanged("SectionID");
            }
        }

        /// <summary>
        /// Gets the list of added checques
        /// </summary>
        public System.Collections.ObjectModel.ObservableCollection<ChequeDepositsModel> ChequeList
        {
            get
            {
                if (_chequeList == null)
                    _chequeList = new ObservableCollection<ChequeDepositsModel>();
                return _chequeList;
            }
            set
            {
                _chequeList = value;
                RaisePropertyChanged("ChequeList");
            }
        }
        /// <summary>
        /// Command to Load Cheques
        /// </summary>
        public System.Windows.Input.ICommand LoadCheques
        {
            get
            {
                if ( _loadCheques == null )
                     _loadCheques = new RelayCommand<object>( this.ExecuteLoadCheques, this.CanExecuteLoadCheques ) ;
                return _loadCheques ;
            }
        }

        /// <summary>
        /// Command to Add all Cheques
        /// </summary>
        public System.Windows.Input.ICommand AddAll
        {
            get
            {
                if ( _addAll == null )
                     _addAll = new RelayCommand<object>( this.ExecuteAddAll, this.CanExecuteAddAll ) ;
                return _addAll ;
            }
        }

        /// <summary>
        /// Command to Add  Cheques
        /// </summary>
        public System.Windows.Input.ICommand Add
        {
            get
            {
                if ( _add == null )
                     _add = new RelayCommand<object>( this.ExecuteAdd, this.CanExecuteAdd ) ;
                return _add ;
            }
        }

        /// <summary>
        /// Command to Remove all Cheques
        /// </summary>
        public System.Windows.Input.ICommand RemoveAll
        {
            get
            {
                if ( _removeAll == null )
                     _removeAll = new RelayCommand<object>( this.ExecuteRemoveAll, this.CanExecuteRemoveAll ) ;
                return _removeAll ;
            }
        }

        /// <summary>
        /// Command to Remove Cheques
        /// </summary>
        public System.Windows.Input.ICommand Remove
        {
            get
            {
                if ( _remove == null )
                     _remove = new RelayCommand<object>( this.ExecuteRemove, this.CanExecuteRemove ) ;
                return _remove ;
            }
        }

        /// <summary>
        /// Command to Save Changes
        /// </summary>
        public System.Windows.Input.ICommand SaveChanges
        {
            get
            {
                if ( _saveChanges == null)
                     _saveChanges = new RelayCommand<object>( this.ExecuteSaveChanges, this.CanExecuteSaveChanges ) ;
                return _saveChanges ; 
            }
        }

        /// <summary>
        /// Command to Cancel Cheque Deposit
        /// </summary>
        public System.Windows.Input.ICommand Cancel
        {
            get
            {
                if ( _cancel == null)
                     _cancel = new RelayCommand<object>( this.ExecuteCancel, this.CanExecuteCancel ) ;
                return _cancel ;
            }
        }

        /// <summary>
        /// Command to Create Statement
        /// </summary>
        public System.Windows.Input.ICommand CreateStatement
        {
            get
            {
                if ( _createStatement == null )
                     _createStatement = new RelayCommand<object>( this.ExecuteCreateStatement, this.CanExecuteCreateStatement ) ;
                return _createStatement ;
            }
        }

        #endregion

        #region [Events]

        private bool CanExecuteLoadCheques( object sender )
        {
            return true ;
        }

        private void ExecuteLoadCheques( object sender )
        {
            ChequeBusinessLogic chqBusiness = new ChequeBusinessLogic( ) ;
           //_chequeList = chqBusiness.GetAllCheques().Where(s => s.Section_ID == _sectionId).ToObservableCollection();
        }

        private bool CanExecuteAddAll( object sender )
        {
            return true ;
        }

        private void ExecuteAddAll( object sender )
        {

        }

        private bool CanExecuteAdd( object sender )
        {
            return true ; 
        }

        private void ExecuteAdd( object sender )
        {

        }

        private bool CanExecuteRemoveAll( object sender )
        {
            return true ;
        }

        private void ExecuteRemoveAll( object sender )
        {

        }

        private bool CanExecuteRemove( object sender )
        {
            return true ;
        }

        private void ExecuteRemove( object sender )
        {

        }

        private bool CanExecuteSaveChanges( object sender )
        {
            return true ;
        }

        private void ExecuteSaveChanges( object sender )
        {

        }

        private bool CanExecuteCancel( object sender )
        {
            return true ;
        }

        private void ExecuteCancel( object sender )
        {

        }

        private bool CanExecuteCreateStatement( object sender )
        {
            return true ;
        }

        private void ExecuteCreateStatement( object sender )
        {

        }
        #endregion
    }
}
