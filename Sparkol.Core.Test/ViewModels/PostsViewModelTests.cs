using System.Collections.Generic;
using System.Threading.Tasks;
using Cirrious.MvvmCross.Test.Core;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Sparkol.Core.Commands;
using Sparkol.Core.Mappers;
using Sparkol.Core.Models;
using Sparkol.Core.ViewModels;

namespace Sparkol.Core.Test.ViewModels
{
	[TestFixture]
	public class PostsViewModelTests : MvxIoCSupportingTest
	{
		IGetPostsCommand _getPostsCommand;

		IOpenLinkCommand _openLinkCommand;

		IPostViewModelMapper _postViewModelMapper;

		PostsViewModel _model;

		[SetUp]
		public void TestSetup()
		{
			Setup ();

			_getPostsCommand = Substitute.For<IGetPostsCommand> ();

			_openLinkCommand = Substitute.For<IOpenLinkCommand> ();

			_postViewModelMapper = Substitute.For<IPostViewModelMapper> ();

			_model = new PostsViewModel (_getPostsCommand, _openLinkCommand, _postViewModelMapper);
		}

		[Test]
		public async void GivenModel_WhenInitIsCalled_ThenPostsAreLoaded ()
		{
			var posts = new [] { new Post (), new Post () };

			_getPostsCommand.Execute ().Returns (Task.FromResult (posts as IEnumerable<Post>));

			_postViewModelMapper.Map (Arg.Any<Post>()).Returns (new PostViewModel ());

			await _model.Init ();

			_getPostsCommand.Received (1).Execute ();

			_postViewModelMapper.Received (1).Map (posts[0]);
			_postViewModelMapper.Received (1).Map (posts[1]);

			_model.Posts.Count.Should ().Be (2);
		}

		[Test]
		public void GivenModel_ShowPostCommandIsExecuted_ThenOpenLinkCommandIsExecuted ()
		{
			_model.ShowPostCommand.Execute (new PostViewModel { Link = "https://www.google.co.uk" });

			_openLinkCommand.Received (1).Execute ("https://www.google.co.uk");
		}
	}
}

