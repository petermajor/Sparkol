﻿using Cirrious.MvvmCross.Droid.Views;
using Android.App;
using Android.OS;
using Sparkol.Core.ViewModels;

namespace Sparkol.Android.Views
{
	[Activity(MainLauncher=true)]
	public class PostsView : MvxActivity<PostsViewModel>
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			SetContentView(Resource.Layout.View_Posts);
		}
	}
}

