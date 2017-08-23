using S360BusinessLogic;
using S360Exceptions;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace S360
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer t;
        DateTime start;

        public MainWindow()
        {
            InitializeComponent();
            this.CreateMenuDynamicaly();
            this.ShowTime();
        }

        private void ShowTime()
        {
            t = new DispatcherTimer(new TimeSpan(0, 0, 0, 1, 0), DispatcherPriority.Background,
               t_Tick, Dispatcher.CurrentDispatcher); t.IsEnabled = true;
            start = DateTime.Now;
        }

        private void t_Tick(object sender, EventArgs e)
        {
            try
            {
                TimerDisplay.Text = Convert.ToString(DateTime.Now);
            }
            catch (Exception ex)
            {
                throw new S360Exception(ex.Message, ex.InnerException);
            }
        }

        private void CreateMenuDynamicaly()
        {
            try
            {
                Style Menustyle = this.FindResource("MLB_MenuItem") as Style;
                Style SubMenustyle = this.FindResource("MLB_SubMenuItem") as Style;
                Style Separatorstyle = this.FindResource("CustomSeparatorStyle") as Style;
                Separator separator;

                #region MainMenu - File

                MenuItem miFiles = new MenuItem();
                miFiles.Style = Menustyle;
                miFiles.Header = "File";
                miFiles.Height = 45;
                miFiles.FontSize = 20;
                miFiles.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                miFiles.VerticalContentAlignment = System.Windows.VerticalAlignment.Center;
                this.MenuContainer.Items.Add(miFiles);

                #region SubMenu - File

                MenuItem smiUserSettings = new MenuItem();
                smiUserSettings.Style = SubMenustyle;
                smiUserSettings.Header = "User Settings";
                smiUserSettings.Height = 45;
                smiUserSettings.Tag = Page.AddNewStudent;
                smiUserSettings.Click += MenuItem_Click;
                miFiles.Items.Add(smiUserSettings);

                MenuItem smiChangePassword = new MenuItem();
                smiChangePassword.Style = SubMenustyle;
                smiChangePassword.Header = "Change Password";
                smiChangePassword.Height = 45;
                smiChangePassword.Tag = Page.AllotDivition;
                smiChangePassword.Click += MenuItem_Click;
                miFiles.Items.Add(smiChangePassword);

                MenuItem smiUserLog = new MenuItem();
                smiUserLog.Style = SubMenustyle;
                smiUserLog.Header = "User Log";
                smiUserLog.Height = 45;
                smiUserLog.Tag = Page.TCStudent;
                smiUserLog.Click += MenuItem_Click;
                miFiles.Items.Add(smiUserLog);

                //// Add Separator
                separator = new Separator();
                separator.Style = Separatorstyle;
                miFiles.Items.Add(separator);

                MenuItem smiResetDateChecking = new MenuItem();
                smiResetDateChecking.Style = SubMenustyle;
                smiResetDateChecking.Header = "Reset Date Checking";
                smiResetDateChecking.Height = 45;
                miFiles.Items.Add(smiResetDateChecking);

                //// Add Separator
                separator = new Separator();
                separator.Style = Separatorstyle;
                miFiles.Items.Add(separator);

                MenuItem smiSettings = new MenuItem();
                smiSettings.Style = SubMenustyle;
                smiSettings.Header = "Settings";
                smiSettings.Height = 45;
                miFiles.Items.Add(smiSettings);

                //// Add Separator
                separator = new Separator();
                separator.Style = Separatorstyle;
                miFiles.Items.Add(separator);

                #region SubMenu - Settings

                MenuItem smiEditAppSettings = new MenuItem();
                smiEditAppSettings.Style = SubMenustyle;
                smiEditAppSettings.Header = "Edit Application Settings";
                smiEditAppSettings.Height = 45;
                smiSettings.Items.Add(smiEditAppSettings);

                MenuItem smiEditModuleSettings = new MenuItem();
                smiEditModuleSettings.Style = SubMenustyle;
                smiEditModuleSettings.Header = "Edit Module Settings";
                smiEditModuleSettings.Height = 45;
                smiSettings.Items.Add(smiEditModuleSettings);

                MenuItem smiEditFeaturesSettings = new MenuItem();
                smiEditFeaturesSettings.Style = SubMenustyle;
                smiEditFeaturesSettings.Header = "Edit Features Settings";
                smiEditFeaturesSettings.Height = 45;
                smiSettings.Items.Add(smiEditFeaturesSettings);

                MenuItem smiEditResultSettings = new MenuItem();
                smiEditResultSettings.Style = SubMenustyle;
                smiEditResultSettings.Header = "Edit Result Settings";
                smiEditResultSettings.Height = 45;
                smiSettings.Items.Add(smiEditResultSettings);

                //// Add Separator
                separator = new Separator();
                separator.Style = Separatorstyle;
                smiSettings.Items.Add(separator);

                MenuItem smiEditPrintSettings = new MenuItem();
                smiEditPrintSettings.Style = SubMenustyle;
                smiEditPrintSettings.Header = "Edit Print Settings";
                smiEditPrintSettings.Height = 45;
                smiSettings.Items.Add(smiEditPrintSettings);

                //// Add Separator
                separator = new Separator();
                separator.Style = Separatorstyle;
                smiSettings.Items.Add(separator);

                MenuItem smiEditLocalSettings = new MenuItem();
                smiEditLocalSettings.Style = SubMenustyle;
                smiEditLocalSettings.Header = "Edit Local Settings";
                smiEditLocalSettings.Height = 45;
                smiSettings.Items.Add(smiEditLocalSettings);

                MenuItem smiEditAllSettings = new MenuItem();
                smiEditAllSettings.Style = SubMenustyle;
                smiEditAllSettings.Header = "Edit All Settings";
                smiEditAllSettings.Height = 45;
                smiSettings.Items.Add(smiEditAllSettings);

                #endregion

                MenuItem smiBackUpData = new MenuItem();
                smiBackUpData.Style = SubMenustyle;
                smiBackUpData.Header = "BackUp Data";
                smiBackUpData.Height = 45;
                miFiles.Items.Add(smiBackUpData);

                MenuItem smiSync = new MenuItem();
                smiSync.Style = SubMenustyle;
                smiSync.Header = "Sync";
                smiSync.Height = 45;
                miFiles.Items.Add(smiSync);

                MenuItem smiUploadLastBackUp = new MenuItem();
                smiUploadLastBackUp.Style = SubMenustyle;
                smiUploadLastBackUp.Header = "Upload Last BackUp";
                smiUploadLastBackUp.Height = 45;
                miFiles.Items.Add(smiUploadLastBackUp);

                //// Add Separator
                separator = new Separator();
                separator.Style = Separatorstyle;
                miFiles.Items.Add(separator);

                MenuItem smiDownloadUpdatePackage = new MenuItem();
                smiDownloadUpdatePackage.Style = SubMenustyle;
                smiDownloadUpdatePackage.Header = "Download Update Package";
                smiDownloadUpdatePackage.Height = 45;
                miFiles.Items.Add(smiDownloadUpdatePackage);

                MenuItem smiDownloadBranchPackage = new MenuItem();
                smiDownloadBranchPackage.Style = SubMenustyle;
                smiDownloadBranchPackage.Header = "Download Branch Package";
                smiDownloadBranchPackage.Height = 45;
                miFiles.Items.Add(smiDownloadBranchPackage);

                MenuItem smiFreeUpdatorUpdate = new MenuItem();
                smiFreeUpdatorUpdate.Style = SubMenustyle;
                smiFreeUpdatorUpdate.Header = "Free Updater Package";
                smiFreeUpdatorUpdate.Height = 45;
                miFiles.Items.Add(smiFreeUpdatorUpdate);

                //// Add Separator
                separator = new Separator();
                separator.Style = Separatorstyle;
                miFiles.Items.Add(separator);

                MenuItem smiQuit = new MenuItem();
                smiQuit.Style = SubMenustyle;
                smiQuit.Header = "Quit";
                smiQuit.Height = 45;
                miFiles.Items.Add(smiQuit);

                #endregion

                #endregion

                #region MainMenu - Masters

                MenuItem miMasters = new MenuItem();
                miMasters.Style = Menustyle;
                miMasters.Header = "Masters";
                miMasters.Height = 45;
                miMasters.FontSize = 20;
                miMasters.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                miMasters.VerticalContentAlignment = System.Windows.VerticalAlignment.Center;
                this.MenuContainer.Items.Add(miMasters);

                #region SubMenu - Masters

                MenuItem smiNewFeeItem = new MenuItem();
                smiNewFeeItem.Style = SubMenustyle;
                smiNewFeeItem.Header = "New Fee Item";
                smiNewFeeItem.Height = 45;
                miMasters.Items.Add(smiNewFeeItem);

                MenuItem smiListFeeItems = new MenuItem();
                smiListFeeItems.Style = SubMenustyle;
                smiListFeeItems.Header = "List Fee items";
                smiListFeeItems.Height = 45;
                miMasters.Items.Add(smiListFeeItems);

                //// Add Separator
                separator = new Separator();
                separator.Style = Separatorstyle;
                miMasters.Items.Add(separator);

                MenuItem smiEditMarkMasters = new MenuItem();
                smiEditMarkMasters.Style = SubMenustyle;
                smiEditMarkMasters.Header = "Edit Mark Master";
                smiEditMarkMasters.Height = 45;
                miMasters.Items.Add(smiEditMarkMasters);

                //// Add Separator
                separator = new Separator();
                separator.Style = Separatorstyle;
                miMasters.Items.Add(separator);

                MenuItem smiReport = new MenuItem();
                smiReport.Style = SubMenustyle;
                smiReport.Header = "Report";
                smiReport.Height = 45;
                miMasters.Items.Add(smiReport);

                //// Add Separator
                separator = new Separator();
                separator.Style = Separatorstyle;
                miMasters.Items.Add(separator);

                MenuItem smiView = new MenuItem();
                smiView.Style = SubMenustyle;
                smiView.Header = "View";
                smiView.Height = 45;
                miMasters.Items.Add(smiView);

                #endregion

                #endregion

                #region MainMenu - Cheques

                MenuItem miCheques = new MenuItem();
                miCheques.Style = Menustyle;
                miCheques.Header = "Cheques";
                miCheques.Height = 45;
                miCheques.FontSize = 20;
                miCheques.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                miCheques.VerticalContentAlignment = System.Windows.VerticalAlignment.Center;
                this.MenuContainer.Items.Add(miCheques);

                #region SubMenu - Cheques

                MenuItem smiChequeInward = new MenuItem();
                smiChequeInward.Style = SubMenustyle;
                smiChequeInward.Header = "Cheque Inward";
                smiChequeInward.Height = 45;
                smiChequeInward.Tag = Page.ChequeInward;
                smiChequeInward.Click += MenuItem_Click;
                miCheques.Items.Add(smiChequeInward);

                MenuItem smiEditCheque = new MenuItem();
                smiEditCheque.Style = SubMenustyle;
                smiEditCheque.Header = "Edit Cheque";
                smiEditCheque.Height = 45;
                smiEditCheque.Tag = Page.EditCheque;
                smiEditCheque.Click += MenuItem_Click;
                miCheques.Items.Add(smiEditCheque);

                MenuItem smiCancelCheque = new MenuItem();
                smiCancelCheque.Style = SubMenustyle;
                smiCancelCheque.Header = "Cancel Cheque";
                smiCancelCheque.Height = 45;
                smiCancelCheque.Tag = Page.CancelCheque;
                smiCancelCheque.Click += MenuItem_Click;
                miCheques.Items.Add(smiCancelCheque);

                //// Add Separator
                separator = new Separator();
                separator.Style = Separatorstyle;
                miCheques.Items.Add(separator);

                MenuItem smiChequeDeposits = new MenuItem();
                smiChequeDeposits.Style = SubMenustyle;
                smiChequeDeposits.Header = "Cheque Deposits";
                smiChequeDeposits.Height = 45;
                miCheques.Items.Add(smiChequeDeposits);

                MenuItem smiChequeDepositsStatement = new MenuItem();
                smiChequeDepositsStatement.Style = SubMenustyle;
                smiChequeDepositsStatement.Header = "Cheque Deposits Statement";
                smiChequeDepositsStatement.Height = 45;
                miCheques.Items.Add(smiChequeDepositsStatement);

                //// Add Separator
                separator = new Separator();
                separator.Style = Separatorstyle;
                miCheques.Items.Add(separator);

                MenuItem smiChequeClearing = new MenuItem();
                smiChequeClearing.Style = SubMenustyle;
                smiChequeClearing.Header = "Cheque Clearing";
                smiChequeClearing.Height = 45;
                miCheques.Items.Add(smiChequeClearing);

                MenuItem smiChequeReturns = new MenuItem();
                smiChequeReturns.Style = SubMenustyle;
                smiChequeReturns.Header = "Cheque Returns";
                smiChequeReturns.Height = 45;
                miCheques.Items.Add(smiChequeReturns);

                //// Add Separator
                separator = new Separator();
                separator.Style = Separatorstyle;
                miCheques.Items.Add(separator);

                MenuItem smiBrowseCheque = new MenuItem();
                smiBrowseCheque.Style = SubMenustyle;
                smiBrowseCheque.Header = "Browse Cheques";
                smiBrowseCheque.Height = 45;
                miCheques.Items.Add(smiBrowseCheque);

                MenuItem smiFindCheque = new MenuItem();
                smiFindCheque.Style = SubMenustyle;
                smiFindCheque.Header = "Find Cheques";
                smiFindCheque.Height = 45;
                miCheques.Items.Add(smiFindCheque);

                //// Add Separator
                separator = new Separator();
                separator.Style = Separatorstyle;
                miCheques.Items.Add(separator);

                MenuItem smiChequeReports = new MenuItem();
                smiChequeReports.Style = SubMenustyle;
                smiChequeReports.Header = "Cheque Report";
                smiChequeReports.Height = 45;
                miCheques.Items.Add(smiChequeReports);

                #endregion

                #endregion

                #region MainMenu - Receipts

                MenuItem miReceipts = new MenuItem();
                miReceipts.Style = Menustyle;
                miReceipts.Header = "Receipts";
                miReceipts.Height = 45;
                miReceipts.FontSize = 20;
                miReceipts.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                miReceipts.VerticalContentAlignment = System.Windows.VerticalAlignment.Center;
                this.MenuContainer.Items.Add(miReceipts);

                #region SubMenu - Receipts

                MenuItem smiReceiptsFormCash = new MenuItem();
                smiReceiptsFormCash.Style = SubMenustyle;
                smiReceiptsFormCash.Header = "Receipt Form Cash";
                smiReceiptsFormCash.Height = 45;
                miReceipts.Items.Add(smiReceiptsFormCash);

                MenuItem smiReceiptsFormCheque = new MenuItem();
                smiReceiptsFormCheque.Style = SubMenustyle;
                smiReceiptsFormCheque.Header = "Receipt Form Cheque";
                smiReceiptsFormCheque.Height = 45;
                miReceipts.Items.Add(smiReceiptsFormCheque);

                //// Add Separator
                separator = new Separator();
                separator.Style = Separatorstyle;
                miReceipts.Items.Add(separator);

                MenuItem smiReceiptsFormPOS = new MenuItem();
                smiReceiptsFormPOS.Style = SubMenustyle;
                smiReceiptsFormPOS.Header = "Receipt Form (POS Visual)";
                smiReceiptsFormPOS.Height = 45;
                miReceipts.Items.Add(smiReceiptsFormPOS);

                //// Add Separator
                separator = new Separator();
                separator.Style = Separatorstyle;
                miReceipts.Items.Add(separator);

                MenuItem smiDuplicateReceipts = new MenuItem();
                smiDuplicateReceipts.Style = SubMenustyle;
                smiDuplicateReceipts.Header = "Duplicate Receipts";
                smiDuplicateReceipts.Height = 45;
                miReceipts.Items.Add(smiDuplicateReceipts);

                //// Add Separator
                separator = new Separator();
                separator.Style = Separatorstyle;
                miReceipts.Items.Add(separator);

                MenuItem smiCondensedReceiptsON = new MenuItem();
                smiCondensedReceiptsON.Style = SubMenustyle;
                smiCondensedReceiptsON.Header = "Condensed Receipts ON";
                smiCondensedReceiptsON.Height = 45;
                miReceipts.Items.Add(smiCondensedReceiptsON);

                MenuItem smiCondensedReceiptsOFF = new MenuItem();
                smiCondensedReceiptsOFF.Style = SubMenustyle;
                smiCondensedReceiptsOFF.Header = "Condensed Receipts OFF";
                smiCondensedReceiptsOFF.Height = 45;
                miReceipts.Items.Add(smiCondensedReceiptsOFF);

                //// Add Separator
                separator = new Separator();
                separator.Style = Separatorstyle;
                miReceipts.Items.Add(separator);

                MenuItem smiReceitsCancelation = new MenuItem();
                smiReceitsCancelation.Style = SubMenustyle;
                smiReceitsCancelation.Header = "Receits Cancelation";
                smiReceitsCancelation.Height = 45;
                miReceipts.Items.Add(smiReceitsCancelation);

                //// Add Separator
                separator = new Separator();
                separator.Style = Separatorstyle;
                miReceipts.Items.Add(separator);

                MenuItem smiReceitsReports = new MenuItem();
                smiReceitsReports.Style = SubMenustyle;
                smiReceitsReports.Header = "Reciets Report";
                smiReceitsReports.Height = 45;
                miReceipts.Items.Add(smiReceitsReports);

                #endregion

                #endregion

                #region MainMenu - Students

                MenuItem miStudents = new MenuItem();
                miStudents.Style = Menustyle;
                miStudents.Header = "Students";
                miStudents.Height = 45;
                miStudents.FontSize = 20;
                miStudents.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                miStudents.VerticalContentAlignment = System.Windows.VerticalAlignment.Center;
                this.MenuContainer.Items.Add(miStudents);

                #region [ SubMenu - Students ]

                //New Student
                MenuItem miNewStudent = new MenuItem();
                miNewStudent.Style = SubMenustyle;
                miNewStudent.Header = "New Student";
                miNewStudent.Height = 45;
                miNewStudent.Tag = Page.AddNewStudent;
                miNewStudent.Click += MenuItem_Click;
                miStudents.Items.Add(miNewStudent);

                //Separator
                separator = new Separator();
                separator.Style = Separatorstyle;
                miStudents.Items.Add(separator);

                //Individual Student Report
                MenuItem miIndividualStudentReport = new MenuItem();
                miIndividualStudentReport.Style = SubMenustyle;
                miIndividualStudentReport.Header = "Individual Student Report";
                miIndividualStudentReport.Height = 45;
                miIndividualStudentReport.Tag = Page.IndividualStudetReport;
                miIndividualStudentReport.Click += MenuItem_Click;
                miStudents.Items.Add(miIndividualStudentReport);

                //Separator
                separator = new Separator();
                separator.Style = Separatorstyle;
                miStudents.Items.Add(separator);

                //View Student Details
                MenuItem miViewStudentDetails = new MenuItem();
                miViewStudentDetails.Style = SubMenustyle;
                miViewStudentDetails.Header = "View Student Details";
                miViewStudentDetails.Height = 45;
                miViewStudentDetails.Tag = Page.ViewStudentDetails;
                miViewStudentDetails.Click += MenuItem_Click;
                miStudents.Items.Add(miViewStudentDetails);

                //Edit Student Details
                MenuItem miEditStudentDetails = new MenuItem();
                miEditStudentDetails.Style = SubMenustyle;
                miEditStudentDetails.Header = "Edit Student Details";
                miEditStudentDetails.Height = 45;
                miEditStudentDetails.Tag = Page.EditStudentDetails;
                miEditStudentDetails.Click += MenuItem_Click;
                miStudents.Items.Add(miEditStudentDetails);

                //Student Data
                MenuItem miStudentData = new MenuItem();
                miStudentData.Style = SubMenustyle;
                miStudentData.Header = "Student Data";
                miStudentData.Height = 45;
                miStudentData.Tag = Page.StudentData;
                miStudents.Items.Add(miStudentData);

                #region [ Student Data - Sub Items ]

                //KG Section
                MenuItem miKGSection = new MenuItem();
                miKGSection.Style = SubMenustyle;
                miKGSection.Header = "KG Section";
                miKGSection.Height = 45;
                miKGSection.Tag = Page.StudentKGSection;
                miKGSection.Click += MenuItem_Click;
                miStudentData.Items.Add(miKGSection);

                //Primary Section
                MenuItem miPrimarySection = new MenuItem();
                miPrimarySection.Style = SubMenustyle;
                miPrimarySection.Header = "Primary Section";
                miPrimarySection.Height = 45;
                miPrimarySection.Tag = Page.StudentPrimarySection;
                miPrimarySection.Click += MenuItem_Click;
                miStudentData.Items.Add(miPrimarySection);

                //Secondary Section
                MenuItem miSecondarySection = new MenuItem();
                miSecondarySection.Style = SubMenustyle;
                miSecondarySection.Header = "Secondary Section";
                miSecondarySection.Height = 45;
                miSecondarySection.Tag = Page.StudentSecondarySection;
                miSecondarySection.Click += MenuItem_Click;
                miStudentData.Items.Add(miSecondarySection);

                //Separator
                separator = new Separator();
                separator.Style = Separatorstyle;
                miStudentData.Items.Add(separator);

                //Others
                MenuItem miOthers = new MenuItem();
                miOthers.Style = SubMenustyle;
                miOthers.Header = "Others";
                miOthers.Height = 45;
                miOthers.Tag = Page.StudentOtherSections;
                miOthers.Click += MenuItem_Click;
                miStudentData.Items.Add(miOthers);

                #endregion

                //Address Data
                MenuItem miAddressData = new MenuItem();
                miAddressData.Style = SubMenustyle;
                miAddressData.Header = "Address Data";
                miAddressData.Height = 45;
                miAddressData.Tag = Page.AddressData;
                miStudents.Items.Add(miAddressData);

                #region [ Address Data - Sub Items ]

                //KG Section
                MenuItem miKGAddress = new MenuItem();
                miKGAddress.Style = SubMenustyle;
                miKGAddress.Header = "KG Section";
                miKGAddress.Height = 45;
                miKGAddress.Tag = Page.AddressKGSection;
                miKGAddress.Click += MenuItem_Click;
                miAddressData.Items.Add(miKGAddress);

                //Primary Section
                MenuItem miPrimaryAddress = new MenuItem();
                miPrimaryAddress.Style = SubMenustyle;
                miPrimaryAddress.Header = "Primary Section";
                miPrimaryAddress.Height = 45;
                miPrimaryAddress.Tag = Page.AddressPrimarySection;
                miPrimaryAddress.Click += MenuItem_Click;
                miAddressData.Items.Add(miPrimaryAddress);

                //Secondary Section
                MenuItem miSecondaryAddress = new MenuItem();
                miSecondaryAddress.Style = SubMenustyle;
                miSecondaryAddress.Header = "Secondary Section";
                miSecondaryAddress.Height = 45;
                miSecondaryAddress.Tag = Page.AddressSecondarySection;
                miSecondaryAddress.Click += MenuItem_Click;
                miAddressData.Items.Add(miSecondaryAddress);

                //Separator
                separator = new Separator();
                separator.Style = Separatorstyle;
                miAddressData.Items.Add(separator);

                //Others (New)
                MenuItem miOthersAddress = new MenuItem();
                miOthersAddress.Style = SubMenustyle;
                miOthersAddress.Header = "Others (New)";
                miOthersAddress.Height = 45;
                miOthersAddress.Tag = Page.AddressOtherSections;
                miOthersAddress.Click += MenuItem_Click;
                miAddressData.Items.Add(miOthersAddress);

                #endregion

                //Separator
                separator = new Separator();
                separator.Style = Separatorstyle;
                miStudents.Items.Add(separator);

                //Promotions
                MenuItem miPromotions = new MenuItem();
                miPromotions.Style = SubMenustyle;
                miPromotions.Header = "Promotions";
                miPromotions.Height = 45;
                miPromotions.Tag = Page.StudentPromotion;
                miPromotions.Click += MenuItem_Click;
                miStudents.Items.Add(miPromotions);

                //Allot New GRegno
                MenuItem miAllotNewGRegno = new MenuItem();
                miAllotNewGRegno.Style = SubMenustyle;
                miAllotNewGRegno.Header = "Allot New G.Reg.No";
                miAllotNewGRegno.Height = 45;
                miAllotNewGRegno.Tag = Page.AllotNewGRno;
                miAllotNewGRegno.Click += MenuItem_Click;
                miStudents.Items.Add(miAllotNewGRegno);

                //Allot Division
                MenuItem miAllotDivision = new MenuItem();
                miAllotDivision.Style = SubMenustyle;
                miAllotDivision.Header = "Allot Division";
                miAllotDivision.Height = 45;
                miAllotDivision.Tag = Page.AllotDivition;
                miAllotDivision.Click += MenuItem_Click;
                miStudents.Items.Add(miAllotDivision);

                //TC Students
                MenuItem miTCStudents = new MenuItem();
                miTCStudents.Style = SubMenustyle;
                miTCStudents.Header = "TC Students";
                miTCStudents.Height = 45;
                miTCStudents.Tag = Page.TCStudent;
                miTCStudents.Click += MenuItem_Click;
                miStudents.Items.Add(miTCStudents);

                //Separator
                separator = new Separator();
                separator.Style = Separatorstyle;
                miStudents.Items.Add(separator);

                //Class Report
                MenuItem miClassReport = new MenuItem();
                miClassReport.Style = SubMenustyle;
                miClassReport.Header = "Class Report";
                miClassReport.Height = 45;
                miClassReport.Tag = Page.StudentClassreport;
                miClassReport.Click += MenuItem_Click;
                miStudents.Items.Add(miClassReport);

                //Fees Report
                MenuItem miFeesReport = new MenuItem();
                miFeesReport.Style = SubMenustyle;
                miFeesReport.Header = "Fees Report";
                miFeesReport.Height = 45;
                miFeesReport.Tag = Page.StudentFeeReport;
                miFeesReport.Click += MenuItem_Click;
                miStudents.Items.Add(miFeesReport);

                #endregion

                #endregion

                #region MainMenu - Results

                MenuItem miResults = new MenuItem();
                miResults.Style = Menustyle;
                miResults.Header = "Results";
                miResults.Height = 45;
                miResults.FontSize = 20;
                miResults.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                miResults.VerticalContentAlignment = System.Windows.VerticalAlignment.Center;
                this.MenuContainer.Items.Add(miResults);

                #endregion

                #region MainMenu - Stock Inventory

                MenuItem miStockInventory = new MenuItem();
                miStockInventory.Style = Menustyle;
                miStockInventory.Header = "Stock Inventory";
                miStockInventory.Height = 45;
                miStockInventory.FontSize = 20;
                miStockInventory.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                miStockInventory.VerticalContentAlignment = System.Windows.VerticalAlignment.Center;
                this.MenuContainer.Items.Add(miStockInventory);

                #endregion

                #region MainMenu - Petty Cash

                MenuItem miPettyCash = new MenuItem();
                miPettyCash.Style = Menustyle;
                miPettyCash.Header = "Petty Cash";
                miPettyCash.Height = 45;
                miPettyCash.FontSize = 20;
                miPettyCash.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                miPettyCash.VerticalContentAlignment = System.Windows.VerticalAlignment.Center;
                this.MenuContainer.Items.Add(miPettyCash);

                #endregion

                #region MainMenu - Version

                MenuItem miVersion = new MenuItem();
                miVersion.Style = Menustyle;
                miVersion.Header = "Version";
                miVersion.Height = 45;
                miVersion.FontSize = 20;
                miVersion.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                miVersion.VerticalContentAlignment = System.Windows.VerticalAlignment.Center;
                this.MenuContainer.Items.Add(miVersion);

                #endregion
            }
            catch (Exception ex)
            {
                throw new S360Exception(ex.Message, ex.InnerException);
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.MDIContainer.Children.Clear();
            MenuItem menuItem = sender as MenuItem;
            if (menuItem != null)
            {
                this.MDIContainer.Children.Add(ShowUserControl.ShowUserControlAndSetVM((Page)menuItem.Tag) as UserControl);
            }
        }

        private void PART_TITLEBAR_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void PART_CLOSE_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PART_MAXIMIZE_RESTORE_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == System.Windows.WindowState.Normal)
            {
                this.WindowState = System.Windows.WindowState.Maximized;
            }
            else
            {
                this.WindowState = System.Windows.WindowState.Normal;
            }
        }

        private void PART_MINIMIZE_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }
    }
}
