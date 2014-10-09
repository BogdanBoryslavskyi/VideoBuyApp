
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
using Android.Media;

namespace VideoBuyApp
{
	[Activity (Label = "CallActivity")]			
	public class CallActivity : Activity, MediaPlayer.IOnPreparedListener, ISurfaceHolderCallback
	{
		MediaPlayer player;
		VideoView videoView;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.IncomingCall);
			// Create your application here
			videoView = FindViewById<VideoView> (Resource.Id.incomingVideo);
			play("test.mp4");
		}
		void play(string fullPath)
		{
			ISurfaceHolder holder = videoView.Holder;
			holder.SetType (SurfaceType.PushBuffers);
			holder.AddCallback( this );
			player = new  MediaPlayer ();
			Android.Content.Res.AssetFileDescriptor afd = this.Assets.OpenFd(fullPath);
			if  (afd != null )
			{
				player.SetDataSource (afd.FileDescriptor, afd.StartOffset, afd.Length);
				player.Prepare ();
				player.Start ();
			}
		}

		public void SurfaceCreated(ISurfaceHolder holder)
		{
			Console.WriteLine("SurfaceCreated");
			player.SetDisplay(holder);
		}
		public void SurfaceDestroyed(ISurfaceHolder holder)
		{
			Console.WriteLine("SurfaceDestroyed");
		}
		public void SurfaceChanged(ISurfaceHolder holder, Android.Graphics.Format format, int w, int h)
		{
			Console.WriteLine("SurfaceChanged");
		}
		public void OnPrepared(MediaPlayer player)
		{

		}
	}

}

