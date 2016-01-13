using Cirrious.MvvmCross.ViewModels;
using Sparkol.Core.ViewModels;

namespace Sparkol.Core
{
	public class App : MvxApplication
	{
		public override void Initialize()
		{
			base.Initialize();

			InitialiseStartNavigation();
		}

		void InitialiseStartNavigation()
		{
			RegisterAppStart<PostsViewModel>();
		}
	}
}
