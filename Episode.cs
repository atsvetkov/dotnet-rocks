using System.Linq;
using System.Xml.Linq;

namespace SurfingTheCode.DotNetRocks
{
    public sealed class Episode
    {
        public string Title { get; set; }
        public string PublicationDate { get; set; }
        public string AudioUrl { get; set; }
        public string Number { get; set; }

        public override string ToString()
        {
            return $"{PublicationDate}: {Title}";
        }

        public static Episode FromXElement(XElement element)
        {
            var title = element.Elements().Single(e => e.Name == "title").Value;
            var publicationDate = element.Elements().Single(e => e.Name == "pubDate").Value.Substring(5, 11);
            var audioUrl = element.Elements().Single(e => e.Name == "enclosure").Attribute("url").Value;
            var link = element.Elements().Single(e => e.Name == "link").Value;

            return new Episode
            {
                Title = title,
                PublicationDate = publicationDate,
                AudioUrl = audioUrl,
                Number = link.Substring(link.LastIndexOf('=') + 1)
            };
        }
    }
}