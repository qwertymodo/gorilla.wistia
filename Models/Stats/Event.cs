using System;
using System.Collections.Generic;

namespace Gorilla.Wistia.Models.Stats
{
    public class Event
    {
        public DateTime received_at { get; set; }
        public string event_key { get; set; }
        public string visitor_key { get; set; }
        public string embed_url { get; set; }
        public double percent_viewed { get; set; }
        public string ip { get; set; }
        public string org { get; set; }
        public string country { get; set; }
        public string region { get; set; }
        public string city { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
        public string email { get; set; }
        public string media_id { get; set; }    // => Gorilla.Wistia.Models.Data.Media.hashed_id
        public string media_url { get; set; }
        public string media_name { get; set; }  // => Gorilla.Wistia.Models.Data.Media.name
        public string iframe_heatmap_url { get; set; }
    }
}