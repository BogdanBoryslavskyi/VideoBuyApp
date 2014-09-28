
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

namespace VideoBuyApp
{
	[Activity (Label = "My Videos")]			
	public class AcountVideoList : Activity
	{
		protected ListView _UiVideosList;
		protected VideosListAdapter _VideosListAdapter;
		public static VideoBuyDB _VideoDB;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.AcountVideoList);
			_UiVideosList = FindViewById<ListView> (Resource.Id.UiVideosList);

			FakeData data = new FakeData ();
			_VideoDB = new VideoBuyDB ();
			_VideoDB.ConnectToDB ("VideoBuyDB.db3");

			_VideosListAdapter = new VideosListAdapter (this, _VideoDB.SelectBDItems ().ToArray ());
			_UiVideosList.Adapter = _VideosListAdapter;

		}
	}
}

