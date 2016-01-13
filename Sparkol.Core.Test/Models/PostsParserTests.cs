using System;
using FluentAssertions;
using NUnit.Framework;
using Sparkol.Core.Models;

namespace Sparkol.Core.Test.Models
{
	[TestFixture]
	public class PostsParserTests
	{
		IPostsParser _postsParser;

		[SetUp]
		public void SetUp()
		{
			_postsParser = new PostsParser ();
		}

		[Test]
		public void GivenTheRssIsEmpty_WhenParseIsCalled_EmptyArrayIsReturned ()
		{
			_postsParser.Parse(string.Empty).Should ().BeEmpty ();
		}

		[Test]
		public void GivenTheRssIsInvalidXml_WhenParseIsCalled_EmptyArrayIsReturned ()
		{
			_postsParser.Parse ("this is not valid xml").Should ().BeEmpty ();
		}

		[Test]
		public void GivenTheRssHasTwoPosts_WhenParseIsCalled_ThenTwoPostsAreReturned ()
		{
			const string Rss = @"<channel><title>Sparkol &#187; Blog</title>
				<item><title>p1</title><description><![CDATA[<p>xxx</p>]]></description><pubDate>Wed, 13 Jan 2016 11:20:08 +0000</pubDate></item>
				<item><title>p2</title><description><![CDATA[<p>yyy</p>]]></description><pubDate>Wed, 06 Jan 2016 17:16:10 +0000</pubDate></item>
				</channel>";

			_postsParser.Parse (Rss).ShouldAllBeEquivalentTo(new [] {
				new Post { Title = "p1", Description = @"<p>xxx</p>", PubDate = new DateTimeOffset(new DateTime(2016, 1, 13, 11, 20, 08)) },
				new Post { Title = "p2", Description = @"<p>yyy</p>", PubDate = new DateTimeOffset(new DateTime(2016, 1, 06, 17, 16, 10)) },
			});
		}
	}
}

