using System;
using System.Collections.Generic;

namespace Gorilla.Wistia.Models.Data
{

    public class Media
    {
        public Project project { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string status { get; set; }
        public float progress { get; set; }
        public string section { get; set; }
        public Thumbnail thumbnail { get; set; }
        public float duration { get; set; }
        public DateTime created { get; set; }
        public DateTime updated { get; set; }
        public List<Asset> assets { get; set; }
        public string description { get; set; }
        public string hashed_id { get; set; }
    }
}