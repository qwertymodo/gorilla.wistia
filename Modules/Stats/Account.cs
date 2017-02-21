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

        private async Task<Models.Stats.Account> _Show()
        {
            var data = await _client.Get("/stats/account.json");
            return _client.Hydrate<Models.Stats.Account>(data);
        }

        public Models.Stats.Account Show()
        {
            return Task.Run(async () => await _Show()).Result;
        }
    }
}