using S360.View.Student;
using S360.ViewModel.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S360
{
    public static class ShowUserControl
    {
        public static object ShowUserControlAndSetVM(Page page)
        {
            switch (page)
            {
                //// File ///
                case Page.UserSettings:
                    break;
                case Page.ChangePassword:
                    break;
                case Page.UserLog:
                    break;
                case Page.ResetDateChecking:
                    break;
                case Page.EditAppSettings:
                    break;
                case Page.EditModuleSettings:
                    break;
                case Page.EditFeaturesSetting:
                    break;
                case Page.EditResultSettings:
                    break;
                case Page.EditPrintSettings:
                    break;
                case Page.EditLocalSttings:
                    break;
                case Page.EditAllSettings:
                    break;
                case Page.BackUpData:
                    break;
                case Page.Sync:
                    break;
                case Page.UploadLastBack:
                    break;
                case Page.DownloadUpdatePackage:
                    break;
                case Page.DownloadBranchPackage:
                    break;
                case Page.FeeUpdaterUpdate:

                //// Masters ///
                case Page.NewFeeItem:
                    break;
                case Page.ListFeeItems:
                    break;
                case Page.EditMasksMaster:
                    break;
                case Page.MastersReport:
                    break;
                case Page.MastersView:
                    break;

                //// Cheques ///
                case Page.ChequeInward:
                    break;
                case Page.EditCheque:
                    break;
                case Page.CancelCheque:
                    break;
                case Page.ChequeDeposits:
                    break;
                case Page.ChequeDepositeStatements:
                    break;
                case Page.CancelCQDepositeStatement:
                    break;
                case Page.ChequeClearing:
                    break;
                case Page.ChequeReturn:
                    break;
                case Page.BrowseCheque:
                    break;
                case Page.FindCheques:
                    break;
                case Page.ChequesReports:
                    break;

                //// Reciepts ///
                case Page.ReceiptFormCash:
                    break;
                case Page.ReceiptFormCheques:
                    break;
                case Page.ReceiptFormPOS:
                    break;
                case Page.DuplicateReciept:
                    break;
                case Page.CondensedRecieptON:
                    break;
                case Page.CondensedRecieptOFF:
                    break;
                case Page.RecieptCancellation:
                    break;
                case Page.RecieptReports:
                    break;

                //// Students ///
                case Page.AddNewStudent:
                    StudentViewModel StudentVM = new StudentViewModel();
                    StudentVM.SelectedSection = new S360Entity.GEN_Sections_Lookup() { Section_Id = 1, Name = "Primary Section", IsActive = true };
                    return new UC_AddStudentScreen();//.DataContext = findStudentVM;
                case Page.IndividualStudetReport:
                    //FindStudentViewModel findstudentVM = new FindStudentViewModel();
                    //findstudentVM.SelectedSection = new S360Entity.GEN_Sections_Lookup() { IsActive = true, Name = "Primary Section", Section_Id = 1 };
                    //UC_FindStudentScreen findStudent = new UC_FindStudentScreen();
                    //findStudent.DataContext = findstudentVM;
                    //return findStudent;
                    break;
                case Page.ViewStudentDetails:
                    break;
                case Page.EditStudentDetails:
                    break;
                case Page.StudentKGSection:
                    break;
                case Page.StudentPrimarySection:
                    break;
                case Page.StudentSecondarySection:
                    break;
                case Page.StudentOtherSections:
                    break;
                case Page.AddressKGSection:
                    break;
                case Page.AddressPrimarySection:
                    break;
                case Page.AddressSecondarySection:
                    break;
                case Page.AddressOtherSections:
                    break;
                case Page.StudentPromotion:
                    return new UC_PromotionScreen();
                case Page.AllotNewGRno:
                    break;
                case Page.AllotDivition:
                    return new UC_AllotDivisionScreen();
                case Page.TCStudent:
                    return new UC_StudentTCScreen();
                case Page.StudentClassreport:
                    break;
                case Page.StudentFeeReport:
                    break;

                default:
                    break;
            }

            return null;
        }
    }
}
