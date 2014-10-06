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

	public class IncomingScreen : Activity
	{
		public ImageView _image;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.IncomingCall);
			_image = (ImageView)FindViewById (Resource.Id.imageView1);

			_image.SetImageResource (Resource.Drawable.blue_bg);
		}
}
}



