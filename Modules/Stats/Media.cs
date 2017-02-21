using System.Threading.Tasks;

namespace Gorilla.Wistia.Modules.Stats
{
    public class Media
    {
        private readonly Client _client;

        public Media()
        {
            _client = ClientFactory.client;
        }

        private async Task<Models.Stats.Media> _Show(string hashedId)
        {
            var data = await _client.Get($"/stats/medias/{hashedId}.json");
            return _client.Hydrate<Models.Stats.Media>(data);
        }

        public Models.Stats.Media Show(string hashedId)
        {
            return Task.Run(async () => await _Show(hashedId)).Result;
        }
    }
}