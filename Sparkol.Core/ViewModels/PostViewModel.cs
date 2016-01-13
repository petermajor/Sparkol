using PropertyChanged;

namespace Sparkol.Core.ViewModels
{
	[ImplementPropertyChanged]
	public class PostViewModel
	{
		public string Title { get; set; }

		public string InitialPostingDate { get; set; }

		public string Description { get; set; }
	}
}