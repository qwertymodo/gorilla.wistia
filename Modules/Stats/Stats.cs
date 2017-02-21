namespace Gorilla.Wistia.Modules.Stats
{
    public class Stats
    {
        public Stats()
        { }

        public Media Media => new Media();
        public Project Project => new Project();
        public Account Account => new Account();
        public Visitor Visitor => new Visitor();
        public Event Event => new Event();
    }
}