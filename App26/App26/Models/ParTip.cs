using System;
using System.Collections.Generic;
using System.Text;

namespace App26.Models
{
    public class ParTip
    {
        public int ParID { get; set; }
        public int TipID { get; set; }
        public int IgraWebID { get; set; }
        public decimal Kvota { get; set; }
        public decimal Granica { get; set; }
        public bool ImaLimit { get; set; }
        public bool Single { get; set; }
        public long SingleLimit { get; set; }


        public int IgraOrder { get; set; }
        public int TipOrder { get; set; }

    }
}
