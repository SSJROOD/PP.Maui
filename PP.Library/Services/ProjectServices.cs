using PP.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PP.Library.Services
{
    public class ProjectServices
    {
        private static ProjectServices? instance;
        private static object _lock = new object();
        public static ProjectServices Current
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new ProjectServices();
                    }
                }

                return instance;
            }
        }
        private List<Project> projectList;
        public List<Project> Projects
        {
            get
            {
                return projectList;
            }
        }
        private ProjectServices()
        {
            projectList = new List<Project>
            {
                new Project{Id = 1,ShortName = "project1",ClientId = 2},
                new Project{Id = 2,ShortName = "project2",ClientId = 2},
                new Project{Id = 3,ShortName = "project3",ClientId = 1}

            };
        }

        public Project? Get(int id)
        {
            return projectList.FirstOrDefault(e => e.Id == id);
        }
        public void Add(Project project)
        {
            if (project.Id == 0)
            {
                project.Id = LastId + 1;
                projectList.Add(project);
                var client = ClientServices.Current.Get(project.ClientId);
                if (client != null)
                {
                    if (client.Projects == null)
                    {
                        client.Projects = new List<Project>();
                    }
                    client.Projects.Add(project);
                }
            }
        }


        private int LastId
        {
            get
            {
                return Projects.Any() ? Projects.Select(c => c.Id).Max() : 0;
            }
        }

        public List<Client> GetClients()
        {
            return ClientServices.Current.Clientlist;
        }

        public Client? GetClient(int clientId)
        {
            return ClientServices.Current.Get(clientId);
        }

        public void Delete(int id)
        {
            var projectoremove = Get(id);
            if (projectoremove != null)
            {
                projectList.Remove(projectoremove);
            }
        }
    }
}
