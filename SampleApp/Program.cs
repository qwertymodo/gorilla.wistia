using System;
using Gorilla.Wistia;
using Data = Gorilla.Wistia.Models.Data;
using Stats = Gorilla.Wistia.Models.Stats;

namespace SampleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var client = ClientFactory.client;

            //var fs = File.OpenRead(@"C:\Temp\video.mp4");
            //var result = client.Upload.File(fs, "video.mp4", "yay").Result;

            //var result = client.Upload.Url("https://someurl", "video.mp4", "description").Result;

            //var result = client.Project.Show("6iacldoykb")
            //var result = client.Project.List();
            //var result = client.Project.Create("Prado Feio");
            //var result = client.Project.Update("2wuj01wtig", "works");
            //var result = client.Project.Delete("2wuj01wtig");
            //var result = client.Media.List();
            //var result = client.Media.Update("t5w12nnlzt", "Yay!", "done");
            //var result = client.Media.Delete("r9s5thz641");
            //var result = client.Media.Copy("2t98ah8i2i");
            //var result = client.Account.Show();

            try
            {
                var visitorList = client.Stats.Visitor.List();
                foreach (Stats.Visitor visitor in visitorList)
                {
                    Console.WriteLine(visitor.visitor_identity.name + " " + visitor.visitor_identity.email);

                    try
                    {
                        var eventList = client.Stats.Event.List();
                        foreach (Stats.Event e in eventList)
                        {
                            Console.WriteLine(e.media_name + " " + e.event_key);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
