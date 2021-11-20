using System;
using System.Collections.Generic;
using System.Text;

namespace App26.Models
{
    public partial class TipoviGrupi
    {
        public int Id { get; set; }
        public int? SportId { get; set; }
        public int? TipId { get; set; }
        public int? GrupaId { get; set; }
        public int? Tezina { get; set; }
        public bool? IsGranica { get; set; }
        public string SportCode { get; set; }
    }
}
