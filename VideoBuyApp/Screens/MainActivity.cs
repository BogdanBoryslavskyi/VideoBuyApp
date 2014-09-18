using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace VideoBuyApp
{
	[Activity (Label = "VideoBuyApp", Icon = "@drawable/icon", Theme = "@android:style/Theme.NoTitleBar")]
	public class MainActivity : Activity
	{
		protected Activity _Context;
		protected ListView _UiVideosList;
		protected VideosListAdapter _VideosListAdapter;
		public static VideoBuyDB _VideoDB;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
			_UiVideosList = FindViewById<ListView> (Resource.Id.UiVideosList);

			//FakeData data = new FakeData ();
			_VideoDB = new VideoBuyDB();
			_VideoDB.ConnectToDB ();
			_VideoDB.CreateDB ();
			_VideoDB.SelectItem ();
			_VideosListAdapter = new VideosListAdapter (this, _VideoDB.SelectItem ());
			_UiVideosList.Adapter = _VideosListAdapter;
		}
	}
	
}



