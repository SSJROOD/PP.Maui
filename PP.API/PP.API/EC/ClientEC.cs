using PP.API.Database;
using PP.Library.DTO;
using PP.Library.Models;
namespace PP.API.EC
{
    public class ClientEC
    {
        public ClientDTO AddOrUpdate(ClientDTO dto)
        {
            if(dto.Id > 0)
            {
                var cUpdate = FakeDatabase.
                    Clients.
                    FirstOrDefault(x=> x.Id == dto.Id);
                if(cUpdate != null)
                {
                    FakeDatabase.Clients.Remove(cUpdate);
                }
                FakeDatabase.Clients.Add(new Client(dto));

            }
            else
            {
                dto.Id = FakeDatabase.LastClientId + 1;
                FakeDatabase.Clients.Add(new Client(dto));
            }
            return dto;
        }

        public IEnumerable<ClientDTO> Search(string query = "")
        {
           return FakeDatabase.Clients.
                               Where(c => c.Name.ToUpper().
                               Contains(query.ToUpper())).
                               Take(100).
                               Select(c => new ClientDTO(c));
        }

        public ClientDTO? Get(int id)
        {
            var result =  FakeDatabase.
                           Clients.
                           FirstOrDefault(c => c.Id == id) ?? new Client();

            return new ClientDTO(result);

        }

        public ClientDTO? Delete(int id)
        {
            var c = FakeDatabase.Clients.FirstOrDefault(x => x.Id == id);
            if (c != null)
            {
                FakeDatabase.Clients.Remove(c);
            }
            return c != null ? new ClientDTO(c) : null;
        }

    }
}
