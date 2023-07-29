using Newtonsoft.Json;
using PP.Library.DTO;
using PP.Library.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private List<ClientDTO> clientList;
        public List<ClientDTO> Clientlist
        {
            get
            {
                return clientList ?? new List<ClientDTO>();
            }
        }

        private ClientServices()
        {
            var response = new WebRequestHandler().Get("/Client").Result;
            clientList = JsonConvert.DeserializeObject<List<ClientDTO>>(response) ?? new List<ClientDTO>();
        }


        public ClientDTO? Get(int id)
        {
            var response = new WebRequestHandler().Get($"/{id}").Result;
            return JsonConvert.DeserializeObject<ClientDTO>(response);
        }
        public void AddOrUpdate(ClientDTO c)
        {
            var response = new WebRequestHandler().Post("/Client", c).Result;
            var updatedClient = JsonConvert.DeserializeObject<ClientDTO>(response);
            if (updatedClient != null)
            {
                var existingClient = clientList.FirstOrDefault(c => c.Id == updatedClient.Id);
                if (existingClient == null)
                {
                    clientList.Add(updatedClient);
                }
                else
                {
                    var index = clientList.IndexOf(existingClient);
                    clientList.RemoveAt(index);
                    clientList.Insert(index, updatedClient);
                }
            }



        }

        public void Delete(int id)
        {
            var clientToRemove = clientList.FirstOrDefault(c => c.Id == id);
            if (clientToRemove != null)
            {
                var projectsToRemove = ProjectServices.Current.Projects.Where(p => p.ClientId == id).ToList();
                foreach (var project in projectsToRemove)
                {
                    ProjectServices.Current.Delete(project.Id);
                }

                var response = new WebRequestHandler().Delete($"/Client/Delete/{id}").Result;
                clientList.Remove(clientToRemove);
            }
        }



    }
}
