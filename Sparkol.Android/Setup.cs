using Android.Content;
using Cirrious.CrossCore.IoC;
using Cirrious.MvvmCross.Droid.Platform;
using Cirrious.MvvmCross.ViewModels;
using Sparkol.Core;

namespace Sparkol.Android
{
	public class Setup : MvxAndroidSetup
	{
		public Setup(Context applicationContext)
			: base(applicationContext)
		{
		}

		protected override IMvxApplication CreateApp()
		{
			RegisterTypes ();

			return new App();
		}

		void RegisterTypes ()
		{
			CreatableTypes()
				.InNamespace("Sparkol.Android.Commands")
				.AsInterfaces()
				.RegisterAsLazySingleton();
		}
	}
}	