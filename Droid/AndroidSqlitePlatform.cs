using System;
using System.IO;

using SQLite.Net.Interop;
using SQLite.Net.Platform.XamarinAndroid;

namespace FuelStation.Droid
{
	public class AndroidSqlitePlatform : IPlatform
	{
		public AndroidSqlitePlatform ()
		{
		}

		public string DBPath {
			get { 
				return Path.Combine (Environment.GetFolderPath( Environment.SpecialFolder.Personal), "stations.db3");
			}
		}

		public ISQLitePlatform OSPlatform {
			get { 
				return new SQLitePlatformAndroid ();
			}
		}
	}
}

