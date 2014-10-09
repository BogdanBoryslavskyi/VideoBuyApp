using System;

using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Telephony;
using Android.Media;
using Android.Graphics;



namespace VideoBuyApp
{
	[Service]
	public class PlayerSevise:Service, MediaPlayer.IOnPreparedListener,ISurfaceHolderCallback
	{
		public const string PlayCommand = "Play";
		public const string StopCommand = "Stop";
		public const string CommandExtraName = "Command";
		private const int VideoPlayingNotification = 1;
		private MediaPlayer _player;
		private LinearLayout mOverlay;
		private SurfaceView _tv;
		LinearLayout.LayoutParams _layoutParamsPortrait;
		LinearLayout.LayoutParams _layoutParamsLandscape;
		ISurfaceHolder _holder; 


		public override IBinder OnBind(Intent intent)
		{

			return null;
		}
		public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
		{

			string command = intent.GetStringExtra(CommandExtraName);

			switch (command)
			{
			case PlayCommand:
				startPlaying();

				break;
			case StopCommand:
				stopPlaying();

				break;
			default:
				return base.OnStartCommand(intent, flags, startId);
			}

			return StartCommandResult.Sticky;
		}

		private void startPlaying()
		{

			var inflater = Application.Context.GetSystemService(Context.LayoutInflaterService) as LayoutInflater;
			View view = inflater.Inflate (Resource.Id.incomingVideo,null,false);
			View _container = inflater.Inflate (Resource.Layout.IncomingCall, null, false);
		
			//View view = inflater.Inflate(Resource.Layout.IncomingCall,null);
			_tv = view.FindViewById<SurfaceView> (Resource.Id.incomingVideo);

			play ("test.mp4");
		

			var notificationService = (NotificationManager) GetSystemService(NotificationService);
			var notification = new Notification(Resource.Drawable.Icon, "Music started",
				Java.Lang.JavaSystem.CurrentTimeMillis());
			notification.Flags = NotificationFlags.NoClear;

			var notificationIntent = PendingIntent.GetActivity(this, 0, new Intent(this, typeof(CallActivity)), 0);

			notificationService.Notify (VideoPlayingNotification, notification);

		}
	
	

		void play(string fullPath)
	{
			ISurfaceHolder holder = _tv.Holder;
		holder.SetType (SurfaceType.PushBuffers);
		// Necesito saber cuando la superficie esta creada para poder asignar el Display al MediaPlayer
		holder.AddCallback (this);
			_player = new MediaPlayer();

			Android.Content.Res.AssetFileDescriptor afd = this.Assets.OpenFd(fullPath);
		if (afd != null)
		{
			_player.SetDataSource(afd.FileDescriptor, afd.StartOffset, afd.Length);
			_player.Prepare ();
			_player.Start();
		}
	}

	public void SurfaceCreated (ISurfaceHolder holder)
	{
		Console.WriteLine ("SurfaceCreated");
		_player.SetDisplay(holder);
	}

	public void SurfaceDestroyed (ISurfaceHolder holder)
	{
		Console.WriteLine ("SurfaceDestroyed");
	}

	public void SurfaceChanged (ISurfaceHolder holder, Android.Graphics.Format format, int w, int h)
	{
		Console.WriteLine ("SurfaceChanged");
	}

	public void OnPrepared(MediaPlayer mp) {
		mp.Start();
	}
		private void stopPlaying()
		{
			if (_player == null || !_player.IsPlaying)
				return;

			_player.Stop();
			_player.Release();
			_player = null;

			var notificationService = (NotificationManager)GetSystemService(NotificationService);
			notificationService.Cancel(VideoPlayingNotification);
		}
		/*public void SurfaceCreated(ISurfaceHolder holder)
		{

			try
			{
				_player.SetDisplay(holder);
				//player.SetDataSource("http://cs535214.vk.me/u649897/videos/98aad53c00.240.mp4");
				_player.Prepared += new EventHandler(mediaPlayer_Prepared);
				_player.PrepareAsync();
			}
			catch (System.Exception e)
			{
				Android.Util.Log.Debug("MEDIA_PLAYER", e.Message);
				Toast.MakeText(this, e.Message, ToastLength.Short).Show();
			}
		}
		void mediaPlayer_Prepared(object sender, EventArgs e)
		{
			_player.Start();
		}


		public void SurfaceDestroyed(ISurfaceHolder holder)
		{

			//_player.Release ();
		}
		public void SurfaceChanged(ISurfaceHolder holder, Android.Graphics.Format format, int w, int h)
		{
			Console.WriteLine("SurfaceChanged");
		}*/
		void mediaPlayer_Prepared(object sender, EventArgs e)
		{
			_player.Start();
		}

	}
}

