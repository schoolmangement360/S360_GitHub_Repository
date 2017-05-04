using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace S360Controlls.BasicControls
{
    public class S360RichTextBox : RichTextBox
    {
        /// <summary>
        /// Overridden method to set background color as Aqua
        /// when mouse focus on control
        /// </summary>
        /// <param name="e"></param>
        protected override void OnGotFocus(RoutedEventArgs e)
        {
            base.OnGotFocus(e);
            this.Background = Brushes.Aqua;
        }
        /// <summary>
        /// Overridden method to set background color as Aqua
        /// when keyboard focus on control
        /// </summary>
        /// <param name="e"></param>
        protected override void OnGotKeyboardFocus(KeyboardFocusChangedEventArgs e)
        {
            base.OnGotKeyboardFocus(e);
            this.Background = Brushes.Aqua;
        }
        /// <summary>
        /// Overridden method to set background color as White
        /// when mouse focus lost from control
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLostFocus(RoutedEventArgs e)
        {
            base.OnLostFocus(e);
            this.Background = Brushes.White;
        }
        /// <summary>
        /// Overridden method to set background color as White
        /// when keyboard focus lost from control
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLostKeyboardFocus(KeyboardFocusChangedEventArgs e)
        {
            base.OnLostKeyboardFocus(e);
            this.Background = Brushes.White;
        }

        /// <summary>
        /// property For ControlValidation
        /// </summary>
        public bool ControlValidation { get; set; }

        /// <summary>
        /// property For ControlValidationMessage
        /// </summary>
        public string ControlValidationMessage { get; set; }
    }
}
