using System.Threading.Tasks;

namespace Gorilla.Wistia.Modules.Stats
{
    public class Account
    {
        private readonly Client _client;

        public Account()
        {
            _client = ClientFactory.client;
        }

        public async Task<Models.Stats.Account> Show()
        {
            var data = await _client.Get("/stats/account.json");
            return _client.Hydrate<Models.Stats.Account>(data);
        }
    }
}