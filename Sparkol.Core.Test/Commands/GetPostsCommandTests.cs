using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using RichardSzalay.MockHttp;
using Sparkol.Core.Commands;
using Sparkol.Core.Models;

namespace Sparkol.Core.Test.Commands
{
	[TestFixture]
	public class GetPostsCommandTests
	{
		const string FeedUrl = "http://www.sparkol.com/engage/feed/";

		const string FeedResponse = @"<feed/>";

		const string ApplicationXml = @"application/xml";

		IPostsParser _postsParser;

		MockHttpMessageHandler _httpMessageHandler;

		IGetPostsCommand _getPostsCommand;

		[SetUp]
		public void SetUp()
		{
			_postsParser = Substitute.For<IPostsParser> ();

			_httpMessageHandler = new MockHttpMessageHandler ();

			_getPostsCommand = new GetPostsCommand (_postsParser, _httpMessageHandler);
		}

		[Test]
		public async void GivenACommand_WhenExecuteIsCalled_TheRssEndpointIsCalled ()
		{
			_httpMessageHandler.Expect (FeedUrl).Respond(ApplicationXml, FeedResponse);

			await _getPostsCommand.Execute ();

			_httpMessageHandler.VerifyNoOutstandingExpectation ();
		}

		[Test]
		public async void GivenACommand_WhenAResponseIsReturnedFromTheEndpoint_TheResponseIsPassedToTheParser ()
		{
			_httpMessageHandler.When(FeedUrl).Respond(ApplicationXml, FeedResponse);

			await _getPostsCommand.Execute ();

			_postsParser.Received().Parse (FeedResponse);
		}

		[Test]
		public async void GivenACommand_WhenThePostsAreParsed_ThePostsAreReturned()
		{
			var posts = new [] {
				new Post { Title = "p1" },
				new Post { Title = "p2" },
			};

			_httpMessageHandler.When(FeedUrl).Respond(ApplicationXml, FeedResponse);

			_postsParser.Parse (FeedResponse).Returns(posts);

			var result = await _getPostsCommand.Execute ();

			result.Should ().BeSameAs (posts);
		}
	}
}

