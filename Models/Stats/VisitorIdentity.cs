namespace Gorilla.Wistia.Models.Stats
{
    public class VisitorIdentity
    {
        public string name { get; set; }
        public string email { get; set; }
        public VisitorOrganization org { get; set; }
    }
}
