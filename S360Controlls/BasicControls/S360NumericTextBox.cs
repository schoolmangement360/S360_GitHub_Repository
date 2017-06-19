using System.Windows.Input;
using System.Windows.Media;

namespace S360Controlls.BasicControls
{
    public class S360NumericTextBox : S360TextBox
    {
        protected override void OnPreviewTextInput(TextCompositionEventArgs e)
        {
            if (!IsTextAllowed(e.Text))
                e.Handled = true;
            base.OnPreviewTextInput(e);
        }

        public bool IsTextAllowed(string text)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("[^0-9.-]+"); //regex that matches disallowed text
            return !regex.IsMatch(text);
        }
    }
}
