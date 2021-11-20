using System;
using System.Collections.Generic;
using System.Text;

namespace App26.Models
{
    public class ParSync
    {
        public int ParID { get; set; }
        public int DomaID { get; set; }
        public int GostiID { get; set; }
        public DateTime DatumNaIgranje { get; set; }
        public int Sifra { get; set; }
        public int LigaID { get; set; }
        public int SportID { get; set; }
        public string LigaNaziv { get; set; }
        public string ParNaziv { get; set; }
        public string ParKomentar { get; set; }
        public DateTime DatumNaParDate { get; set; }
        public DateTime ParDoDatum { get; set; }
        public bool isTradingOpen { get; set; }
        public int Status { get; set; }
        public bool isMin { get; set; }
        public bool ImaLigaKomentar { get; set; }
        public int BrojNaTipovi { get; set; }
        public string Uver { get; set; }

        public List<ParTip> ParTipovi { get; set; }


        public int TezMaster { get; set; }
        public int TezinskiFaktor { get; set; }
        public int TezGrupa { get; set; }
        public int TezLiga { get; set; }

        public string LigaNazivWeb { get; set; }
        public string LigaNaziv2Chars { get; set; }


        public string NazivGrupa { get; set; }

    }
}
