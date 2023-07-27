using PP.Library.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PP.Maui.ViewModels
{
    public class ClientViewViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ClientViewModel> Clients
        {
            get
            {
                if (string.IsNullOrEmpty(Query))
                {
                    return new ObservableCollection<ClientViewModel>
                        (
                        ClientServices
                       .Current
                       .Clientlist
                       .Select(c => new ClientViewModel(c)).ToList()
                       );
                }
                return new ObservableCollection<ClientViewModel>
                    (
                    ClientServices.
                    Current.
                    Clientlist.
                    Where(c => c.Name.ToUpper().Contains(Query.ToUpper())).
                    Select(c => new ClientViewModel(c)).ToList()
                );
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public string Query { get; set; }




        public void RefreshClientList()
        {
            NotifyPropertyChanged(nameof(Clients));
        }


    }
}
