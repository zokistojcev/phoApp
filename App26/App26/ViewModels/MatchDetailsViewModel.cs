using App26.Models;
using App26.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App26.ViewModels
{
    public class MatchDetailsViewModel: BaseViewModel
    {
        public IDataMatchDetails<ParDetails> DataStoreparDetails => DependencyService.Get<IDataMatchDetails<ParDetails>>();
        private ParDetails Par;
        private ObservableCollection<TipoviGroups> _tipGroups;
        public ObservableCollection<TipoviGroups> TipGroups
        {
            get { return _tipGroups; }
            set { SetProperty(ref _tipGroups, value); }
        }
        private string _host;
        public string Host
        {
            get { return _host; }
            set { SetProperty(ref _host, value); }
        }
        private string _visitor;
        public string Visitor
        {
            get { return _visitor; }
            set { SetProperty(ref _visitor, value); }
        }
        public MatchDetailsViewModel()
        {
            ParDetails Par = new ParDetails();
            Task.Run(async () => await ExecuteMatchDetails());
        }
        public async Task ExecuteMatchDetails()
        {
            Par = await DataStoreparDetails.GetItemAsync();
            Host = Par.PN.Split(':')[0];
            Visitor = Par.PN.Split(':')[1].TrimStart();
            TipGroups = new ObservableCollection<TipoviGroups>(Par.TGroups);
        }
    }
}
