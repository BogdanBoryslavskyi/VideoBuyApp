using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace VideoBuyApp
{
	[Activity (Label = "VideoBuyApp", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{

		protected ListView _UiVideosList;
		protected VideosListAdapter _VideosListAdapter;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			_UiVideosList = FindViewById<ListView> (Resource.Id.UiVideosList);

			VideoItem[] items = new VideoItem[9];
			items [0] = new VideoItem{ _VideoId = 1, _VideoName = "Video Title 1", _VideoPrice = 20.15m };
			items [1] = new VideoItem{ _VideoId = 2, _VideoName = "Video Title 2", _VideoPrice = 20.15m };
			items [2] = new VideoItem{ _VideoId = 3, _VideoName = "Video Title 3", _VideoPrice = 20.15m };
			items [3] = new VideoItem{ _VideoId = 4, _VideoName = "Video Title 4", _VideoPrice = 20.15m };
			items [4] = new VideoItem{ _VideoId = 5, _VideoName = "Video Title 5", _VideoPrice = 20.15m };
			items [5] = new VideoItem{ _VideoId = 6, _VideoName = "Video Title 6", _VideoPrice = 20.15m };
			items [6] = new VideoItem{ _VideoId = 7, _VideoName = "Video Title 7", _VideoPrice = 20.15m };
			items [7] = new VideoItem{ _VideoId = 8, _VideoName = "Video Title 8", _VideoPrice = 20.15m };
			items [8] = new VideoItem{ _VideoId = 9, _VideoName = "Video Title 9", _VideoPrice = 20.15m };

			_VideosListAdapter = new VideosListAdapter (this, items);
			_UiVideosList.Adapter = _VideosListAdapter;
		}
	}
}


