﻿using System;
using System.Collections.Generic;

namespace VideoBuyApp
{
	public class FakeData
	{
		private readonly List<VideoItem> _allVideos = new List<VideoItem> () {
			new VideoItem {
				_VideoId = 1,
				_VideoName = "Video Title 1",
				_VideoPrice = 20.15m,
				_VideoLink = "http://cs12603.vk.me/u59401146/videos/eeaad7abf7.240.mp4"
			},
			new VideoItem {
				_VideoId = 2,
				_VideoName = "Video Title 2",
				_VideoPrice = 20.15m,
				_VideoLink = "http://cs529200.vk.me/u206423731/videos/614de1f80d.240.mp4"
			},
			new VideoItem {
				_VideoId = 3,
				_VideoName = "Video Title 3",
				_VideoPrice = 20.15m,
				_VideoLink = "http://cs505609.vk.me/u86338325/videos/efc6bcf4ed.240.mp4"
			},
			new VideoItem {
				_VideoId = 4,
				_VideoName = "Video Title 4",
				_VideoPrice = 20.15m,
				_VideoLink = "http://cs510103.vk.me/u72786884/videos/d657a43517.240.mp4"
			},
			new VideoItem {
				_VideoId = 5,
				_VideoName = "Video Title 5",
				_VideoPrice = 20.15m,
				_VideoLink = "http://cs12358.vk.me/u62315385/videos/588e1decdf.flv"
			},
			new VideoItem {
				_VideoId = 6,
				_VideoName = "Video Title 6",
				_VideoPrice = 20.15m,
				_VideoLink = "http://cs12860.vk.me/u63560660/videos/4fb658bc1b.240.mp4"
			},
			new VideoItem {
				_VideoId = 7,
				_VideoName = "Video Title 7",
				_VideoPrice = 20.15m,
				_VideoLink = "http://cs13084.vk.me/u26471852/videos/07287b9c12.240.mp4"
			},
			new VideoItem {
				_VideoId = 8,
				_VideoName = "Video Title 8",
				_VideoPrice = 20.15m,
				_VideoLink = "http://cs12752.vk.me/u85132585/videos/68a785be96.240.mp4"
			},
			new VideoItem {
				_VideoId = 9,
				_VideoName = "Video Title 9",
				_VideoPrice = 20.15m,
				_VideoLink = "http://cs12752.vk.me/u85132585/videos/68a785be96.240.mp4"
			},
		};

		public List<VideoItem> allVideos {
			get {
				return _allVideos;
			}
		}
	}
}

