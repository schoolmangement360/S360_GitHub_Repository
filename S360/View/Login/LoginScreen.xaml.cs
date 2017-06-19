using S360BusinessLogic;
using S360Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace S360
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        #region Private Variables

        /// <summary>
        /// Login BusinessLogic Object Initialization
        /// </summary>
        private LoginBusinessLogic studentBusinessLogic;

        #endregion

        #region Constructor


        public LoginScreen()
        {
            InitializeComponent();
            studentBusinessLogic = new LoginBusinessLogic();
            studentBusinessLogic.ActivateApplication();
            txtUserName.Focus();
        }

        #endregion

        #region Public Properties



        #endregion

        #region Events

        private void PART_TITLEBAR_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            this.Login();
        }

        private void pswPassword_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                this.Login();
            }
        }

        private void txtUserName_TextChanged(object sender, RoutedEventArgs e)
        {
            txtMessageInfo.Text = string.Empty;
        }

        #endregion

        #region Private Functions

        private void Login()
        {
            LoginModel loginmodel = new LoginModel();
            loginmodel.Username = txtUserName.Text.ToUpper();
            loginmodel.Password = pswPassword.Password;

            LoginModel Result = studentBusinessLogic.LoginAccess(loginmodel);

            if (Result.IsLogin)
            {
                //S360Configuration.Instance.UserID = Result.UserID;
                //S360Configuration.Instance.AcademicYearStart = Properties.Settings.Default.AcademicYearStart;
                //S360Configuration.Instance.AcademicYearEnd = Properties.Settings.Default.AcademicYearEnd;
                S360Model.S360Configuration.Instance.UserID = Result.UserID;
                S360Model.S360Configuration.Instance.User = Result.Username;
                S360Model.S360Configuration.Instance.AcademicYearStart = Properties.Settings.Default.AcademicYearStart;
                S360Model.S360Configuration.Instance.AcademicYearEnd = Properties.Settings.Default.AcademicYearEnd;

                txtMessageInfo.Text = string.Empty;
                txtUserName.Clear();
                pswPassword.Clear();
                //S360Configuration.Instance.LoginID = Result.LoginID;
                S360Model.S360Configuration.Instance.LoginID = Result.LoginID;

                MainWindow mdiWindow = new MainWindow();
                mdiWindow.ShowDialog();
                txtUserName.Focus();
                studentBusinessLogic.MarkLogout(S360Model.S360Configuration.Instance.LoginID);
            }
            else
            {
                txtMessageInfo.Text = Result.Message;

                if (Result.Message == "Invalid User Name")
                {
                    txtUserName.Clear();
                    txtUserName.Focus();
                }
                else if (Result.Message == "Invalid Password")
                {
                    pswPassword.Clear();
                    pswPassword.Focus();
                }
                else
                {
                    txtUserName.Clear();
                    pswPassword.Clear();
                    txtUserName.Focus();
                }


            }
        }

        private void txtUserName_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                pswPassword.Focus();
            }
        }

        #endregion


    }
}
