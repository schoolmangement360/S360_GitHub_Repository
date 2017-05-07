using S360Controlls.BasicControls;
using S360Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace S360
{
    public static class ValidateControls
    {
        public static ControlValidationStatus ValidateAllControls(object ValidationWindow)
        {
            dynamic userControl = ValidationWindow as UserControl;
            ControlValidationStatus ValidationStatus = new ControlValidationStatus();

            if (userControl == null)
            {
                userControl = ValidationWindow as Window;
            }

            foreach (S360TextBox tb in FindVisualChildren<S360TextBox>(userControl))
            {
                if (tb.ControlValidation && tb.Text == string.Empty)
                {
                    tb.Focus();
                    tb.Background = System.Windows.Media.Brushes.IndianRed;
                    ValidationStatus.isValid = false;
                    ValidationStatus.TextBoxControl = tb;
                    ValidationStatus.ValidationMessage = tb.ControlValidationMessage;
                    return ValidationStatus;
                }
            }

            foreach (S360ComboBox cb in FindVisualChildren<S360ComboBox>(userControl))
            {
                if (cb.ControlValidation && cb.SelectedIndex == -1)
                {
                    cb.Focus();
                    cb.Background = System.Windows.Media.Brushes.IndianRed;
                    ValidationStatus.isValid = false;
                    ValidationStatus.ComboBoxControl = cb;
                    ValidationStatus.ValidationMessage = cb.ControlValidationMessage;
                    return ValidationStatus;
                }
            }

            ValidationStatus.isValid = true;
            return ValidationStatus;
        }

        public static bool ClearAllControls(object ValidationWindow)
        {
            dynamic userControl = ValidationWindow as UserControl;
            ControlValidationStatus ValidationStatus = new ControlValidationStatus();

            if (userControl == null)
            {
                userControl = ValidationWindow as Window;
            }

            foreach (S360TextBox tb in FindVisualChildren<S360TextBox>(userControl))
            {
                tb.Clear();
            }

            foreach (S360ComboBox cb in FindVisualChildren<S360ComboBox>(userControl))
            {
                cb.SelectedIndex = -1;
            }

            foreach (S360RichTextBox rtb in FindVisualChildren<S360RichTextBox>(userControl))
            {
                rtb.AppendText(string.Empty);
            }

            return true;
        }

        private static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < System.Windows.Media.VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = System.Windows.Media.VisualTreeHelper.GetChild(depObj, i);
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
    }
}
