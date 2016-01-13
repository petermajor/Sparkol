using Cirrious.MvvmCross.ViewModels;
using Sparkol.Core.ViewModels;
using Cirrious.CrossCore.IoC;
using Cirrious.CrossCore;
using System.Net.Http;

namespace Sparkol.Core
{
	public class App : MvxApplication
	{
		public override void Initialize()
		{
			base.Initialize();

			RegisterTypes ();

			InitializeNavigation();
		}

		void RegisterTypes()
		{
			CreatableTypes ()
				.InNamespace ("Sparkol.Core.Commands")
				.AsInterfaces ()
				.RegisterAsLazySingleton ();

			CreatableTypes ()
				.InNamespace ("Sparkol.Core.Mappers")
				.AsInterfaces ()
				.RegisterAsLazySingleton ();
			
			CreatableTypes ()
				.InNamespace ("Sparkol.Core.Models")
				.AsInterfaces ()
				.RegisterAsLazySingleton ();

			Mvx.RegisterSingleton<HttpMessageHandler>(new HttpClientHandler());
		}

		void InitializeNavigation()
		{
			RegisterAppStart<PostsViewModel>();
		}
	}
}
