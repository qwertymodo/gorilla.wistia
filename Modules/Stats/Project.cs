using System.Threading.Tasks;

namespace Gorilla.Wistia.Modules.Stats
{
    public class Project
    {
        private readonly Client _client;

        public Project()
        {
            _client = ClientFactory.client;
        }

        private async Task<Models.Stats.Project> _Show(string projectId)
        {
            var data = await _client.Get($"/stats/projects/{projectId}.json");
            return _client.Hydrate<Models.Stats.Project>(data);
        }

        public Models.Stats.Project Show(string projectId)
        {
            return Task.Run(async () => await _Show(projectId)).Result;
        }
    }
}