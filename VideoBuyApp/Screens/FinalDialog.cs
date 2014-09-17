
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
	[Activity (Label = "FinalDialog", Theme = "@android:style/Theme.NoTitleBar")]			
	public class FinalDialog : Activity
	{	
		RadioButton bSMS;
		RadioButton bEmail;
		RadioGroup group;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.FinalDialog);
			bSMS = FindViewById<RadioButton> (Resource.Id.radioButtonSMS);
			bEmail = FindViewById<RadioButton> (Resource.Id.radioButtonEmail);
			group = FindViewById<RadioGroup> (Resource.Id.radioGroup1);
			group.ClearCheck ();
			bSMS.Click += new EventHandler(bSMS_Click);
			bEmail.Click += new EventHandler (bEmail_Click);
		}

		void bSMS_Click(object sender, EventArgs e)
		{	String link = Intent.GetStringExtra ("Extra_Link");
			var intent = new Intent(Intent.ActionView, Android.Net.Uri.Parse("sms:"));
			intent.PutExtra("sms_body", link);
			StartActivity(intent);

		}

		void bEmail_Click(object sender, EventArgs e)
		{
			String link = Intent.GetStringExtra ("Extra_Link");
			var intent = new Intent(Intent.ActionView,
				Android.Net.Uri.Parse("mailto:"));
			intent.PutExtra("body", link);
			StartActivity(intent);

		}
	}
}

