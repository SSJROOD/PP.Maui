using PP.Library.Models;

namespace PP.API.Database
{
    public static class FakeDatabase
    {
        public static List<Client> Clients = new List<Client>
            {
                new Client {Id = 1, Name = "Client1",OpenDate = DateTime.Now, IsActive=true},
                new Client {Id = 2, Name = "Client2",OpenDate = DateTime.Now, IsActive=true},
                new Client { Id = 3, Name = "Client3", OpenDate = DateTime.Now, IsActive = true }
            };

        public static int LastClientId
        {
            get
            {
                if(Clients.Any())
                {
                    return Clients.Select(c => c.Id).Max();
                }
                return 0;
            }
        }
    }
}
