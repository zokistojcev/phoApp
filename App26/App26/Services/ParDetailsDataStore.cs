using App26.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MoreLinq;

namespace App26.Services
{
    public class ParDetailsDataStore : IDataMatchDetails<ParDetails>
    {
        HttpClient client;
        ParDetails item;
        List<TipoviGrupi> tipovigrupi;
        List<IgraWeb> igriweb;
        List<IgriWebGrupi> igriWebGrupi;
        List<Tip> tipovi;

        public ParDetailsDataStore()
        {
            item = new ParDetails();
            tipovigrupi = new List<TipoviGrupi>();
            igriWebGrupi = new List<IgriWebGrupi>();
            igriweb = new List<IgraWeb>();
            tipovi = new List<Tip>();
            client = new HttpClient();
        }

        public async Task GetIgriWebGrupi()
        {
            try
            {
                var response = await client.GetAsync("https://apiv3.starbet.rs/api/GetAllIgriWebGrupi?jazik=" + "MK");
                response.EnsureSuccessStatusCode();
                string result = await response.Content.ReadAsStringAsync();
                igriWebGrupi = JsonConvert.DeserializeObject<List<IgriWebGrupi>>(result);
            }
            catch (Exception ex)
            {
                // to do send exception to log service
            }
        }

        private async Task GetTipoviGrupi()
        {
            try
            {
                var response = await client.GetAsync("https://apiv3.starbet.rs/api/OfferEx/GetAllTipoviGrupi");
                response.EnsureSuccessStatusCode();
                string result = await response.Content.ReadAsStringAsync();
                tipovigrupi = JsonConvert.DeserializeObject<List<TipoviGrupi>>(result);
            }
            catch (Exception ex)
            {
                // to do send exception to log service
            }
        }
        private async Task GetIgriWeb()
        {
            try
            {
                var response = await client.GetAsync("https://apiv3.starbet.rs/api/OfferEx/GetAllIgriWeb?jazik=" + "MK");
                response.EnsureSuccessStatusCode();
                string result = await response.Content.ReadAsStringAsync();
                igriweb = JsonConvert.DeserializeObject<List<IgraWeb>>(result);
            }
            catch (Exception ex)
            {
                // to do send exception to log service
            }
        }
        public async Task getTipovi()
        {
           
            try
            {
                var response = await client.GetAsync("https://apiv3.starbet.rs/api/OfferEx/GetAllTipovi?jazik=" + "MK");
                response.EnsureSuccessStatusCode();
                string result = await response.Content.ReadAsStringAsync();
                tipovi = JsonConvert.DeserializeObject<List<Tip>>(result);
            }
            catch (Exception ex)
            {
                // to do send exception to log service
            }
        }


        public async Task<ParDetails> GetItemAsync()
        {


            try
            {
                await getTipovi();
                await GetIgriWeb();
                await GetTipoviGrupi();
                await GetIgriWebGrupi();
                var response = await client.GetStringAsync("https://apiv3.starbet.rs/api/OfferEx/GetParDetail?ParId=" + "2835672");
                var parDetail = JsonConvert.DeserializeObject<ParSync>(response);


                var parAnonymous = new
                {
                    PID = parDetail.ParID,
                    PN = parDetail.ParNaziv,
                    DI = new DateTime(parDetail.DatumNaIgranje.Ticks, DateTimeKind.Local).ToString("O"),
                    S = parDetail.Sifra,
                    PK = parDetail.ParKomentar,
                    LN = parDetail.LigaNaziv,
                    SportId = parDetail.SportID,
                    IPID = parDetail.ParID,
                    BT = parDetail.BrojNaTipovi,
                    TGroups =
                      parDetail.ParTipovi.Select(x => new
                      {
                          IWID = x.IgraWebID,
                          IWGID = GetIgriWebGrupaId(x.IgraWebID),
                          ON = igriweb.Where(iw => iw.IgraWebId == x.IgraWebID).First().OrderNumber,
                          IN = GetIgraNazivDetail(x.TipID),
                          BTDetails = parDetail.ParTipovi.Where(e => e.IgraWebID != 1).Count(),
                          T = parDetail.ParTipovi.Where(z => x.IgraWebID == z.IgraWebID).Select
                       (t => new
                       {
                           IN = GetIgraNaziv(t.TipID),
                           TID = t.TipID,
                           K = GetKvota(parDetail.ParTipovi, t.TipID) == null ? "-" : GetKvota(parDetail.ParTipovi, t.TipID).ToString(),
                           G = GetGranica(parDetail.ParTipovi, t.TipID),
                           TP = GetTipNaziv(t.TipID, "MK"),
                           IWID = GetIgraWebId(t.TipID),
                           TO = t.TipOrder
                       }
                       ).OrderBy(t => t.TO)
                      })
                .DistinctBy(gt => gt.IWID).OrderBy(on => on.ON)
                };
                      
                      //.DistinctBy(gt => gt.IWID).OrderBy(on => on.ON)};
                string SerializedData = JsonConvert.SerializeObject(parAnonymous);
                item = JsonConvert.DeserializeObject<ParDetails>(SerializedData);

                return item;
            }
            catch (Exception e)
            {
                Debug.WriteLine("sdasda");
                throw;
            }
          

         

        }

        public int? GetIgriWebGrupaId(int igraWebId)
        {
            try
            {
                int? iwgId = igriWebGrupi.Where(iwg => iwg.IgriIds.Split(',').ToArray().Contains(igraWebId.ToString()) == true).Select(iwg => iwg.Id).FirstOrDefault();
                return iwgId;
            }
            catch (Exception)
            {
                Debug.WriteLine("sdasda");
                throw;
            }
          
        }
        private object GetTipNaziv(int tipID, object jazik)
        {
            if (tipovi!=null)
            {
                return tipovi.FirstOrDefault(x => x.TipId == tipID).Naziv;

            }
            else
            {
                return null;
            }
        }
        public string GetIgraNazivDetail(int TipID)
        {
            var tip = tipovi.FirstOrDefault(x => x.TipId == TipID);
            if (tip == null) return String.Empty;
            else
            {
                var s = igriweb.FirstOrDefault(x => x.IgraWebId == tip.IgraWebId);
                return s.Naziv;
            }
        
        }
        public string GetIgraNaziv(int TipID)
        {
            var tip = tipovi.FirstOrDefault(x => x.TipId == TipID);
            if (tip == null) return String.Empty;

            var s = igriweb.FirstOrDefault(x => x.IgraWebId == tip.IgraWebId);
            return s.Naziv;
        }
        private decimal? GetKvota(List<ParTip> partipovi, int TipID)
        {
            var partip = partipovi.FirstOrDefault(pp => pp.TipID == TipID);
            if (partip == null)
            {
                return null;
            }
            else
            {
                return partip.Kvota;
            }
        }
        public decimal? GetGranica(List<ParTip> partipovi, int TipID)
        {
            var partip = partipovi.FirstOrDefault(pp => pp.TipID == TipID);
            if (partip == null)
            {
                return null;
            }
            else
            {
                return partip.Granica;
            }
        }
        public int? GetIgraWebId(int TipID)
        {
            var t = tipovi.FirstOrDefault(pp => pp.TipId == TipID);
            if (t == null)
            {
                return null;
            }
            else
            {
                return t.IgraWebId;
            }

        }
    }
}
