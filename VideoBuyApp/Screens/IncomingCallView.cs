using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Telephony;

namespace VideoBuyApp
{
	[Activity(Label = "VideoBuyApp", ScreenOrientation = ScreenOrientation.Portrait)]
	public class IncomingCallView : Base
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			var inflater = (LayoutInflater)ApplicationContext.GetSystemService(LayoutInflaterService);

			var layout = inflater.Inflate(Resource.Layout.IncomingCall, null);

			SetContentView(layout, new WindowManagerLayoutParams(WindowManagerTypes.SystemOverlay));
		}

		public override void OnBackPressed()
		{
			Finish();
		}
	}
}

