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
	public class PlayerSevise:Service
	{
		public const string PlayCommand = "Play";
		public const string StopCommand = "Stop";
		public const string CommandExtraName = "Command";
		private const int VideoPlayingNotification = 1;
		private ISurfaceHolder holder;
		private Window _screen;
		private MediaPlayer _player;
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


			//LayoutInflater inflater = new LayoutInflater();
			View view = inflater.Inflate(Resource.Layout.IncomingCall,null);
			//View view = Context.LayoutInflaterService (Resource.Layout.IncomingScreen);
			var videotest = view.FindViewById<VideoView> (Resource.Id.incomingVideo);

			//var _surface = FindViewById<SurfaceView>(Resource.Id.incomingVideo);
			if (_player != null && _player.IsPlaying)
				return;


			ISurfaceHolder holder = videotest.Holder;



			holder.SetType (SurfaceType.Normal);
			//holder.AddCallback( this );
			_player = MediaPlayer.Create(this, Resource.Raw.test);
			_player.SetScreenOnWhilePlaying(true);
			//_player.SetDisplay (holder);
			_player.SetDisplay()
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

