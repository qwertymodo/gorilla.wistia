using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gorilla.Wistia.Modules.Stats
{
    public class Visitor
    {
        private readonly Client _client;

        public Visitor()
        {
            _client = ClientFactory.client;
        }

        private async Task<Models.Stats.Visitor> _Show(string visitorKey)
        {
            var data = await _client.Get($"/medias/{visitorKey}.json");
            return _client.Hydrate<Models.Stats.Visitor>(data);
        }

        public Models.Stats.Visitor Show(string visitoryKey)
        {
            return Task.Run(async () => await _Show(visitoryKey)).Result;
        }

        private async Task<List<Models.Stats.Visitor>> _List(string filter, string search, int perPage, int page)
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

        public List<Models.Stats.Visitor> List(string filter = null, string search = null, int perPage = 10, int page = 1)
        {
            return Task.Run(async () => await _List(filter, search, perPage, page)).Result;
        }
    }
}
