using S360Entity;
using System;

namespace S360Model
{
    public class ChequeInwardsModel : CHQ_Cheques_Master
    {
        public ChequeInwardsModel()
        {
            this.EnteredOn = System.DateTimeOffset.Now;
            this.InwardDate = System.DateTime.Today;
        }
        public int SerialNo { get; set; }
        public string StudentName { get; set; }
        public string RegNo { get; set; }
        public string Section { get; set; }
        public string User { get; set; }
    }
}
