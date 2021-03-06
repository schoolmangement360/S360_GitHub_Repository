﻿using S360.View.Student;
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
    public class ChequeEditViewModel : ViewModelBase
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
        /// Command to find student with GR number
        /// </summary>
        private System.Windows.Input.ICommand _findStudentWithGRCommand = null;

        /// <summary>
        /// Command to find student
        /// </summary>
        private System.Windows.Input.ICommand _findStudentCommand = null;

        /// <summary>
        /// Command to select cheque from list
        /// </summary>
        private System.Windows.Input.ICommand _selectChequeCommand = null;

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
        //private System.Windows.Input.ICommand _deleteCQCommand = null;

        /// <summary>
        /// Command to refresh the page
        /// </summary>
        private System.Windows.Input.ICommand _refreshCommand = null;

        /// <summary>
        /// Command to save all cheque details to DB
        /// </summary>
        private System.Windows.Input.ICommand _saveCqsCommand = null;

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
            set
            {
                _chequeList = value;
                RaisePropertyChanged("ChequeList");
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
        public System.Windows.Input.ICommand SelecttChequeCommand
        {
            get
            {
                if (_selectChequeCommand == null)
                    _selectChequeCommand = new RelayCommand<object>(ExecuteSelecttChequeCommand, CanExecuteSelecttChequeCommand);
                return _selectChequeCommand;
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

        #endregion

        #region [ Events ]

        private bool CanExecuteFindStudent(object sender)
        {
            if (!string.IsNullOrEmpty(SelectedSection.Name))
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
                    CurrentChequeInwardModel.Student_ID = findStudentVM.SelectedStudent.StudentId;
                    CurrentChequeInwardModel.StudentName = findStudentVM.SelectedStudent.Name + " " + findStudentVM.SelectedStudent.SurName + " " + findStudentVM.SelectedStudent.Father;
                    CurrentChequeInwardModel.RegNo = findStudentVM.SelectedStudent.RegNo;
                    CurrentChequeInwardModel.Section_ID = findStudentVM.SelectedStudent.SectionId;
                    CurrentChequeInwardModel.Section = findStudentVM.SelectedStudent.Section;
                    RaisePropertyChanged("CurrentChequeInwardModel");

                    ChequeBusinessLogic business = new ChequeBusinessLogic();
                    IEnumerable<CHQ_Cheques_Master> cheques = business.GetAllCheques().Where(C => C.Student_ID == findStudentVM.SelectedStudent.StudentId &&
                                                              C.ChqStatus_ID == 1/*Chq Recieved*/ && C.IsActive == true);
                    int serial = 1;
                    foreach (CHQ_Cheques_Master chq in cheques)
                    {
                        this.ChequeList.Add(ConvertToCheque(chq, serial++));
                    }
                }
            }
        }

        private bool CanExecuteNewEntryCommand(object sender)
        {
            return true;
        }

        private void ExecuteNewEntryCommand(object sender)
        {
            View.Popups.S360PopupWindow popupwnd = new View.Popups.S360PopupWindow("New Student");
            UC_AddStudentScreen ucAddStudent = new UC_AddStudentScreen();
            StudentViewModel viewmodel = new StudentViewModel() { IscancelVisible = System.Windows.Visibility.Hidden };
            ucAddStudent.DataContext = viewmodel;
            popupwnd.PopupContainer.Children.Add(ucAddStudent);
            popupwnd.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            popupwnd.ShowDialog();
        }

        private bool CanExecuteSelecttChequeCommand(object sender)
        {
            if (SelectedCheque != null)
                return true;
            return false;
        }

        private void ExecuteSelecttChequeCommand(object sender)
        {
            CurrentChequeInwardModel.Bank = SelectedCheque.Bank;
            CurrentChequeInwardModel.ChequeNo = SelectedCheque.ChequeNo;
            CurrentChequeInwardModel.Cheque_ID = SelectedCheque.Cheque_ID;
            CurrentChequeInwardModel.ChqAmount = SelectedCheque.ChqAmount;
            CurrentChequeInwardModel.ChqStatus_ID = SelectedCheque.ChqStatus_ID;
            CurrentChequeInwardModel.EnteredBy = SelectedCheque.EnteredBy;
            CurrentChequeInwardModel.EnteredOn = SelectedCheque.EnteredOn;
            CurrentChequeInwardModel.InwardDate = SelectedCheque.InwardDate;
            CurrentChequeInwardModel.IsActive = SelectedCheque.IsActive;
            CurrentChequeInwardModel.Login_ID = SelectedCheque.Login_ID;
            //CurrentChequeInwardModel.RegNo = SelectedCheque.RegNo;
            CurrentChequeInwardModel.Remarks = SelectedCheque.Remarks;
            //CurrentChequeInwardModel.Section = SelectedCheque.Section;
            //CurrentChequeInwardModel.Section_ID = SelectedCheque.Section_ID;
            CurrentChequeInwardModel.SerialNo = SelectedCheque.SerialNo;
            //CurrentChequeInwardModel.StudentName = SelectedCheque.StudentName;
            //CurrentChequeInwardModel.Student_ID = SelectedCheque.Student_ID;
            //CurrentChequeInwardModel.User = SelectedCheque.User;
            RaisePropertyChanged("CurrentChequeInwardModel");
        }

        private bool CanExecuteCancelCommand(object sender)
        {
            return true;
        }

        private void ExecuteCancelCommand(object sender)
        {
            this.CancelPage(sender);
        }

        private bool CanExecuteClearCommand(object sender)
        {
            return true;
        }

        private void ExecuteClearCommand(object sender)
        {
            this.CurrentChequeInwardModel = null;
            this.IsAllUser = false;
            this.Unknown = string.Empty;
            this.SelectedSection = null;
            this.ChequeList.Clear();
        }

        private bool CanExecuteRefreshCommand(object sender)
        {
            return true;
        }

        private void ExecuteRefreshCommand(object sender)
        {

        }

        private bool CanExecuteSaveChqCommand(object sender)
        {
            if (ChequeList.Count > 0)
                return true;
            return false;
        }

        private void ExecuteSaveChqCommand(object sender)
        {
            View.Cheque.UC_ChequeEditScreen uccheque = sender as View.Cheque.UC_ChequeEditScreen;
            ChequeBusinessLogic chequeBussiness;
            try
            {
                ControlValidationStatus status = ValidateControls.ValidateAllControls(uccheque);
                if (status != null && !status.isValid)
                {
                    WPFCustomMessageBox.CustomMessageBox.ShowOK(status.ValidationMessage, "S360 Application", "OK");
                    return;
                }
                decimal chequeNo = 0;
                decimal Amt = 0;
                decimal.TryParse(CurrentChequeInwardModel.ChequeNo, out chequeNo);
                if (string.IsNullOrEmpty(CurrentChequeInwardModel.ChequeNo) || chequeNo <= 0)
                {
                    WPFCustomMessageBox.CustomMessageBox.ShowOK("Invalid Cq. No", "Warning", "OK");
                    S360Controlls.BasicControls.S360TextBox txt = FindVisualChildren<S360Controlls.BasicControls.S360TextBox>(uccheque).Where(S => S.Name == "txtCqNo").FirstOrDefault();
                    txt.Text = string.Empty;
                    txt.Focus();
                    return;
                }
                if (!decimal.TryParse(CurrentChequeInwardModel.ChqAmount.ToString(), out Amt))
                {
                    WPFCustomMessageBox.CustomMessageBox.ShowOK("Invalid Amount", "Warning", "OK");
                    S360Controlls.BasicControls.S360TextBox txt = FindVisualChildren<S360Controlls.BasicControls.S360TextBox>(uccheque).Where(S => S.Name == "txtAmt").FirstOrDefault();
                    txt.Text = string.Empty;
                    txt.Focus();
                    return;
                }
                if (Amt <= 0)
                {
                    WPFCustomMessageBox.CustomMessageBox.ShowOK("Invalid Amount", "Warning", "OK");
                    S360Controlls.BasicControls.S360TextBox txt = FindVisualChildren<S360Controlls.BasicControls.S360TextBox>(uccheque).Where(S => S.Name == "txtAmt").FirstOrDefault();
                    txt.Text = string.Empty;
                    txt.Focus();
                    return;
                }

                chequeBussiness = new ChequeBusinessLogic();
                CHQ_Cheques_Master model = new CHQ_Cheques_Master()
                {
                    Student_ID = CurrentChequeInwardModel.Student_ID,
                    Bank = CurrentChequeInwardModel.Bank,
                    ChequeNo = CurrentChequeInwardModel.ChequeNo,
                    Cheque_ID = CurrentChequeInwardModel.Cheque_ID,
                    ChqAmount = CurrentChequeInwardModel.ChqAmount,
                    ChqStatus_ID = CurrentChequeInwardModel.ChqStatus_ID,
                    EnteredBy = CurrentChequeInwardModel.EnteredBy,
                    //EnteredBy = S360Configuration.Instance.UserID,
                    EnteredOn = CurrentChequeInwardModel.EnteredOn,
                    InwardDate = CurrentChequeInwardModel.InwardDate,
                    IsActive = CurrentChequeInwardModel.IsActive,
                    Login_ID = S360Configuration.Instance.LoginID,
                    Remarks = CurrentChequeInwardModel.Remarks,
                    Section_ID = CurrentChequeInwardModel.Section_ID
                };
                chequeBussiness.UpdateCheque(model);

                CurrentChequeInwardModel = new ChequeInwardsModel()
                {
                    RegNo = SelectedCheque.RegNo,
                    StudentName = SelectedCheque.StudentName,
                    Student_ID = SelectedCheque.Student_ID,
                    Section = SelectedCheque.Section,
                    Section_ID = SelectedCheque.Section_ID
                };

                IEnumerable<CHQ_Cheques_Master> cheques = chequeBussiness.GetAllCheques().Where(C => C.Student_ID == CurrentChequeInwardModel.Student_ID
                                                            && C.ChqStatus_ID == 1 /*Cheque Recieved*/ && C.IsActive == true);

                ChequeList.Clear();
                int serialNo = 1;
                foreach (CHQ_Cheques_Master chq in cheques)
                {
                    this.ChequeList.Add(ConvertToCheque(chq, serialNo++));
                }
                this.SelectedCheque = null;
            }
            catch(Exception ex)
            {
                throw new S360Exceptions.S360Exception(ex.Message, ex.InnerException);
            }
            finally
            {
                //ExecuteClearCommand(null);
                chequeBussiness = null;
            }
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
                CurrentChequeInwardModel.Student_ID = student.StudentId;
                CurrentChequeInwardModel.StudentName = student.Name + " " + student.SurName + " " + student.Father;
                CurrentChequeInwardModel.RegNo = student.RegNo;
                CurrentChequeInwardModel.Section_ID = student.SectionId;
                CurrentChequeInwardModel.Section = student.Section;
                RaisePropertyChanged("CurrentChequeInwardModel");

                ChequeBusinessLogic business = new ChequeBusinessLogic();
                IEnumerable<CHQ_Cheques_Master> cheques = business.GetAllCheques().Where(C => C.Student_ID == student.StudentId &&
                                                            C.ChqStatus_ID == 1/*Chq Recieved*/ && C.IsActive == true);
                int serialNo = 1;
                foreach (CHQ_Cheques_Master chq in cheques)
                {
                    this.ChequeList.Add(ConvertToCheque(chq, serialNo++));
                }
            }
        }

        #endregion

        #region [ Private Methods ]

        /// <summary>
        /// Converts the input ChequeMaster object to its model object type
        /// </summary>
        /// <param name="cheque"></param>
        /// <returns></returns>
        private ChequeInwardsModel ConvertToCheque(CHQ_Cheques_Master cheque, int SerialNo)
        {
            if (cheque == null)
                return new ChequeInwardsModel();
            StudentBusinessLogic bussiness = new StudentBusinessLogic();

            //STUD_Students_Master student = bussiness.GetAllStudents().Where(S => S.Student_ID == cheque.Student_ID).FirstOrDefault();
            //GEN_Sections_Lookup sec = bussiness.GetAllSections().Where(S => S.Section_Id == cheque.Section_ID).FirstOrDefault();

            ChequeInwardsModel cheq = new ChequeInwardsModel();
            cheq.SerialNo = SerialNo;
            cheq.Student_ID = cheque.Student_ID;
            cheq.Bank = cheque.Bank;
            cheq.ChequeNo = cheque.ChequeNo;
            cheq.Cheque_ID = cheque.Cheque_ID;
            cheq.ChqAmount = cheque.ChqAmount;
            cheq.ChqStatus_ID = cheque.ChqStatus_ID;
            cheq.EnteredBy = cheque.EnteredBy;
            cheq.EnteredOn = cheque.EnteredOn;
            cheq.InwardDate = cheque.InwardDate;
            cheq.IsActive = cheque.IsActive;
            cheq.Login_ID = cheque.Login_ID;
            cheq.Remarks = cheque.Remarks;
            cheq.Section_ID = cheque.Section_ID;
            cheq.RegNo = CurrentChequeInwardModel.RegNo;
            cheq.StudentName = CurrentChequeInwardModel.StudentName;
            cheq.Section = CurrentChequeInwardModel.Section;

            cheq.User = LoginBusinessLogic.GetUserByID(LoginBusinessLogic.GetUserIdByLoginId((decimal)cheque.Login_ID)).Username;
            return cheq;
        }

        private IEnumerable<T> FindVisualChildren<T>(System.Windows.DependencyObject depObj) where T : System.Windows.DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < System.Windows.Media.VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    System.Windows.DependencyObject child = System.Windows.Media.VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        #endregion
    }
}
