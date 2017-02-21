using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gorilla.Wistia.Models.Data
{
    public class Project
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int mediaCount { get; set; }
        public DateTime created { get; set; }
        public DateTime updated { get; set; }
        public string hashedId { get; set; }
        public bool anonymousCanUpload { get; set; }
        public bool anonymousCanDownload { get; set; }
        public bool @public { get; set; }
        public string publicId { get; set; }
        private List<Media> _medias = null;
        public List<Media> medias
        {
            get
            {
                if(_medias == null)
                {
                    _medias = Task.Run(async () => await ClientFactory.client.Data.Media.List(this.hashedId, null, 1, mediaCount < 100 ? mediaCount : 100)).Result;
                }
                return _medias;
            } }
    }
}