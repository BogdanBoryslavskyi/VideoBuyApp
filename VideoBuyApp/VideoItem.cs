using System;

namespace VideoBuyApp
{
	public class VideoItem
	{
		public int _VideoId{ get; set; }
		public string _VideoName{ get; set; }
		public string _VideoIcon{ get; set; }
		public string _VideoLink{ get; set; }
		public decimal _VideoPrice{ get; set; }
		public decimal _VideoTiming{ get; set; }
		public int _Repeat { get; set; }
	}
}

