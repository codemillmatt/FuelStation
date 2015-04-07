using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using SQLite.Net.Async;
using SQLite.Net;
using SQLite;	

namespace FuelStation
{
	public class FuelDBConnection : SQLiteAsyncConnection
	{
		public FuelDBConnection (Func<SQLiteConnectionWithLock> connFunc) : base(connFunc)
		{
			
		}
			
		public async Task SetupDatabaseAsync()
		{
			await CreateTableAsync<StationInfo> ().ConfigureAwait (false);
		}

		public async Task<IList<StationInfo>> GetStationsNear(string location) 
		{			
			var cityStateSplit = location.Split (new Char[]{ ',' });
			var city = cityStateSplit [0].Trim ();
			var state = cityStateSplit [1].Trim ();

			return await Table<StationInfo> ().Where (si => si.City.Contains (city)
				&& si.State.Contains (state)).ToListAsync ().ConfigureAwait (false);			
		}

		public async Task SaveStations(IList<StationInfo> stations) 
		{
			foreach (var item in stations) {
				int stationId = item.StationID;

				item.LastUpdated = DateTime.Now;

				var dbRecord = await Table<StationInfo> ().Where (si => si.StationID == stationId).FirstOrDefaultAsync ().ConfigureAwait (false);

				if (dbRecord == null) {					
					await InsertAsync (item).ConfigureAwait (false);
				}
				else {
					await UpdateAsync (item).ConfigureAwait (false);
				}
			}
		}
	}
}

