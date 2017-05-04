using S360Controlls.BasicControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S360Model
{
    public class ControlValidationStatus
    {
        public S360TextBox TextBoxControl { get; set; }
        public S360ComboBox ComboBoxControl { get; set; }
        public S360RichTextBox RichTextBoxControl { get; set; }
        public bool isValid { get; set; }
        public string ValidationMessage { get; set; }
    }
}
