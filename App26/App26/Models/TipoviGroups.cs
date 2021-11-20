using System;
using System.Collections.Generic;
using System.Text;

namespace App26.Models
{
    public class TipoviGroups
    {
        public int IWID { get; set; }
        public int IWGID { get; set; }
        public string IN { get; set; }
        public int ON { get; set; }
        //private List<Tipovi> _t;
        private List<Tipovi> _t;
        public List<Tipovi> T
        {
            get
            {
                return _t;
            }
            set
            {
                foreach (var item in value)
                {
                    if (value.Count == 1)
                    {
                        item.PercentCell = "100%";
                    }
                    else if (value.Count == 2)
                    {
                        item.PercentCell = "49.8%";
                    }
                    else if (value.Count > 2)
                    {
                        item.PercentCell = "33%";
                    }
                }
                _t = value;
            }
        }
    }
}
