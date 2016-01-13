using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Sparkol.Core.Models;

namespace Sparkol.Core.Commands
{
	public class GetPostsCommand : IGetPostsCommand
	{
		const string FeedUrl = "http://www.sparkol.com/engage/feed/";

		readonly IPostsParser _postsParser;

		readonly HttpMessageHandler _httpMessageHandler;

		public GetPostsCommand(IPostsParser postsParser, HttpMessageHandler httpMessageHandler)
		{
			_postsParser = postsParser;
			_httpMessageHandler = httpMessageHandler;
		}

		public async Task<IEnumerable<Post>> Execute()
		{
			var httpClient = new HttpClient(_httpMessageHandler);

			var responseString = await httpClient.GetStringAsync(FeedUrl)
				.ConfigureAwait(false);

			var posts = _postsParser.Parse(responseString);

			return posts;
		}

	}

	public interface IGetPostsCommand
	{
		Task<IEnumerable<Post>> Execute ();
	}
}