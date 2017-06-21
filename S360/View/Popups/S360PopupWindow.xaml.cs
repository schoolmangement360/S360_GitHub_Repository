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

namespace S360.View.Popups
{
    /// <summary>
    /// Interaction logic for S360PopupWindow.xaml
    /// </summary>
    public partial class S360PopupWindow : Window
    {
        public S360PopupWindow(string Title)
        {
            InitializeComponent();
            this.Title = Title;
        }
    }
}
