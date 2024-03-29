﻿using System;
using Android.Widget;
using Android.Content;
using Android.Views;
using Android.App;

namespace VideoBuyApp
{
	public class VideosListAdapter : BaseAdapter
	{

		protected Activity _Context;
		protected VideoItem[] _VideoItems;

		public VideosListAdapter (Activity context, VideoItem[] videoItems)
		{
			_Context = context;
			_VideoItems = videoItems;
		}

		public override Java.Lang.Object GetItem (int position)
		{
			return null;
		}

		public override long GetItemId (int position)
		{
			return _VideoItems [position]._VideoId;
		}

		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			View view = convertView; 

			if (view == null) 
				view = _Context.LayoutInflater.Inflate (Resource.Layout.VideoListItem, null);
				
			view.FindViewById<TextView> (Resource.Id.UiVideoTitle).Text = _VideoItems [position]._VideoName;
			view.FindViewById<TextView> (Resource.Id.UiVideoPrice).Text = _VideoItems [position]._VideoPrice.ToString();

			var UiPreviewAndBuy = view.FindViewById<Button> (Resource.Id.UiPreviewAndBuyButton);
			UiPreviewAndBuy.Click += delegate {
				//To Do
				Intent PrevBuyActivity = new Intent (_Context, typeof(PreviewBuyActivity));
				PrevBuyActivity.PutExtra("VideoLink",_VideoItems [position]._VideoLink);
				_Context.StartActivity (PrevBuyActivity);
				Toast.MakeText(_Context, "PreviewAndBuy", ToastLength.Short);

			};
			var UiVideoIcon = view.FindViewById<ImageView> (Resource.Id.UiVideoIcon);
			UiVideoIcon.Click += delegate {
				//To Do
				var uri = Android.Net.Uri.Parse (_VideoItems [position]._VideoLink);
				var intent = new Intent (Intent.ActionView, uri);
				_Context.StartActivity (intent);
				Toast.MakeText(_Context, "VideoIcon", ToastLength.Short);
			};
			return view;
		}

		public override int Count {
			get {
				return _VideoItems.Length;
			}
		}
			


	}
}

