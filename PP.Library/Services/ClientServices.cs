using PP.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PP.Library.Services
{
    public class ClientServices
    {
        private static ClientServices? instance;
        private static object _lock = new object();

        public static ClientServices Current
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new ClientServices();
                    }
                }
                return instance;
            }
        }
        private List<Client> clientList;
        public List<Client> Clientlist
        {
            get { return clientList; }
        }

        private ClientServices()
        {
            clientList = new List<Client>
            {
                new Client {Id = 1, Name = "Client1",OpenDate = DateTime.Now, IsActive=true},
                new Client {Id = 2, Name = "Client2",OpenDate = DateTime.Now, IsActive=true},
                new Client {Id = 3, Name = "Client3", OpenDate = DateTime.Now, IsActive = true}
            };

        }


        public Client? Get(int id)
        {

            var client = clientList.FirstOrDefault(e => e.Id == id);
            if (client != null && client.Projects != null)
            {
                client.Projects = ProjectServices.
                    Current.
                    Projects.
                    Where(p => p.ClientId == id).ToList();
            }
            return client;
        }
        public void AddOrUpdate(Client c)
        {
            if (c.Id == 0)
            {
                //add
                c.Id = LastId + 1;
                Clientlist.Add(c);
            }
        }
        private int LastId
        {
            get
            {
                return Clientlist.Any() ? Clientlist.Select(c => c.Id).Max() : 1;
            }
        }
        public void Delete(int id)
        {
            var clientToRemove = Get(id);
            if (clientToRemove != null)
            {
                var projectsToRemove = ProjectServices.Current.Projects.Where(p => p.ClientId == id).ToList();
                foreach (var project in projectsToRemove)
                {
                    ProjectServices.Current.Delete(project.Id);
                }
                clientList.Remove(clientToRemove);
            }
        }

        public void Delete(Client s)
        {
            Delete(s.Id);
        }
    }
}
