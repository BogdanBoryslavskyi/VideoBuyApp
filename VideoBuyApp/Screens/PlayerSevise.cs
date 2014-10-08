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
		private VideoView _tv;
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
			//LayoutInflater inflater = new LayoutInflater();
			var inflater = Application.Context.GetSystemService(Context.LayoutInflaterService) as LayoutInflater;
			View view = inflater.Inflate(Resource.Layout.IncomingCall,null);
			_tv = view.FindViewById<VideoView> (Resource.Id.incomingVideo);
			play (Resource.Raw.test);
			/*

			/
			//var videotest = new VideoView (this);
			//var _surface = FindViewById<SurfaceView>(Resource.Id.incomingVideo);
			if (_player != null && _player.IsPlaying)
				return;
			//createOverlay ();	
			//ISurfaceHolder holder = tv.Holder;

			//MediaController _media = new MediaController (inflater);
			//holder.SetType (SurfaceType.Normal);
			//holder.AddCallback();

			_player = MediaPlayer.Create(this, Resource.Raw.test);
			//_player.SetDisplay(holder);

			_player.Prepared += new EventHandler(mediaPlayer_Prepared);
			//_player.PrepareAsync();

			//_player.SetScreenOnWhilePlaying(true);
			//_player.SetDisplay (createOverlay());
			//_player.SetDisplay (holder);
			//_player.Prepared += new EventHandler(mediaPlayer_Prepared);
			//_player.PrepareAsync();
			_player.Start();

			/*_player.Completion += (sender, e) => StopSelf();

			var notificationService = (NotificationManager) GetSystemService(NotificationService);
			var notification = new Notification(Resource.Drawable.Icon, "Music started",
				Java.Lang.JavaSystem.CurrentTimeMillis());
			notification.Flags = NotificationFlags.NoClear;

			var notificationIntent = PendingIntent.GetActivity(this, 0, new Intent(this, typeof(CallResiver)), 0);
			//notification.SetLatestEventInfo(this, "Now Playing", "Nine Inch Nails - 7 Ghosts I", notificationIntent);

			//notificationService.Notify(MusicPlayingNotification, notification);
			notificationService.Notify (VideoPlayingNotification, notification);
			*/
		}
		private ISurfaceHolder createOverlay() {

			var rl = new LinearLayout (this);

			// set layout parameters
			var layoutParams = new LinearLayout.LayoutParams (ViewGroup.LayoutParams.FillParent, ViewGroup.LayoutParams.FillParent);
			rl.LayoutParameters = layoutParams;
			var inflater = Application.Context.GetSystemService(Context.LayoutInflaterService) as LayoutInflater;
			View view = inflater.Inflate(Resource.Layout.IncomingCall,null);
			var tv = view.FindViewById<VideoView> (Resource.Id.incomingVideo);
			var surfaceOrientation = SurfaceOrientation.Rotation0;
			//var surfaceOrientation = WindowManager.DefaultDisplay.Rotation;
			// create layout based upon orientation
			LinearLayout.LayoutParams tvLayoutParams;


			if (surfaceOrientation == SurfaceOrientation.Rotation0 || surfaceOrientation == SurfaceOrientation.Rotation180) {
				tvLayoutParams = new LinearLayout.LayoutParams (ViewGroup.LayoutParams.FillParent, ViewGroup.LayoutParams.WrapContent);
			} else {
				tvLayoutParams = new LinearLayout.LayoutParams (ViewGroup.LayoutParams.FillParent, ViewGroup.LayoutParams.WrapContent);
				tvLayoutParams.LeftMargin = 100;
				tvLayoutParams.TopMargin = 100;
				// create TextView control}
			
			// Create System overlay video
			/*WindowManagerLayoutParams param = new WindowManagerLayoutParams (
				                              WindowManagerFlags.Fullscreen|WindowManagerFlags.NotFocusable |
			                                  WindowManagerFlags.NotTouchModal);
			param.Gravity = GravityFlags.Bottom;
			var inflater = Application.Context.GetSystemService(Context.LayoutInflaterService) as LayoutInflater;
			View view = inflater.Inflate(Resource.Layout.IncomingCall,null);

			//WindowManagerLayoutParams wm = (WindowManagerLayoutParams)GetSystemService (WindowService); 
			Window wm = (Window)GetSystemService (WindowService);
			wm.AddContentView (mOverlay, param);
			var videotest = view.FindViewById<VideoView> (Resource.Id.incomingVideo);
			//wm.addView(mOverlay, params);*/

		}
			//var tv = new VideoView (this);

			// set TextView's LayoutParameters
			tv.LayoutParameters = layoutParams;

			// add TextView to the layout
			//var tv = view.FindViewById<VideoView> (Resource.Id.incomingVideo);
			//rl.AddView (tv);
			//_holder = tv.Holder;
			return tv.Holder;
		}


	

	void play(int fullPath)
	{
			ISurfaceHolder holder = _tv.Holder;
		holder.SetType (SurfaceType.PushBuffers);
		// Necesito saber cuando la superficie esta creada para poder asignar el Display al MediaPlayer
		holder.AddCallback (this);
			_player = new MediaPlayer();

		Android.Content.Res.AssetFileDescriptor afd = this.Assets.OpenFd("test.mp4");
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

