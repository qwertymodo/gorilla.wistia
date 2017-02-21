using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gorilla.Wistia.Modules.Stats
{
    public class Event
    {
        private readonly Client _client;

        public Event()
        {
            _client = ClientFactory.client;
        }

        public async Task<Models.Stats.Event> Show(string eventKey)
        {
            var data = await _client.Get($"/stats/events/{eventKey}.json");
            return _client.Hydrate<Models.Stats.Event>(data);
        }
        public async Task<List<Models.Stats.Event>> List(string mediaId = null, string visitorKey = null, DateTime startDate = default(DateTime), DateTime endDate = default(DateTime), int page = 1, int perPage = 10)
        {
            var pars = new Dictionary<string, string>
            {
                ["media_id"] = mediaId,
                ["visitor_key"] = visitorKey,
                ["per_page"] = perPage.ToString(),
                ["page"] = page.ToString(),
                ["start_date"] = startDate != default(DateTime) ? startDate.ToString(@"yyyy-MM-dd") : null,
                ["end_date"] = endDate != default(DateTime) ? endDate.ToString(@"yyyy-MM-dd") : null
            };

            var data = await _client.Get("/stats/events.json", pars);
            return _client.Hydrate<List<Models.Stats.Event>>(data);
        }
    }
}
