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

        private async Task<Models.Stats.Event> _Show(string eventKey)
        {
            var data = await _client.Get($"/stats/events/{eventKey}.json");
            return _client.Hydrate<Models.Stats.Event>(data);
        }

        public Models.Stats.Event Show(string eventKey)
        {
            return Task.Run(async () => await _Show(eventKey)).Result;
        }

        private async Task<List<Models.Stats.Event>> _List(string mediaId, string visitorKey, DateTime startDate, DateTime endDate, int perPage, int page)
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

        public List<Models.Stats.Event> List(string mediaId = null, string visitorKey = null, DateTime startDate = default(DateTime), DateTime endDate = default(DateTime), int perPage = 10, int page = 1)
        {
            return Task.Run(async () => await _List(mediaId, visitorKey, startDate, endDate, perPage, page)).Result;
        }
    }
}
