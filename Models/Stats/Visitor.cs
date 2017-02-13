using System;
using System.Collections.Generic;

namespace Gorilla.Wistia.Models.Stats
{
    public class Visitor
    {
        public string visitor_key { get; set; }
        public DateTime created_at { get; set; }
        public DateTime last_active_at { get; set; }
        public string last_event_key { get; set; }
        public int load_count { get; set; }
        public int play_count { get; set; }
        public string identifying_event_key { get; set; }
        public VisitorIdentity visitor_identity { get; set; }
        public VisitorUserAgent user_agent_details { get; set; }
    }
}
