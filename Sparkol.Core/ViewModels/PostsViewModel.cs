using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using PropertyChanged;
using Sparkol.Core.Commands;
using Sparkol.Core.Mappers;

namespace Sparkol.Core.ViewModels
{
	[ImplementPropertyChanged]
	public class PostsViewModel : MvxViewModel
	{
		public ObservableCollection<PostViewModel> Posts { get; private set; } = new ObservableCollection<PostViewModel>();

		public ICommand ShowPostCommand { get; private set; }

		readonly IGetPostsCommand _getPostsCommand;

		readonly IOpenLinkCommand _openLinkCommand;

		readonly IPostViewModelMapper _postMapper;

		public PostsViewModel(IGetPostsCommand getPostsCommand, IOpenLinkCommand openLinkCommand, IPostViewModelMapper postMapper)
		{
			_getPostsCommand = getPostsCommand;
			_openLinkCommand = openLinkCommand;
			_postMapper = postMapper;

			ShowPostCommand = new MvxCommand<PostViewModel> (ExecuteShowPostCommand);
		}

		public Task Init()
		{
			return LoadPosts ();
		}

		async Task LoadPosts()
		{
			var posts = await _getPostsCommand.Execute ();

			Posts.Clear ();

			foreach (var post in posts) {
				var model = _postMapper.Map (post);
				Posts.Add (model);
			}
		}

		void ExecuteShowPostCommand (PostViewModel post)
		{
			_openLinkCommand.Execute(post.Link);
		}
	}
}