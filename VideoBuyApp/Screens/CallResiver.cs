
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

namespace VideoBuyApp
{

	[BroadcastReceiver]
	[IntentFilter(new[] { "android.intent.action.PHONE_STATE" })]


	public class CallResiver : BroadcastReceiver
	{
		private MediaPlayer player;
		private TelephonyManager _telephonyManager;
		public override void OnReceive (Context context, Intent intent)
		{
			string state = intent.GetStringExtra(TelephonyManager.ExtraState);
			 _telephonyManager = (TelephonyManager) context.GetSystemService(Context.TelephonyService) as TelephonyManager;
			PhoneStateListener callListener = new PhoneStateListener ();

			PhoneStateListenerFlags callStateListenerFlags = new PhoneStateListenerFlags();


			//_telephonyManager.Listen (, PhoneStateListenerFlags.CallState);
			_telephonyManager.Listen (callListener, PhoneStateListenerFlags.CallState);
			onCallStateChanged (state, null,context);
		}
	
		public  void onCallStateChanged(string state, string incomingNumber, Context _conetext) { // TODO React to incoming call. // React to incoming call. string number=incomingNumber;

			// If phone ringing
			if(state == TelephonyManager.ExtraStateRinging )
			{
				var uri = Android.Net.Uri.Parse ("http://cs535214.vk.me/u649897/videos/98aad53c00.240.mp4");
				videoPlayer (uri, _conetext);
				//Toast.MakeText(this, " Phone Is Riging ", ToastLength.Long).Show()
				//Toast.MakeText(_conetext,"phone is neither ringing nor in a call", ToastLength.Long).Show();
			}

			// If incoming call received
			if(state==TelephonyManager.ExtraStateOffhook)
			{
			}

			if(state==TelephonyManager.ExtraStateIdle)
			{			}
		}
		public void videoPlayer(Android.Net.Uri path, Context _context){
			//get current window information, and set format, set it up differently, if you need some special effects

			//getWindow().setFormat(PixelFormat.TRANSLUCENT);
			//the VideoView will hold the video

			VideoView videoHolder = new VideoView(_context);
			//MediaController is the ui control howering above the video (just like in the default youtube player).
			videoHolder.SetMediaController(new MediaController(_context));
			//assing a video file to the video holder
			//var uri = Android.Net.Uri.Parse (path);
			videoHolder.SetVideoURI(path);
			//get focus, before playing the video.
			videoHolder.RequestFocus();

			videoHolder.Start();
			}

		}
				
		 


	

}



