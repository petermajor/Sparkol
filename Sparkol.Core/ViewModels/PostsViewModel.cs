using Cirrious.MvvmCross.ViewModels;
using PropertyChanged;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Sparkol.Core.Commands;

namespace Sparkol.Core.ViewModels
{
	[ImplementPropertyChanged]
	public class PostsViewModel : MvxViewModel
	{
		public ObservableCollection<PostViewModel> Posts { get; private set; } = new ObservableCollection<PostViewModel>();

		public ICommand ShowPostCommand { get; private set; }

		readonly IOpenLinkCommand _openLinkCommand;

		public PostsViewModel(IOpenLinkCommand openLinkCommand)
		{
			_openLinkCommand = openLinkCommand;

			ShowPostCommand = new MvxCommand<PostViewModel> (ExecuteShowPostCommand);

			Posts.Add (new PostViewModel {
				Title = "David Bowie’s wonderful way of handling the thrill of live performance",
				InitialPostingDate = "Wed, 13 Jan 2016 11:20",
				Link = @"http://www.sparkol.com/engage/david-bowies-wonderful-way-of-handling-the-thrill-of-live-performance/",
				Description = @"<p>It's sad whenever somebody you admire dies. But the many wonderful things you then learn about them can temper that sadness. Here's something new I enjoyed learning about David Bowie.</p>
<p>The post <a rel=""nofollow"" href=""http://www.sparkol.com/engage/david-bowies-wonderful-way-of-handling-the-thrill-of-live-performance/"">David Bowie’s wonderful way of handling the thrill of live performance</a> appeared first on <a rel=""nofollow"" href=""http://www.sparkol.com"">Sparkol</a>.</p>",
			});

			Posts.Add (new PostViewModel {
				Title = "8 Extremely inspiring words for public speakers",
				InitialPostingDate = "Wed, 13 Jan 2016 09:27",
				Link = "http://www.sparkol.com/engage/8-extremely-inspiring-words-for-public-speakers/",
				Description = @"<p>Communicating well – whether it's with your co-workers, customers or followers – isn't always easy. Discover these 8 powerful words and knock your audience's socks off.</p>
<p>The post <a rel=""nofollow"" href=""http://www.sparkol.com/engage/8-extremely-inspiring-words-for-public-speakers/"">8 Extremely inspiring words for public speakers</a> appeared first on <a rel=""nofollow"" href=""http://www.sparkol.com"">Sparkol</a>.</p>",
			});
		}

		void ExecuteShowPostCommand (PostViewModel post)
		{
			_openLinkCommand.Execute(post.Link);
		}
	}
}