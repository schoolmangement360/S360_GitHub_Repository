using S360Model;
using System.Collections.Generic;
using System.Windows.Input;
using System;
using S360Entity;
using System.Linq;

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
        /// Variable to hold all sections
        /// </summary>
        private IEnumerable<GEN_Sections_Lookup> _sections = null;

        /// <summary>
        /// Variable to hold all standards
        /// </summary>
        private IEnumerable<GEN_Standards_Lookup> _standards = null;

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
        /// Gets all sections
        /// </summary>
        public IEnumerable<GEN_Sections_Lookup> Sections
        {
            get
            {
                if (_sections == null)
                    _sections = new S360BusinessLogic.StudentBusinessLogic().GetAllSections();
                return _sections;
            }
        }

        /// <summary>
        /// Gets all standards
        /// </summary>
        public IEnumerable<GEN_Standards_Lookup> Standards
        {
            get
            {
                if (_standards == null)
                    _standards = new S360BusinessLogic.StudentBusinessLogic().GetAllStandards();
                return _standards;
            }
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

        ///// <summary>
        ///// Gets or sets PromoteAllStudents button Enable or disable value
        ///// </summary>
        //public bool IsBtnPromoteAllEnable
        //{
        //    get { return _isbtnPromoteAllEnable; }
        //    set
        //    {
        //        _isbtnPromoteAllEnable = value;
        //        RaisePropertyChanged("IsBtnPromoteAllEnable");
        //    }
        //}

        ///// <summary>
        ///// Gets or sets ViewLogPromotion button Enable or disable value
        ///// </summary>
        //public bool IsBtnViewLogPromotionEnable
        //{
        //    get { return _isbtnViewLogPromotionEnable; }
        //    set { _isbtnViewLogPromotionEnable = value; }
        //}

        ///// <summary>
        ///// Gets or sets Detain Students button Enable or disable value
        ///// </summary>
        //public bool IsBtnDetainEnable
        //{
        //    get { return _isbtnDetainEnable; }
        //    set { _isbtnDetainEnable = value; }
        //}

        ///// <summary>
        ///// Gets or sets ViewLogDetain button Enable or disable value
        ///// </summary>
        //public bool IsBtnViewLogDetainEnable
        //{
        //    get { return _isbtnViewLogDetainEnable; }
        //    set { _isbtnViewLogDetainEnable = value; }
        //}

        #endregion

        #region [ Events ]

        /// <summary>
        /// Method to allow Cancel command or not
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        private bool CanExecuteCancelCommand(object sender)
        {
            return true;
        }

        /// <summary>
        /// Execute Cancel button click operations
        /// </summary>
        /// <param name="sender"></param>
        private void ExecuteCancelCommand(object sender)
        {
            App.CancelPage(sender);
        }

        /// <summary>
        /// Method to allow CheckDataIntegrity command or not
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        private bool CanExecuteCheckDataIntegrityCommand(object sender)
        {
            return true;
        }

        /// <summary>
        /// Execute CheckDataIntegrity button click operations
        /// </summary>
        /// <param name="sender"></param>
        private void ExecuteCheckDataIntegrityCommand(object sender)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to allow Start Promotion command or not
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        private bool CanExecuteStartPromotionCommand(object sender)
        {
            return true;
        }

        /// <summary>
        /// Execute StartPromotion button click operations
        /// </summary>
        /// <param name="sender"></param>
        private void ExecuteStartPromotionCommand(object sender)
        {
            _isbtnPromoteAllEnable = true;
        }

        /// <summary>
        /// Method to allow Promote All Student command or not
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        private bool CanExecutePromoteAllStudentCommand(object sender)
        {
            return _isbtnPromoteAllEnable;
        }

        /// <summary>
        /// Execute PromoteAllStudent button click operations
        /// </summary>
        /// <param name="sender"></param>
        private void ExecutePromoteAllStudentCommand(object sender)
        {
            S360BusinessLogic.StudentBusinessLogic StudentBusiness = new S360BusinessLogic.StudentBusinessLogic();

            IEnumerable<STUD_StudentAcademic_Details> studentsaccademicdetails = StudentBusiness.GetAllStudentsAccademicDetails().Where(S => S.IsActive = true);

            studentsaccademicdetails.Select(S =>
            {
                S.AcademicYearStart = S360Model.S360Configuration.Instance.AcademicYearStart;
                S.AcademicYearEnd = S360Model.S360Configuration.Instance.AcademicYearEnd;
                S.Standard_ID = (S.Standard_ID != 102 /*&& S.Standard_ID != 12*/) ? ++S.Standard_ID : 1;
                //S.Standard_ID = (S.Standard_ID == 102) ? 1 : S.Standard_ID;
                S.Section_ID = Standards.Where(St => St.Standard_Id == S.Standard_ID).FirstOrDefault() == null ? S.Section_ID :
                                            Standards.Where(St => St.Standard_Id == S.Standard_ID).FirstOrDefault().Section_Id;
                return S;
            }).ToList();

            IEnumerable<STUD_Students_Master> Students = StudentBusiness.GetAllStudents().Where(S => S.IsActive == true);

            STUD_Students_Master PromotingStudent = null;

            foreach (STUD_StudentAcademic_Details studentacc in studentsaccademicdetails)
            {
                StudentBusiness.SavePromotion(studentacc);

                PromotingStudent = Students.Where(St => St.Student_ID == studentacc.Student_ID).FirstOrDefault();
                PromotingStudent.CurrentAcaDetail_ID = studentacc.AcademicDet_ID;
                PromotingStudent.CurrentStd_ID = studentacc.Standard_ID;
                PromotingStudent.LastModifiedBy_ID = S360Model.S360Configuration.Instance.LoginID;
                PromotingStudent.LastModifiedOn = System.DateTimeOffset.Now;

                StudentBusiness.UpdateStudent(PromotingStudent);
            }
        }

        /// <summary>
        /// Method to allow View Promotion Log command or not
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        private bool CanExecuteViewLogPromotionCommand(object sender)
        {
            return true;
        }

        /// <summary>
        /// Execute ViewLogPromotion button click operations
        /// </summary>
        /// <param name="sender"></param>
        private void ExecuteViewLogPromotionCommand(object sender)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to allow Detain command or not
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        private bool CanExecuteDetainCommand(object sender)
        {
            return true;
        }

        /// <summary>
        /// Execute DetainStudents button click operations
        /// </summary>
        /// <param name="sender"></param>
        private void ExecuteDetainCommand(object sender)
        {
            View.Student.UC_DetainScreen detain = new View.Student.UC_DetainScreen();
            ViewModel.Student.DetainStudentViewModel detainVM = new DetainStudentViewModel();
            detain.DataContext = detainVM;
            detain.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            detain.ShowDialog();
        }

        /// <summary>
        /// Method to allow View Detain Log or not
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        private bool CanExecuteViewLogDetainCommand(object sender)
        {
            return true;
        }

        /// <summary>
        /// Execute ViewLogDetain button click operations
        /// </summary>
        /// <param name="sender"></param>
        private void ExecuteViewLogDetainCommand(object sender)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
