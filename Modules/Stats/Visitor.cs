using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gorilla.Wistia.Modules.Stats
{
    public class Visitor
    {
        private readonly Client _client;

        public Visitor(Client client)
        {
            _client = client;
        }

        public async Task<Models.Stats.Visitor> Show(string visitorKey)
        {
            var data = await _client.Get($"/medias/{visitorKey}.json");
            return _client.Hydrate<Models.Stats.Visitor>(data);
        }
        public async Task<List<Models.Stats.Visitor>> List(string filter = null, string search = null, int page = 1, int perPage = 10)
        {
            var pars = new Dictionary<string, string>
            {
                ["page"] = page.ToString(),
                ["per_page"] = perPage.ToString(),
                ["filter"] = filter,
                ["search"] = search
            };

            var data = await _client.Get("/stats/visitors.json", pars);
            return _client.Hydrate<List<Models.Stats.Visitor>>(data);
        }
    }
}
