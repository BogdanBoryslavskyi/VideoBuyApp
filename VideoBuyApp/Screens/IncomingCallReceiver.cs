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
	[BroadcastReceiver()]
	[IntentFilter(new[] { "android.intent.action.PHONE_STATE" })]
	public class IncomingCallReceiver : BroadcastReceiver
	{
		public override void OnReceive(Context context, Intent intent)
		{
			// ensure there is information
			if (intent.Extras != null)
			{
				// get the incoming call state
				string state = intent.GetStringExtra(TelephonyManager.ExtraState);
				var telephone = intent.GetStringExtra(TelephonyManager.ExtraIncomingNumber);
				if (string.IsNullOrEmpty(telephone))
				{
					telephone = string.Empty;
				}
				// check the current state
				if (state == TelephonyManager.ExtraStateRinging)
				{
					// read the incoming call telephone number...


					Intent i = new Intent(context, typeof(MainActivity));
					//i.PutExtra(intent);
					i.AddFlags(ActivityFlags.NewTask);
					i.PutExtra("Number", telephone);
					context.StartActivity (i);



				}
				else if (state == TelephonyManager.ExtraStateOffhook)
				{
					// incoming call answer
				}
				else if (state == TelephonyManager.ExtraStateIdle)
				{
					// incoming call end
				}
			}
		}
}
}


