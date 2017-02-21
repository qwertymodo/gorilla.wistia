using System.Threading.Tasks;

namespace Gorilla.Wistia.Modules.Data
{
    public class Account
    {
        private readonly Client _client;

        public Account()
        {
            _client = ClientFactory.client;
        }

        public async Task<Models.Data.Account> Show()
        {
            var data = await _client.Get("/account.json");
            return _client.Hydrate<Models.Data.Account>(data);
        }
    }
}