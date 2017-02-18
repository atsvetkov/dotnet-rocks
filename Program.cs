using System;
using System.Linq;
using System.Net.Http;
using System.Xml.Linq;

namespace SurfingTheCode.DotNetRocks
{
    class Program
    {
        private const string EpisodeFeedUrl = "http://www.pwop.com/feed.aspx?show=dotnetrocks&filetype=master";
        private const int DefaultItemCount = 10;

        static void Main(string[] args)
        {
            var itemCount = args.Length > 0 && int.TryParse(args[0], out int count) ? count : DefaultItemCount;
            
            var client = new HttpClient();
            XDocument feed;
            using (var stream = client.GetStreamAsync(EpisodeFeedUrl).Result)
            {
                feed = XDocument.Load(stream);
            }
            
            Console.WriteLine($"Pick one of {itemCount} last episodes on .NET Rocks! to play:");
            
            var options = feed.Descendants("item")
                              .Take(itemCount)
                              .Select(Episode.FromXElement)
                              .ToList();
            
            var selectedEpisode = ConsoleMenu.Prompt(options);
            UrlHelper.OpenUrl(selectedEpisode.AudioUrl);
        }               
    }
}