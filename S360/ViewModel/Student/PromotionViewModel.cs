using S360Model;
using System.Collections.Generic;
using System.Windows.Input;
using System;

namespace S360.ViewModel.Student
{
    public class PromotionViewModel : ViewModelBase
    {
        #region [ Private Variables ]

        /// <summary>
        /// Variable to store the list of students for promotion or detain
        /// </summary>
        private List<PromoteStudentModel> _promotionStudentList = null;

        /// <summary>
        /// Variable to store the list of detained students
        /// </summary>
        private List<PromoteStudentModel> _detainStudentList = null;

        /// <summary>
        /// Command to cancel the screen
        /// </summary>
        private ICommand _cancelCommand = null;

        /// <summary>
        /// Command to check data integrity
        /// </summary>
        private ICommand _checkDataIntegrityCommand = null;

        /// <summary>
        /// Command to start promotion
        /// </summary>
        private ICommand _startPromotionCommand = null;

        /// <summary>
        /// Command to promote all students
        /// </summary>
        private ICommand _promoteAllStudentsCommand = null;

        /// <summary>
        /// Command to view log for promote all students
        /// </summary>
        private ICommand _viewLogPromotionCommand = null;

        /// <summary>
        /// Command to detain students
        /// </summary>
        private ICommand _detaincommand = null;

        /// <summary>
        /// Command to view log for detain students
        /// </summary>
        private ICommand _viewLogdetainCommand = null;

        /// <summary>
        /// Variable to store button PromoteAllStudent Enable value
        /// </summary>
        private bool _isbtnPromoteAllEnable = false;

        /// <summary>
        /// Variable to store button ViewLogPromotion Enable value
        /// </summary>
        private bool _isbtnViewLogPromotionEnable = false;

        /// <summary>
        /// Variable to store button Detain Enable value
        /// </summary>
        private bool _isbtnDetainEnable = false;

        /// <summary>
        /// Variable to store button ViewLogDetain Enable value
        /// </summary>
        private bool _isbtnViewLogDetainEnable = false;

        #endregion

        #region [ Constructor ]

        #endregion

        #region [ Public Properties ]

        /// <summary>
        /// Gets or Sets Students List for promotion
        /// </summary>
        public List<PromoteStudentModel> PromotionStudentList
        {
            get
            {
                if (_promotionStudentList == null)
                    _promotionStudentList = new List<PromoteStudentModel>();
                return _promotionStudentList;
            }
            set { _promotionStudentList = value; }
        }

        /// <summary>
        /// Gets or Sets students list for detain
        /// </summary>
        public List<PromoteStudentModel> DetainStudentList
        {
            get
            {
                if (_detainStudentList == null)
                    _detainStudentList = new List<PromoteStudentModel>();
                return _detainStudentList;
            }
            set { _detainStudentList = value; }
        }

        /// <summary>
        /// Gets Cancel Command
        /// </summary>
        public ICommand CancelCommand
        {
            get
            {
                if (_cancelCommand == null)
                    _cancelCommand = new RelayCommand<object>(this.ExecuteCancelCommand, this.CanExecuteCancelCommand);
                return _cancelCommand;
            }
        }

        /// <summary>
        /// Gets CheckDataIntegrity Command
        /// </summary>
        public ICommand CheckDataIntegrityCommand
        {
            get
            {
                if (_checkDataIntegrityCommand == null)
                    _checkDataIntegrityCommand = new RelayCommand<object>(this.ExecuteCheckDataIntegrityCommand, this.CanExecuteCheckDataIntegrityCommand);
                return _checkDataIntegrityCommand;
            }
        }

        /// <summary>
        /// Gets StartPromotion Command
        /// </summary>
        public ICommand StartPromotionCommand
        {
            get
            {
                if (_startPromotionCommand == null)
                    _startPromotionCommand = new RelayCommand<object>(this.ExecuteStartPromotionCommand, this.CanExecuteStartPromotionCommand);
                return _startPromotionCommand;
            }
        }

        /// <summary>
        /// Gets PromoteAllStudents Command
        /// </summary>
        public ICommand PromoteAllStudentsCommand
        {
            get
            {
                if (_promoteAllStudentsCommand == null)
                    _promoteAllStudentsCommand = new RelayCommand<object>(this.ExecutePromoteAllStudentCommand, this.CanExecutePromoteAllStudentCommand);
                return _promoteAllStudentsCommand;
            }
        }

        /// <summary>
        /// Gets ViewLogPromotion Command
        /// </summary>
        public ICommand ViewLogPromotionCommand
        {
            get
            {
                if (_viewLogPromotionCommand == null)
                    _viewLogPromotionCommand = new RelayCommand<object>(this.ExecuteViewLogPromotionCommand, this.CanExecuteViewLogPromotionCommand);
                return _viewLogPromotionCommand;
            }
        }

        /// <summary>
        /// Gets Detain command
        /// </summary>
        public ICommand Detaincommand
        {
            get
            {
                if (_detaincommand == null)
                    _detaincommand = new RelayCommand<object>(this.ExecuteDetainCommand, this.CanExecuteDetainCommand);
                return _detaincommand;
            }
        }

        /// <summary>
        /// Gets ViewLogdetain Command
        /// </summary>
        public ICommand ViewLogdetainCommand
        {
            get
            {
                if (_viewLogdetainCommand == null)
                    _viewLogdetainCommand = new RelayCommand<object>(this.ExecuteViewLogDetainCommand, this.CanExecuteViewLogDetainCommand);
                return _viewLogdetainCommand;
            }
        }

        /// <summary>
        /// Gets or sets PromoteAllStudents button Enable or disable value
        /// </summary>
        public bool IsBtnPromoteAllEnable
        {
            get { return _isbtnPromoteAllEnable; }
            set { _isbtnPromoteAllEnable = value; }
        }

        /// <summary>
        /// Gets or sets ViewLogPromotion button Enable or disable value
        /// </summary>
        public bool IsBtnViewLogPromotionEnable
        {
            get { return _isbtnViewLogPromotionEnable; }
            set { _isbtnViewLogPromotionEnable = value; }
        }

        /// <summary>
        /// Gets or sets Detain Students button Enable or disable value
        /// </summary>
        public bool IsBtnDetainEnable
        {
            get { return _isbtnDetainEnable; }
            set { _isbtnDetainEnable = value; }
        }

        /// <summary>
        /// Gets or sets ViewLogDetain button Enable or disable value
        /// </summary>
        public bool IsBtnViewLogDetainEnable
        {
            get { return _isbtnViewLogDetainEnable; }
            set { _isbtnViewLogDetainEnable = value; }
        }

        #endregion

        #region [ Events ]

        private bool CanExecuteCancelCommand(object sender)
        {
            return true;
        }

        private void ExecuteCancelCommand(object sender)
        {
            throw new NotImplementedException();
        }

        private bool CanExecuteCheckDataIntegrityCommand(object sender)
        {
            return true;
        }

        private void ExecuteCheckDataIntegrityCommand(object sender)
        {
            throw new NotImplementedException();
        }

        private bool CanExecuteStartPromotionCommand(object sender)
        {
            return true;
        }

        private void ExecuteStartPromotionCommand(object sender)
        {
            throw new NotImplementedException();
        }

        private bool CanExecutePromoteAllStudentCommand(object sender)
        {
            return true;
        }

        private void ExecutePromoteAllStudentCommand(object sender)
        {
            throw new NotImplementedException();
        }

        private bool CanExecuteViewLogPromotionCommand(object sender)
        {
            return true;
        }

        private void ExecuteViewLogPromotionCommand(object sender)
        {
            throw new NotImplementedException();
        }

        private bool CanExecuteDetainCommand(object sender)
        {
            return true;
        }

        private void ExecuteDetainCommand(object sender)
        {
            throw new NotImplementedException();
        }

        private bool CanExecuteViewLogDetainCommand(object sender)
        {
            return true;
        }

        private void ExecuteViewLogDetainCommand(object sender)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
