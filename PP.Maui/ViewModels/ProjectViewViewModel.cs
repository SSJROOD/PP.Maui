using PP.Library.DTO;
using PP.Library.Models;
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
    public class ProjectViewViewModel : INotifyPropertyChanged
    {
        public ClientDTO myClient { get; set; }
        public ObservableCollection<Project> ClientProjects
        {
            get
            {
                if (myClient == null || myClient.Id == 0)
                {
                    return new ObservableCollection<Project>(ProjectServices.Current.Projects);
                }
                return new ObservableCollection<Project>(ProjectServices
                    .Current
                    .Projects
                    .Where(p => p.ClientId == myClient.Id));
            }
        }
        public ProjectViewViewModel(int clientid)
        {
            if (clientid > 0)
            {
                myClient = ClientServices.Current.Get(clientid);
            }
            myClient = new ClientDTO();
        }
        public ProjectViewViewModel()
        {
            myClient = new ClientDTO { Id = 0 };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void RefreshProjectList()
        {
            NotifyPropertyChanged(nameof(ClientProjects));
        }

    }
}
