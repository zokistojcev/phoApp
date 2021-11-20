using System;
using System.Collections.Generic;
using System.Text;

namespace App26.Models
{
    public class Tip
    {
        public int TipId { get; set; }
        public int OrderNumber { get; set; }
        public int IgraWebId { get; set; }
        public string Naziv { get; set; }
        public bool IsLiveTip { get; set; }
    }
}
