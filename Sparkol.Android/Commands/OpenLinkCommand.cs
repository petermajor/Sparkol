using Sparkol.Core.Commands;
using Android.Content;
using Android.Net;
using Android.App;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Droid.Platform;

namespace Sparkol.Android.Commands
{
	public class OpenLinkCommand : IOpenLinkCommand
	{
		public void Execute (string link)
		{
			var activity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity;

			var uri = Uri.Parse (link);
			var intent = new Intent(Intent.ActionView, uri);
			activity.StartActivity (intent);
		}
	}
}

