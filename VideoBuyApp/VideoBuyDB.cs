using System;
using System.Collections.Generic;
using System.IO;
using Mono.Data.Sqlite;
using System.Threading.Tasks;

namespace VideoBuyApp
{
	public class VideoBuyDB
	{
		protected VideoItem[] _VideoItems;
		private SqliteConnection _connection;
		private bool _FileExists;

		public bool ConnectToDB(string sdbPath){
			string dbPath = System.IO.Path.Combine ( System.Environment.GetFolderPath (System.Environment.SpecialFolder.Personal), sdbPath );
			_FileExists = System.IO.File.Exists (dbPath);
			if (!_FileExists) {
				SqliteConnection.CreateFile (dbPath);
				_FileExists = System.IO.File.Exists (dbPath);
			}

			_connection = new SqliteConnection ("Data Source=" + dbPath);
			return _FileExists;
		}

		public bool CreateDB(){
			if (_FileExists) {
				if (!TableExists ("VideoBuy", _connection)) {
					_connection.Open ();
					// This is the first time the app has run and/or that we need the DB.
					// Copy a "template" DB from your assets, or programmatically create one like this:
					var command =" CREATE TABLE IF NOT EXISTS VideoBuy (_VideoId INTEGER PRIMARY KEY NOT NULL, _VideoName ntext, _VideoLink ntext, _VideoPrice DECIMAL, _VideoTiming DECIMAL);";
					using (var c = _connection.CreateCommand ()) {
						c.CommandText = command;
						c.ExecuteNonQuery ();
					}

					_connection.Close ();
					FakeData data = new FakeData ();
					this.Insert (data.allVideos.ToArray());
				}
			}
			return _FileExists;
		}

		public bool TableExists (String tableName, SqliteConnection connection)
		{
			_connection.Open ();
			using (SqliteCommand cmd = new SqliteCommand())
			{
				//cmd.CommandType = CommandType.Text;
				cmd.Connection = connection;
				cmd.CommandText = "SELECT * FROM sqlite_master WHERE type = 'table' AND name = @name";
				cmd.Parameters.AddWithValue("@name", tableName);

				using (SqliteDataReader sqlDataReader = cmd.ExecuteReader())
				{
					if (sqlDataReader.Read ()) {
						_connection.Close ();
						return true;
					} else {
						_connection.Close ();
						return false;
					}
				}
			}
		}

		public bool Insert(VideoItem[] BDVideoItems){
			if (_FileExists) {
				_connection.Open ();

				// This is the first time the app has run and/or that we need the DB.
				// Copy a "template" DB from your assets, or programmatically create one like this:
				foreach (var item in BDVideoItems) {
					var command = "INSERT INTO VideoBuy (_VideoId, _VideoName, _VideoLink, _VideoPrice, _VideoTiming) VALUES ('" + item._VideoId + "', '" + item._VideoName + "', '" + item._VideoLink + "', '" + item._VideoPrice.ToString () + "', '" + item._VideoTiming.ToString () + "')";
					using (var c = _connection.CreateCommand ()) { 
						c.CommandText = command;
						c.ExecuteNonQuery ();
					}
				}

				_connection.Close ();
			}
			return _FileExists;
		}

		public bool Insert(VideoItem BDVideoItems){
			if (_FileExists) {
				_connection.Open ();

				// This is the first time the app has run and/or that we need the DB.
				// Copy a "template" DB from your assets, or programmatically create one like this:
				var command = "INSERT INTO VideoBuy (_VideoId, _VideoName, _VideoLink, _VideoPrice, _VideoTiming) VALUES ('" + BDVideoItems._VideoId + "', '" + BDVideoItems._VideoName + "', '" + BDVideoItems._VideoLink + "', '" + BDVideoItems._VideoPrice.ToString () + "', '" + BDVideoItems._VideoTiming.ToString () + "')";
				using (var c = _connection.CreateCommand ()) {
					c.CommandText = command;
					c.ExecuteNonQuery ();
				}

				_connection.Close ();
			}
			return _FileExists;
		}



	public List<VideoItem> SelectBDItems()

	{

		List<VideoItem> BDitems = new List<VideoItem>();

			if (_FileExists) {
				_connection.Open ();

				using (var contents = _connection.CreateCommand ()) {
					contents.CommandText = "SELECT * FROM VideoBuy ORDER BY _VideoName DESC";

					var r = contents.ExecuteReader ();
					while (r.Read ())
						BDitems.Add ( new VideoItem(){ 

							_VideoId = Convert.ToInt16(r ["_VideoId"].ToString ()), 
							_VideoName = r ["_VideoName"].ToString (), 
							_VideoLink = r ["_VideoLink"].ToString (), 
							_VideoPrice = Convert.ToInt16(r ["_VideoPrice"].ToString ()),
							_VideoTiming = Convert.ToInt16(r ["_VideoTiming"].ToString ()) } );

				}
				_connection.Close ();
				/*if( BDitems.Count > 0 )
					BDitems = BDitems.OrderBy(o=>o._EndDate).ToList();
			}*/

		}
		return BDitems;

	}


}
}




