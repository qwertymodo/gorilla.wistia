using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gorilla.Wistia.Modules.Data
{
    public class Media
    {
        private readonly Client _client;

        public Media()
        {
            _client = ClientFactory.client;
        }
        
        private async Task<Models.Data.Media> _Show(string hashedId)
        {
            var data = await _client.Get($"/medias/{hashedId}.json");
            return _client.Hydrate<Models.Data.Media>(data);
        }

        public Models.Data.Media Show(string hashedId)
        {
            return Task.Run(async () => await _Show(hashedId)).Result;
        }

        private async Task<List<Models.Data.Media>> _List(string projectId, string hashedId, int perPage, int page, string name, string type)
        {
            var pars = new Dictionary<string, string>
            {
                ["page"]       = page.ToString(),
                ["per_page"]   = perPage.ToString(),
                ["project_id"] = projectId,
                ["name"]       = name,
                ["hashed_id "] = hashedId,
                ["type"]       = type
            };

            var data = await _client.Get("/medias.json", pars);
            return _client.Hydrate<List<Models.Data.Media>>(data);
        }

        public List<Models.Data.Media> List(string projectId = null, string hashedId = null, int perPage = 10, int page = 1, string name = null, string type = null)
        {
            return Task.Run(async () => await _List(projectId, hashedId, page, perPage, name, type)).Result;
        }

        private async Task<Models.Data.Media> _Update(string hashedId, string name, string description, string new_still_media_id)
        {
            var parameters = new Dictionary<string, string>
            {
                ["name"] = name,
                ["description"] = description,
                ["new_still_media_id"] = new_still_media_id
            };

            var data = await _client.Put($"/medias/{hashedId}.json", parameters);
            return _client.Hydrate<Models.Data.Media>(data);
        }

        public Models.Data.Media Update(string hashedId, string name, string description = null, string new_still_media_id = null)
        {
            return Task.Run(async () => await _Update(hashedId, name, description, new_still_media_id)).Result;
        }

        private async Task<Models.Data.Media> _Delete(string hashedId)
        {
            var data = await _client.Delete($"/medias/{hashedId}.json");
            return _client.Hydrate<Models.Data.Media>(data);
        }

        public Models.Data.Media Delete(string hashedId)
        {
            return Task.Run(async () => await _Delete(hashedId)).Result;
        }

        private async Task<Models.Data.Media> _Copy(string hashedId)
        {
            var data = await _client.Post($"/medias/{hashedId}/copy.json");
            return _client.Hydrate<Models.Data.Media>(data);
        }

        public Models.Data.Media Copy(string hashedId)
        {
            return Task.Run(async () => await _Copy(hashedId)).Result;
        }
    }
}