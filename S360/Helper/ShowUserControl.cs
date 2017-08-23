using S360.View.Cheque;
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
                    return new UC_ChequeInwardScreen();
                case Page.EditCheque:
                    return new UC_ChequeEditScreen();
                case Page.CancelCheque:
                    return new UC_ChequeCancellationScreen();
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
                    StudentDataViewModel studentDatakg = new StudentDataViewModel();
                    studentDatakg.SectionID = 0; //Section Id for KG section
                    studentDatakg.Title = "KG Section";
                    UC_StudentDataScreen ucStudentDataKG = new UC_StudentDataScreen();
                    ucStudentDataKG.DataContext = studentDatakg;
                    return ucStudentDataKG;
                case Page.StudentPrimarySection:
                    StudentDataViewModel studentDataP = new StudentDataViewModel();
                    studentDataP.SectionID = 1; //Section Id for Primary section
                    studentDataP.Title = "KG Section";
                    UC_StudentDataScreen ucStudentDataP = new UC_StudentDataScreen();
                    ucStudentDataP.DataContext = studentDataP;
                    return ucStudentDataP;
                case Page.StudentSecondarySection:
                    StudentDataViewModel studentDataS = new StudentDataViewModel();
                    studentDataS.SectionID = 2; //Section Id for Secondary section
                    studentDataS.Title = "KG Section";
                    UC_StudentDataScreen ucStudentDataS = new UC_StudentDataScreen();
                    ucStudentDataS.DataContext = studentDataS;
                    return ucStudentDataS;
                case Page.StudentOtherSections:
                    StudentDataViewModel studentDataO = new StudentDataViewModel();
                    studentDataO.SectionID = 3; //Section Id for Other sections
                    studentDataO.Title = "KG Section";
                    UC_StudentDataScreen ucStudentDataO = new UC_StudentDataScreen();
                    ucStudentDataO.DataContext = studentDataO;
                    return ucStudentDataO;
                case Page.AddressKGSection:
                    StudentDataViewModel addressDatakG = new StudentDataViewModel();
                    addressDatakG.SectionID = 0; //Section Id for KG section
                    addressDatakG.Title = "KG Section";
                    UC_AddressDataScreen ucaddresDataKG = new UC_AddressDataScreen();
                    ucaddresDataKG.DataContext = addressDatakG;
                    return ucaddresDataKG;
                case Page.AddressPrimarySection:
                    StudentDataViewModel addressDataP = new StudentDataViewModel();
                    addressDataP.SectionID = 1; //Section Id for Primary section
                    addressDataP.Title = "Primary Section";
                    UC_AddressDataScreen ucaddresDataP = new UC_AddressDataScreen();
                    ucaddresDataP.DataContext = addressDataP;
                    return ucaddresDataP;
                case Page.AddressSecondarySection:
                    StudentDataViewModel addressDataS = new StudentDataViewModel();
                    addressDataS.SectionID = 2; //Section Id for Secondary section
                    addressDataS.Title = "Secondary Section";
                    UC_AddressDataScreen ucaddresDataS = new UC_AddressDataScreen();
                    ucaddresDataS.DataContext = addressDataS;
                    return ucaddresDataS;
                case Page.AddressOtherSections:
                    StudentDataViewModel addressDataO = new StudentDataViewModel();
                    addressDataO.SectionID = 3; //Section Id for Other section
                    addressDataO.Title = "Other Section";
                    UC_AddressDataScreen ucaddresDataO = new UC_AddressDataScreen();
                    ucaddresDataO.DataContext = addressDataO;
                    return ucaddresDataO;
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
