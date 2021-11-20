using System;
using System.Collections.Generic;
using System.Text;

namespace App26.Models
{
    public class ParDetails
    {
        public int SID;
        public string SN { get; set; }
        public int PID { get; set; }
        public int SportId { get; set; }
        public string PN { get; set; }
        public DateTime DI { get; set; }
        public DateTime DatumNaParDate { get; set; }
        public string DisplayDI { get; set; }


        public int S { get; set; }
        public string PK { get; set; }
        public string LN { get; set; }
        public int TF { get; set; }
        public int BT { get; set; }
        public int BTDetails { get; set; }
        public int IPID { get; set; }
        public int TipoviCounter { get; set; }
        public List<TipoviGroups> TGroups { get; set; }
    }
}
