
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace VideoBuyApp
{
	[Activity (Label = "PreviewBuyActivity")]			
	public class PreviewBuyActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Preview_Buy);
			String Test;
			int Id;
			TextView IdTest = FindViewById<TextView> (Resource.Id.UiVideoTitle);
			IdTest = new TextView (this);
			Test = Intent.GetStringExtra("VideoName");
			IdTest.Text = Test;
						// Create your application here
		}
	}
}

