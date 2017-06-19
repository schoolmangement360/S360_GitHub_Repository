using S360.View.Student;
using S360.ViewModel.Student;
using S360BusinessLogic;
using S360Entity;
using S360Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S360.ViewModel.Cheque
{
    public class ChequeInwardViewModel : ViewModelBase
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
        /// Variable to hold current cheque details
        /// </summary>
        private ChequeInwardsModel _currentChequeInwardModel = null;

        /// <summary>
        /// Variable to hold selected cheque from list
        /// </summary>
        private ChequeInwardsModel _selectedCheque = null;

        /// <summary>
        /// Variable to hold all cheques added
        /// </summary>
        private System.Collections.ObjectModel.ObservableCollection<ChequeInwardsModel> _chequeList = null;

        /// <summary>
        /// Variable to hold value for all users have access or not
        /// </summary>
        private bool _isAllUser = false;

        /// <summary>
        /// Unknown
        /// </summary>
        private string _unknown = null;

        /// <summary>
        /// Command to find student
        /// </summary>
        private System.Windows.Input.ICommand _findStudentCommand = null;

        /// <summary>
        /// command to add new student
        /// </summary>
        private System.Windows.Input.ICommand _newEntryCommand = null;

        /// <summary>
        /// Command to add cheque to list
        /// </summary>
        private System.Windows.Input.ICommand _addChequeCommand = null;

        /// <summary>
        /// Command to cancel the page
        /// </summary>
        private System.Windows.Input.ICommand _cancelCommand = null;

        /// <summary>
        /// Command to clear all controls in page
        /// </summary>
        private System.Windows.Input.ICommand _clearCommand = null;

        /// <summary>
        /// Command to remove selected cheque from list
        /// </summary>
        private System.Windows.Input.ICommand _deleteCQCommand = null;

        /// <summary>
        /// Command to refresh the page
        /// </summary>
        private System.Windows.Input.ICommand _refreshCommand = null;

        /// <summary>
        /// Command to save all cheque details to DB
        /// </summary>
        private System.Windows.Input.ICommand _saveCqsCommand = null;

        /// <summary>
        /// Command to find student with GR number
        /// </summary>
        private System.Windows.Input.ICommand _findStudentWithGRCommand = null;

        #endregion

        #region [ Constructor ]

        public ChequeInwardViewModel()
        {
            ChequeBusinessLogic bussiness = new ChequeBusinessLogic();
            AddToChequeList(bussiness.GetAllUnsavedCheques());
            bussiness = null;
        }

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
        /// Gets or sets Current Cheque Inwards details
        /// </summary>
        public ChequeInwardsModel CurrentChequeInwardModel
        {
            get
            {
                if (_currentChequeInwardModel == null)
                    _currentChequeInwardModel = new ChequeInwardsModel()
                    {
                        ChequeNo = "000000",
                        ChqAmount = (decimal)0.00
                    };
                return _currentChequeInwardModel;
            }
            set
            {
                _currentChequeInwardModel = value;
                RaisePropertyChanged("CurrentChequeInwardModel");
            }
        }

        /// <summary>
        /// Gets or sets Current Cheque Inwards details
        /// </summary>
        public ChequeInwardsModel SelectedCheque
        {
            get
            {
                if (_selectedCheque == null)
                    _selectedCheque = new ChequeInwardsModel();
                return _selectedCheque;
            }
            set
            {
                _selectedCheque = value;
                RaisePropertyChanged("SelectedCheque");
            }
        }

        /// <summary>
        /// Gets the list of added checques
        /// </summary>
        public System.Collections.ObjectModel.ObservableCollection<ChequeInwardsModel> ChequeList
        {
            get
            {
                if (_chequeList == null)
                    _chequeList = new ObservableCollection<ChequeInwardsModel>();
                return _chequeList;
            }
        }

        /// <summary>
        /// Gets or sets Is All users or not
        /// </summary>
        public bool IsAllUser
        {
            get { return _isAllUser; }
            set
            {
                _isAllUser = value;
                RaisePropertyChanged("IsAllUser");
            }
        }

        /// <summary>
        /// Unknown
        /// </summary>
        public string Unknown
        {
            get { return _unknown; }
            set
            {
                _unknown = value;
                RaisePropertyChanged("Unknown");
            }
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
        /// Command to add new student
        /// </summary>
        public System.Windows.Input.ICommand NewEntryCommand
        {
            get
            {
                if (_newEntryCommand == null)
                    _newEntryCommand = new RelayCommand<object>(ExecuteNewEntryCommand, CanExecuteNewEntryCommand);
                return _newEntryCommand;
            }
        }

        /// <summary>
        /// Command to add selected student to detain list
        /// </summary>
        public System.Windows.Input.ICommand AddtChequeCommand
        {
            get
            {
                if (_addChequeCommand == null)
                    _addChequeCommand = new RelayCommand<object>(ExecuteAddChequeCommand, CanExecuteAddChequeCommand);
                return _addChequeCommand;
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
        public System.Windows.Input.ICommand ClearCommand
        {
            get
            {
                if (_clearCommand == null)
                    _clearCommand = new RelayCommand<object>(ExecuteClearCommand, CanExecuteClearCommand);
                return _clearCommand;
            }
        }

        /// <summary>
        /// Command to remove selected student from detain list
        /// </summary>
        public System.Windows.Input.ICommand DeleteCQCommand
        {
            get
            {
                if (_deleteCQCommand == null)
                    _deleteCQCommand = new RelayCommand<object>(ExecuteDeleteCQCommand, CanExecuteDeleteCQCommand);
                return _deleteCQCommand;
            }
        }

        /// <summary>
        /// Command to refresh the page
        /// </summary>
        public System.Windows.Input.ICommand RefreshCommand
        {
            get
            {
                if (_refreshCommand == null)
                    _refreshCommand = new RelayCommand<object>(ExecuteRefreshCommand, CanExecuteRefreshCommand);
                return _refreshCommand;
            }
        }

        /// <summary>
        /// Command to save all cheques entered
        /// </summary>
        public System.Windows.Input.ICommand SaveCqsCommand
        {
            get
            {
                if (_saveCqsCommand == null)
                    _saveCqsCommand = new RelayCommand<object>(ExecuteSaveChqCommand, CanExecuteSaveChqCommand);
                return _saveCqsCommand;
            }
        }

        /// <summary>
        /// Command to find student with GR number
        /// </summary>
        public System.Windows.Input.ICommand FindStudentWithGRCommand
        {
            get
            {
                if (_findStudentWithGRCommand == null)
                    _findStudentWithGRCommand = new RelayCommand<object>(this.ExecuteFindStudentWithGRCommand, this.CanExecuteFindStudentWithGRCommand);
                return _findStudentWithGRCommand;
            }
        }

        #endregion

        #region [ Events ]

        private bool CanExecuteFindStudent(object sender)
        {
            if (!string.IsNullOrEmpty(_selectedSection.Name))
                return true;
            return false;
        }

        private void ExecuteFindStudent(object sender)
        {
            UC_FindStudentScreen findStuent = new UC_FindStudentScreen();
            findStuent.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            FindStudentViewModel findStudentVM = new FindStudentViewModel();
            findStudentVM.SelectedSection = this._selectedSection;
            findStuent.DataContext = findStudentVM;
            if (findStuent.ShowDialog() == true)
            {
                findStudentVM = findStuent.DataContext as FindStudentViewModel;
                if (findStudentVM.SelectedStudent != null && findStudentVM.SelectedStudent.StudentId > 0)
                {
                    CurrentChequeInwardModel = new ChequeInwardsModel()
                    {
                        Student_ID = findStudentVM.SelectedStudent.StudentId,
                        RegNo = findStudentVM.SelectedStudent.RegNo,
                        StudentName = findStudentVM.SelectedStudent.Name + " " + findStudentVM.SelectedStudent.SurName + " " + findStudentVM.SelectedStudent.Father,
                        Section_ID = findStudentVM.SelectedStudent.SectionId,
                        Section = findStudentVM.SelectedStudent.Section,
                        ChequeNo = "000000",
                        ChqAmount = 0
                    };
                }
            }
        }

        private bool CanExecuteNewEntryCommand(object sender)
        {
            return true;
        }

        private void ExecuteNewEntryCommand(object sender)
        {

        }

        private bool CanExecuteAddChequeCommand(object sender)
        {
            if (string.IsNullOrEmpty(this.CurrentChequeInwardModel.StudentName))
                return false;

            ChequeInwardsModel existingCheque = this.ChequeList.Where(S => S.Student_ID == this.CurrentChequeInwardModel.Student_ID
                                                && S.ChequeNo == this.CurrentChequeInwardModel.ChequeNo).FirstOrDefault();
            if (existingCheque != null)
                return false;

            return true;
        }

        private void ExecuteAddChequeCommand(object sender)
        {
            decimal chequeNo = 0;
            decimal Amt = 0;
            decimal.TryParse(CurrentChequeInwardModel.ChequeNo, out chequeNo);
            if (string.IsNullOrEmpty(CurrentChequeInwardModel.ChequeNo) || chequeNo <= 0)
            {
                WPFCustomMessageBox.CustomMessageBox.ShowOK("Invalid Cq. No", "Warning", "OK");
                return;
            }
            else if (string.IsNullOrEmpty(CurrentChequeInwardModel.Bank))
            {
                WPFCustomMessageBox.CustomMessageBox.ShowOK("Bank cannot be blank", "Warning", "OK");
                return;
            }
            if(!decimal.TryParse(CurrentChequeInwardModel.ChqAmount.ToString(),out Amt))
            {
                WPFCustomMessageBox.CustomMessageBox.ShowOK("Invalid Amount", "Warning", "OK");
                return;
            }
            if(Amt == 0)
            {
                WPFCustomMessageBox.CustomMessageBox.ShowOK("Amount must be greater than 0", "Warning", "OK");
                return;
            }

            if (this._chequeList == null)
                _chequeList = new ObservableCollection<ChequeInwardsModel>();
            CurrentChequeInwardModel.SerialNo = ChequeList.Count + 1;
            CurrentChequeInwardModel.User = LoginBusinessLogic.GetUserByID(S360Configuration.Instance.UserID).Username;
            CurrentChequeInwardModel.EnteredBy = S360Model.S360Configuration.Instance.UserID;
            CurrentChequeInwardModel.Login_ID = S360Model.S360Configuration.Instance.LoginID;
            
            ChequeBusinessLogic business = new ChequeBusinessLogic();
            business.SaveChequeTemp(ConvertToChequeMasterTemp(CurrentChequeInwardModel));

            ChequeList.Add(CurrentChequeInwardModel);
            CurrentChequeInwardModel = null;
            business = null;
        }

        private bool CanExecuteCancelCommand(object sender)
        {
            return true;
        }

        private void ExecuteCancelCommand(object sender)
        {
            App.CancelPage(sender);
        }

        private bool CanExecuteClearCommand(object sender)
        {
            return true;
        }

        private void ExecuteClearCommand(object sender)
        {
            //this.SelectedSection = null;
            //this.ChequeList.Clear();
            this.CurrentChequeInwardModel = null;
            this.IsAllUser = false;
            this.Unknown = string.Empty;
        }

        private bool CanExecuteRefreshCommand(object sender)
        {
            return true;
        }

        private void ExecuteRefreshCommand(object sender)
        {

        }

        private bool CanExecuteDeleteCQCommand(object sender)
        {
            ChequeInwardsModel chequeinward = this.ChequeList.Where(S => S.Student_ID == this._selectedCheque.Student_ID && S.ChequeNo == this._selectedCheque.ChequeNo).FirstOrDefault();
            if (chequeinward != null)
                return true;
            return false;
        }

        private void ExecuteDeleteCQCommand(object sender)
        {
            ChequeBusinessLogic business = new ChequeBusinessLogic();
            business.DeleteTempCheque(ConvertToChequeMasterTemp(SelectedCheque));
            ChequeList.Remove(SelectedCheque);
            ChequeList.Select(S => { S.SerialNo = ChequeList.IndexOf(S); return S; }).ToList();
            business = null;
            SelectedCheque = null;
        }

        private bool CanExecuteSaveChqCommand(object sender)
        {
            if (ChequeList.Count > 0)
                return true;
            return false;
        }

        private void ExecuteSaveChqCommand(object sender)
        {
            if(ChequeList.Count == 0)
            {
                WPFCustomMessageBox.CustomMessageBox.ShowOK("No records to save", "Info", "OK");
                return;
            }

            ChequeBusinessLogic chequeBussiness = new ChequeBusinessLogic();
            foreach (ChequeInwardsModel cheque in ChequeList)
            {
                chequeBussiness.DeleteTempCheque(ConvertToChequeMasterTemp(cheque));
                CHQ_Cheques_Master entity = new CHQ_Cheques_Master()
                {
                    Bank = cheque.Bank,
                    ChequeNo = cheque.ChequeNo,
                    Cheque_ID = cheque.Cheque_ID,
                    ChqAmount = cheque.ChqAmount,
                    ChqStatus_ID = cheque.ChqStatus_ID,
                    EnteredBy = cheque.EnteredBy,
                    EnteredOn = cheque.EnteredOn,
                    InwardDate = cheque.InwardDate,
                    IsActive = cheque.IsActive,
                    Login_ID = S360Model.S360Configuration.Instance.LoginID,
                    Remarks = cheque.Remarks,
                    Section_ID = cheque.Section_ID,
                    Student_ID = cheque.Student_ID
                };
                chequeBussiness.SaveCheque(entity);
            }

            ExecuteClearCommand(null);
            ChequeList.Clear();
            chequeBussiness = null;
            SelectedSection = null;
            CurrentChequeInwardModel = null;
        }

        private bool CanExecuteFindStudentWithGRCommand(object obj)
        {
            if (!String.IsNullOrEmpty(CurrentChequeInwardModel.RegNo) && SelectedSection.Section_Id >= 0)
                return true;
            return false;
        }

        private void ExecuteFindStudentWithGRCommand(object obj)
        {
            if (String.IsNullOrEmpty(SelectedSection.Name))
            {
                WPFCustomMessageBox.CustomMessageBox.ShowOK("Please Select Any Section", "Warning", "OK");
                return;
            }

            S360Model.PromoteStudentModel student = new StudentBusinessLogic().GetStudentWithRegNoAndSection(this.CurrentChequeInwardModel.RegNo, this.SelectedSection.Section_Id);

            if (student == null)
            {
                WPFCustomMessageBox.CustomMessageBox.ShowOK("No Records Found", "Message", "OK");
                this.CurrentChequeInwardModel.RegNo = string.Empty;
                this.CurrentChequeInwardModel = null;
            }
            else
            {
                CurrentChequeInwardModel = new ChequeInwardsModel()
                {
                    Student_ID = student.StudentId,
                    RegNo = student.RegNo,
                    StudentName = student.Name + " " + student.SurName + " " + student.Father,
                    Section_ID = student.SectionId,
                    Section = student.Section,
                    ChequeNo = "000000",
                    ChqAmount = 0
                };
            }
        }

        #endregion

        #region [ Private Methods ]

        /// <summary>
        /// converts the temp cheque list to current cheques
        /// </summary>
        /// <param name="TempCheques"></param>
        /// <returns></returns>
        private void AddToChequeList(IEnumerable<CHQ_Cheques_Master_Temp> TempCheques)
        {
            if (TempCheques == null || TempCheques.Count() == 0)
                return;

            ChequeInwardsModel model;
            StudentBusinessLogic bussiness = new StudentBusinessLogic();
            int serial = 1;
            foreach (CHQ_Cheques_Master_Temp temp in TempCheques)
            {
                STUD_Students_Master student = bussiness.GetAllStudents().Where(S => S.Student_ID == temp.Student_ID).FirstOrDefault();
                GEN_Sections_Lookup sec = bussiness.GetAllSections().Where(S => S.Section_Id == temp.Section_ID).FirstOrDefault();
                model = new ChequeInwardsModel()
                {
                    StudentName = student.Name + " " + student.Surname + " " + student.FatherName,
                    Student_ID = temp.Student_ID,
                    Bank = temp.Bank,
                    ChequeNo = temp.ChequeNo,
                    Cheque_ID = temp.Cheque_ID,
                    ChqAmount = temp.ChqAmount,
                    ChqStatus_ID = temp.ChqStatus_ID,
                    EnteredBy = temp.EnteredBy,
                    EnteredOn = temp.EnteredOn,
                    InwardDate = temp.InwardDate,
                    IsActive = temp.IsActive,
                    Login_ID = temp.Login_ID,
                    RegNo = student.RegNo,
                    Remarks = temp.Remarks,
                    Section = sec.Name,
                    Section_ID = temp.Section_ID,
                    SerialNo = serial++,
                    User = S360Model.S360Configuration.Instance.User
                };

                this.ChequeList.Add(model);
            }
        }

        /// <summary>
        /// Converts the input ChequeMaster object to its temp object type
        /// </summary>
        /// <param name="cheque"></param>
        /// <returns></returns>
        private CHQ_Cheques_Master_Temp ConvertToChequeMasterTemp(CHQ_Cheques_Master cheque)
        {
            return new CHQ_Cheques_Master_Temp()
            {
                Student_ID = cheque.Student_ID,
                Bank = cheque.Bank,
                ChequeNo = cheque.ChequeNo,
                Cheque_ID = cheque.Cheque_ID,
                ChqAmount = cheque.ChqAmount,
                ChqStatus_ID = cheque.ChqStatus_ID,
                EnteredBy = cheque.EnteredBy,
                EnteredOn = cheque.EnteredOn,
                InwardDate = cheque.InwardDate,
                IsActive = cheque.IsActive,
                Login_ID = cheque.Login_ID,
                Remarks = cheque.Remarks,
                Section_ID = cheque.Section_ID
            };
        }

        #endregion
    }
}