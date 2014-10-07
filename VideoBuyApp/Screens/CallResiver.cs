
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
using Android.Telephony;
using Android.Media;
using Android.Graphics;

namespace VideoBuyApp
{

	[BroadcastReceiver]
	[IntentFilter(new[] { "android.intent.action.PHONE_STATE" })]


	public class CallResiver : BroadcastReceiver
	{
		protected Activity _Context;
		private ViewGroup screen;
		private MediaPlayer player;
		private TelephonyManager _telephonyManager;
		public ImageView _image;


		public override void OnReceive (Context context, Intent intent)
		{
		
			string state = intent.GetStringExtra(TelephonyManager.ExtraState);
			 _telephonyManager = (TelephonyManager) context.GetSystemService(Context.TelephonyService) as TelephonyManager;
			PhoneStateListener callListener = new PhoneStateListener ();

			PhoneStateListenerFlags callStateListenerFlags = new PhoneStateListenerFlags();


			//_telephonyManager.Listen (, PhoneStateListenerFlags.CallState);
			_telephonyManager.Listen (callListener, PhoneStateListenerFlags.CallState);
			onCallStateChanged (state, null, context);
		}
	
		public  void onCallStateChanged(string state, string incomingNumber, Context _context) { // TODO React to incoming call. // React to incoming call. string number=incomingNumber;
			//screen =_Context.FindViewById<ViewGroup>(Resource.Id.IncomingCall);
			// If phone ringing
			if(state == TelephonyManager.ExtraStateRinging )
			{

			
				var i = new Intent(_context, typeof (PlayerSevise));
				i.PutExtra(PlayerSevise.CommandExtraName, PlayerSevise.PlayCommand);
				_context.StartService (i);



				//Toast.MakeText(this, " Phone Is Riging ", ToastLength.Long).Show()
				Toast.MakeText(_context,"phone is neither ringing nor in a call", ToastLength.Long).Show();

				}
			if (state == TelephonyManager.ExtraStateIdle) {
				var i = new Intent(_context, typeof (PlayerSevise));
				i.PutExtra(PlayerSevise.CommandExtraName, PlayerSevise.StopCommand);
				_context.StartService (i);
			}

			if (state == TelephonyManager.ExtraStateOffhook) {
				var i = new Intent(_context, typeof (PlayerSevise));
				i.PutExtra(PlayerSevise.CommandExtraName, PlayerSevise.StopCommand);
				_context.StartService (i);
			}
				
		 


	
	}
}
}



