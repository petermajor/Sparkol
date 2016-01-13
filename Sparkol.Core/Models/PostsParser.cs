using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml;

namespace Sparkol.Core.Models
{
	public class PostsParser : IPostsParser
	{
		public IEnumerable<Post> Parse(string rss)
		{
			try
			{
				var xdoc = XDocument.Parse(rss);

				var posts = from item in xdoc.Descendants("item")
					select new Post
				{
					Title = (string)item.Element("title"),
					Description = (string)item.Element("description"),
					PubDate = (DateTime)item.Element("pubDate")
				};

				return posts.ToArray ();
			}
			catch (XmlException)
			{
				return Enumerable.Empty<Post> ();
			}
		}
	}

	public interface IPostsParser
	{
		IEnumerable<Post> Parse(string rss);
	}
}