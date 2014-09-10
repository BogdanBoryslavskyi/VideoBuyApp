
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
using Android.Graphics;
using Android.Util;



namespace VideoBuyApp
{
	[Activity (Label = "PreviewBuyActivity")]			
	public class PreviewBuyActivity : Activity, ISurfaceHolderCallback
	{
		MediaPlayer player;
		Button Buy;
		String VideoLink;
		EditText VideoText;
		//VideoView vid;
		protected override void OnCreate (Bundle bundle)
		{

			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Preview_Buy);
			Buy = FindViewById<Button> (Resource.Id.bBuy);
			//int Id;
			//TextView IdTest = (TextView)FindViewById (Resource.Id.UiVideoTitleBuy);
			VideoText = FindViewById<EditText> (Resource.Id.MassageField);
			VideoView vid = FindViewById<VideoView>(Resource.Id.videoPlayer);
			VideoLink = "http://cs535214.vk.me/u649897/videos/98aad53c00.240.mp4";
			//String Path = "http://cs535214.vk.me/u649897/videos/98aad53c00.240.mp4";  

			vid.Click+= delegate {
				 
			
				var uri = Android.Net.Uri.Parse (VideoLink);
				var intent = new Intent (Intent.ActionView, uri);
				StartActivity (intent);

			};
			Buy.Click += new EventHandler(Buy_Click);
		}
	
	
		void Buy_Click(object sender, EventArgs e)
		{
			var intent = new Intent (this, typeof(FinalDialog));

			intent.PutExtra ("Extra_Link", VideoLink);
			StartActivity(intent);
		}
	

	public void SurfaceCreated(ISurfaceHolder holder)
		{
			try
			{
				player.SetDisplay(holder);
				player.SetDataSource("http://cs535214.vk.me/u649897/videos/98aad53c00.240.mp4");
				player.Prepared += new EventHandler(mediaPlayer_Prepared);
				player.PrepareAsync();
			}
			catch (System.Exception e)
			{
				Android.Util.Log.Debug("MEDIA_PLAYER", e.Message);
				Toast.MakeText(this, e.Message, ToastLength.Short).Show();
			}
		}
		void mediaPlayer_Prepared(object sender, EventArgs e)
		{
			player.Start();
		}


		public void SurfaceDestroyed(ISurfaceHolder holder)
		{
			Console.WriteLine("SurfaceDestroyed");
			player.Release ();
		}
		public void SurfaceChanged(ISurfaceHolder holder, Android.Graphics.Format format, int w, int h)
		{
			Console.WriteLine("SurfaceChanged");
		}

		}
	
}