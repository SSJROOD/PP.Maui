using PP.Library.Models;
using PP.Library.Services;
using PP.Maui.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PP.Maui.ViewModels
{
    public class ProjectViewModel
    {
        public Project ProjectModel { get; set; }


        public Time time;

        public ICommand TimerCommand { get; private set; }
        public ICommand EditProjectCommand { get; private set; }
        public ICommand ProjectDeleteCommand { get; private set; }
        public ICommand chooseempCommand { get; private set; }



        public void ExecuteEdit(int id)
        {
            Shell.Current.GoToAsync($"//ProjectDetail?clientId={id}");

        }

        public void chooseemployee(int id)
        {
            Shell.Current.GoToAsync($"//chooseemployee?projectid={id}");
        }
     

       
        public void ExecuteDelete(int id)
        {
            ProjectServices.Current.Delete(id);
        }


        public string Display
        {
            get
            {
                return ProjectModel.ToString() ?? string.Empty;
            }
        }


        private void ExecuteTimer()
        {
            var window = new Window(new TimerView(ProjectModel.Id))
            {
                Width = 250,
                Height = 350,
                X = 0,
                Y = 0
            };
            Application.Current.OpenWindow(window);
        }


        public void SetupCommands()
        {
            TimerCommand = new Command(ExecuteTimer);
            ProjectDeleteCommand = new Command((p) => ExecuteDelete((p as ProjectViewModel).ProjectModel.Id));
            EditProjectCommand = new Command((p) => ExecuteEdit((p as ProjectViewModel).ProjectModel.Id));
            chooseempCommand = new Command(()=>chooseemployee(ProjectModel.Id));
        }

        public void addorupdate()
        {
            ProjectServices.Current.Add(ProjectModel);

        }

        public ProjectViewModel()
        {
            ProjectModel = new Project();
            SetupCommands();
        }
        public ProjectViewModel(int id)
        {
            if (id == 0)
            {
                ProjectModel = new Project();
            }
            else
            {
                ProjectModel = ProjectServices.Current.Get(id);
            }
            SetupCommands();
        }


        public ProjectViewModel(Project model)
        {
            ProjectModel = model;
            SetupCommands();
        }

    }
}
