using PP.API.Database;
using PP.Library.DTO;
using PP.Library.Models;
namespace PP.API.EC
{
    public class ClientEC
    {
        public ClientDTO AddOrUpdate(Client client)
        {
            var result = ClientDatabase.Current.AddOrUpdate(client);
            return new ClientDTO(client);
        }

        public IEnumerable<ClientDTO> Search(string query = "")
        {
            var result = ClientDatabase.Current.Search(query);
            return result.Select(c => new ClientDTO(c));
        }

        public ClientDTO? Get(int id)
        {
            var result =  ClientDatabase.Current.GetClient(id);
            return new ClientDTO(result);

        }

        public List<ClientDTO> Get()
        {
            var result = ClientDatabase.Current.Get();
            return result.Select(c => new ClientDTO
            {
                Id = c.Id,
                Name = c.Name,
                OpenDate = c.OpenDate,
                IsActive = c.IsActive
            }).ToList();
        }

        public ClientDTO? Delete(int id)
        {
           var result = ClientDatabase.Current.Delete(id);
            return result != null ? new ClientDTO(result) : null;
        }

    }
}
