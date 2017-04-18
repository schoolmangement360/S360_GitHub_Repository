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
using System.Windows.Navigation;
using System.Windows.Shapes;
using S360BusinessLogic;
using S360Logging;

namespace S360
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            StudentBusinessLogic test = new StudentBusinessLogic();
            var testing = test.FirstStudent();
            firstname.Text = testing.Name;
            FatherName.Text = testing.FatherName;
            RegNo.Text = testing.RegNo;
            S360Log.Instance.Trace("Tracing");
        }
    }
}
