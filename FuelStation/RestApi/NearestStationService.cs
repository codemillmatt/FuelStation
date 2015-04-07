using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

using Connectivity.Plugin;

namespace FuelStation
{
	public class NearestStationService
	{
		public NearestStationService ()
		{
		}

		private const string API_KEY = "hvQF7TpYFEV2xlpFegJIvF1HoUWgOyCLUOX86bzX";
		private const string NEAREST_BASE_URL = "http://developer.nrel.gov/api/alt-fuel-stations/v1/nearest";

		string urlPath (string location)
		{
			return string.Format ("{0}?format=json&api_key={1}&location={2}", NEAREST_BASE_URL, API_KEY, location);
		}

		public async Task<List<StationInfo>> GetNearestStations (string location)
		{			
			if (CrossConnectivity.Current.IsConnected) {				
				using (var client = new HttpClient ()) {
					client.BaseAddress = new Uri (urlPath (location));
					client.DefaultRequestHeaders.Accept.Clear ();
					client.DefaultRequestHeaders.Accept.Add (
						new MediaTypeWithQualityHeaderValue ("application/json"));

					var response = await client.GetAsync ("");

					response.EnsureSuccessStatusCode ();

					var content = await response.Content.ReadAsStringAsync ();

					var nearestStations = new List<StationInfo> ();

					await Task.Run (async() => {
						var nsr = JsonConvert.DeserializeObject<NearestStationResponse> (content);

						foreach (var item in nsr.fuel_stations) {
							var si = new StationInfo {
								StationName = item.station_name,
								State = item.state,
								StationID = item.id,
								Address = item.street_address,
								City = item.city,
								Zip = item.zip
							};

							nearestStations.Add (si);
						}						
					});
					
					return nearestStations;
				}
			} else {
				throw new InternetNotReachableException ();
			}
		}
			
	}
}

