using System;
using SQLite.Net;

namespace FuelStation
{
	public class FuelStationDataManager
	{
		public FuelStationDataManager (IPlatform platform)
		{
			_platform = platform;
		}

		private IPlatform _platform;
		private FuelDBConnection _conn;

		public FuelDBConnection Database {
			get {
				if (_conn == null) {
					_conn = new FuelDBConnection (() =>
						new SQLiteConnectionWithLock (_platform.OSPlatform,
						new SQLiteConnectionString (_platform.DBPath, true)));

				}

				return _conn;
			}
		}
	}
}

