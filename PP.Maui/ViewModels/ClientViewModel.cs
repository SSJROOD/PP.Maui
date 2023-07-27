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
using System.Windows.Input;

namespace PP.Maui.ViewModels
{
    public class ClientViewModel : INotifyPropertyChanged
    {
        public Client Model { get; set; }
        public ObservableCollection<ProjectViewModel> Projects
        {
            get
            {
                if (Model == null || Model.Id == 0)
                {
                    return new ObservableCollection<ProjectViewModel>();
                }
                return new ObservableCollection<ProjectViewModel>(ProjectServices
                    .Current
                    .Projects
                    .Where(p => p.ClientId == Model.Id)
                    .Select(r => new ProjectViewModel(r)));
            }
        }



        public string Display
        {
            get
            {
                return Model.ToString() ?? string.Empty;
            }
        }


        public ICommand DeleteCommand { get; private set; }
        public ICommand EditCommand { get; private set; }
        public ICommand ShowProjectCommand { get; private set; }








        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void ExecuteDelete(int id)
        {
            ClientServices.Current.Delete(id);
        }

        public void ExecuteShowProjects(int id)
        {
            Shell.Current.GoToAsync($"//ProjectList?clientId={id}");
        }
        public void ExecuteEdit(int id)
        {
            Shell.Current.GoToAsync($"//ClientDetail?clientId={id}");
        }

        public void RefreshProjects()
        {
            NotifyPropertyChanged(nameof(Projects));
        }


        public ClientViewModel(Client client)
        {
            Model = client;
            SetupCommands();
        }

        private void SetupCommands()
        {
            DeleteCommand = new Command((c) => ExecuteDelete((c as ClientViewModel).Model.Id));
            EditCommand = new Command((c) => ExecuteEdit((c as ClientViewModel).Model.Id));
            ShowProjectCommand = new Command((c) => ExecuteShowProjects((c as ClientViewModel).Model.Id));
        }
        public ClientViewModel(int id)
        {
            if (id == 0)
            {
                Model = new Client();
            }
            else
            {
                Model = ClientServices.Current.Get(id);
            }
            SetupCommands();
        }

        public ClientViewModel()
        {
            Model = new Client();
            SetupCommands();
        }

        public void AddOrUpdate()
        {
            ClientServices.Current.AddOrUpdate(Model);
        }

        public void RefreshProjectList()
        {
            NotifyPropertyChanged(nameof(Projects));
        }
    }
}
