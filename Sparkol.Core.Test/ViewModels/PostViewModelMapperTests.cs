using System;
using FluentAssertions;
using NUnit.Framework;
using Sparkol.Core.Mappers;
using Sparkol.Core.Models;
using Sparkol.Core.ViewModels;

namespace Sparkol.Core.Test.ViewModels
{
	[TestFixture]
	public class PostViewModelMapperTests
	{
		PostViewModelMapper _mapper;

		[SetUp]
		public void SetUp()
		{
			_mapper = new PostViewModelMapper ();
		}

		[Test]
		public void GivenPost_WhenMapIsCalled_APostViewModelIsReturned ()
		{
			var post = new Post { Title = "t", Description = "d", Link = "l", PubDate = new DateTimeOffset(new DateTime(2016, 1, 13, 11, 20, 08), DateTimeOffset.Now.Offset) };

			var model = _mapper.Map (post);

			var expected = new PostViewModel {
				Title = post.Title,
				Description = post.Description,
				Link = post.Link,
				PublicationDate = new DateTime(2016, 1, 13, 11, 20, 08, DateTimeKind.Local).ToString ("g")
			};

			model.ShouldBeEquivalentTo(expected);
		}

		[Test]
		public void GivenPost_WhenPubDateIsInDifferentOffset_InitialPostingDateIsInLocalTime ()
		{
			var post = new Post { Title = "t", Description = "d", Link = "l", PubDate = new DateTimeOffset(new DateTime(2016, 1, 13, 11, 20, 08), DateTimeOffset.Now.Offset.Add(TimeSpan.FromHours(-1))) };

			var model = _mapper.Map (post);

			var expected = new PostViewModel {
				Title = post.Title,
				Description = post.Description,
				Link = post.Link,
				PublicationDate = new DateTime(2016, 1, 13, 12, 20, 08, DateTimeKind.Local).ToString ("g")
			};

			model.ShouldBeEquivalentTo(expected);
		}
	}
}

