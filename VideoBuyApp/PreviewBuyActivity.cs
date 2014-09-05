
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
	[Activity (Label = "PreviewBuyActivity")]			
	public class PreviewBuyActivity : Activity ,ISurfaceHolderCallback, MediaPlayer.IOnPreparedListener
		
	{
		VideoView videoPlay;
		MediaPlayer player;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Preview_Buy);
			String Test;
			//int Id;
			TextView IdTest = (TextView)FindViewById (Resource.Id.UiVideoTitleBuy);
			//IdTest = new TextView (this);
			Test = Intent.GetStringExtra ("VideoName");
			//Test = String.Format ("{0:0000}",null);
			IdTest.Text = Test;

			videoPlay = FindViewById<VideoView> (Resource.Id.videoPlayer);

	
			play ("https://www.youtube.com/watch?v=r6HYDMe825U");
		}

		void play(string fullPath)
		{
			VideoView videoPlay = FindViewById<VideoView> (Resource.Id.videoPlayer);
			ISurfaceHolder holder = videoPlay.Holder;
			holder.SetType (SurfaceType.PushBuffers);

			holder.AddCallback (this);
			player = new MediaPlayer();
			Android.Content.Res.AssetFileDescriptor afd = this.Assets.OpenFd(fullPath);
			player.SetOnPreparedListener(this);
			if (afd != null)
			{
				player.SetDataSource(afd.FileDescriptor, afd.StartOffset, afd.Length);
				player.Prepare ();
				player.Start();
			}
		}

		public void SurfaceCreated (ISurfaceHolder holder)
		{
			Console.WriteLine ("SurfaceCreated");
			player.SetDisplay(holder);
		}

		public void SurfaceDestroyed (ISurfaceHolder holder)
		{
			Console.WriteLine ("SurfaceDestroyed");
		}

		public void SurfaceChanged (ISurfaceHolder holder, Android.Graphics.Format format, int w, int h)
		{
			Console.WriteLine ("SurfaceChanged");
		}

						// Create your application here
		}
	
}