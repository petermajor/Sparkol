using Sparkol.Core.Commands;
using Android.Content;
using Android.Net;
using Android.App;
using Cirrious.CrossCore.Droid.Platform;

namespace Sparkol.Android.Commands
{
	public class OpenLinkCommand : IOpenLinkCommand
	{
		readonly IMvxAndroidCurrentTopActivity _topActivityProvider;

		public OpenLinkCommand(IMvxAndroidCurrentTopActivity topActivityProvider)
		{
			_topActivityProvider = topActivityProvider;
		}

		public void Execute (string link)
		{
			var activity = _topActivityProvider.Activity;

			var uri = Uri.Parse (link);
			var intent = new Intent(Intent.ActionView, uri);
			activity.StartActivity (intent);
		}
	}
}

