using Sparkol.Core.Models;
using Sparkol.Core.ViewModels;

namespace Sparkol.Core.Mappers
{
	public class PostViewModelMapper : IPostViewModelMapper
	{
		public PostViewModel Map(Post post)
		{
			return new PostViewModel {
				Title = post.Title,
				PublicationDate = post.PubDate.LocalDateTime.ToString("g"),
				Description = post.Description,
				Link = post.Link,
			};
		}
	}

	public interface IPostViewModelMapper
	{
		PostViewModel Map (Post post);
	}
}