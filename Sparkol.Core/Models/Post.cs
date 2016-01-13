using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Sparkol.Core.Models
{
	public class Post
	{
		public string Title { get; set; }

		public DateTimeOffset PubDate { get; set; }

		public string Description { get; set; }
	}
}