using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gorilla.Wistia.Modules.Data
{
    public class Project
    {
        private readonly Client _client;

        public Project()
        {
            _client = ClientFactory.client;
        }

        private async Task<Models.Data.Project> _Show(string hashedId)
        {
            var data = await _client.Get($"/projects/{hashedId}.json");
            return _client.Hydrate<Models.Data.Project>(data);
        }

        public Models.Data.Project Show(string hashedId)
        {
            return Task.Run(async () => await _Show(hashedId)).Result;
        }

        private async Task<List<Models.Data.Project>> _List(int perPage, int page)
        {
            var pars = new Dictionary<string, string>
            {
                ["page"]     = page.ToString(),
                ["per_page"] = perPage.ToString()
            };
            
            var data = await _client.Get("/projects.json", pars);
            return _client.Hydrate<List<Models.Data.Project>>(data);
        }

        public List<Models.Data.Project> List(int perPage = 10, int page = 1)
        {
            return Task.Run(async () => await _List(perPage, page)).Result;
        }

        private async Task<Models.Data.Project> _Create(string name, bool anonymousCanUpload, bool anonymousCanDownload, bool @public, string adminEmail)
        {
            var parameters = new Dictionary<string, string>
            {
                ["name"] = name,
                ["anonymousCanUpload"] = anonymousCanUpload ? "1" : null,
                ["anonymousCanDownload"] = anonymousCanDownload ? "1" : null,
                ["public"] = @public ? "1" : null
            };

            if (!string.IsNullOrWhiteSpace(adminEmail))
            {
                parameters.Add("adminEmail", adminEmail);
            }

            var data = await _client.Post("/projects.json", parameters);
            return _client.Hydrate<Models.Data.Project>(data);
        }

        public Models.Data.Project Create(string name, bool anonymousCanUpload = false,
            bool anonymousCanDownload = false, bool @public = false, string adminEmail = null)
        {
            return Task.Run(async () => await _Create(name, anonymousCanUpload, anonymousCanDownload, @public, adminEmail)).Result;
        }

        private async Task<Models.Data.Project> _Update(string hashedId, string name, bool anonymousCanUpload, bool anonymousCanDownload, bool @public)
        {
            var parameters = new Dictionary<string, string>
            {
                ["name"] = name,
                ["anonymousCanUpload"] = anonymousCanUpload ? "1" : "0",
                ["anonymousCanDownload"] = anonymousCanDownload ? "1" : "0",
                ["public"] = @public ? "1" : "0"
            };

            var data = await _client.Put($"/projects/{hashedId}.json", parameters);
            return _client.Hydrate<Models.Data.Project>(data);
        }

        public Models.Data.Project Update(string hashedId, string name, bool anonymousCanUpload = false,
            bool anonymousCanDownload = false, bool @public = false)
        {
            return Task.Run(async () => await _Update(hashedId, name, anonymousCanUpload, anonymousCanDownload, @public)).Result;
        }

        private async Task<Models.Data.Project> _Delete(string hashedId)
        {
            var data = await _client.Delete($"/projects/{hashedId}.json");
            return _client.Hydrate<Models.Data.Project>(data);
        }

        public Models.Data.Project Delete(string hashedId)
        {
            return Task.Run(async () => await _Delete(hashedId)).Result;
        }

        private async Task<Models.Data.Project> _Copy(string hashedId)
        {
            var data = await _client.Post($"/projects/{hashedId}/copy.json");
            return _client.Hydrate<Models.Data.Project>(data);
        }

        public Models.Data.Project Copy(string hashedId)
        {
            return Task.Run(async () => await _Copy(hashedId)).Result;
        }
    }
}