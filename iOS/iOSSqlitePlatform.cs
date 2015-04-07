using System;
using FuelStation;
using System.IO;
using SQLite.Net.Interop;

namespace FuelStation.iOS
{
	public class iOSSqlitePlatform : IPlatform
	{
		#region IPlatform implementation

		public string DBPath {
			get {
				return Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.Personal), "stations.db3");
			}
		}

		public ISQLitePlatform OSPlatform {
			get {
				return new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS ();
			}
		}

		#endregion

		public iOSSqlitePlatform ()
		{
		}
	}
}

