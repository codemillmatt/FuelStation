using System;
using System.Collections.Generic;

namespace FuelStation
{
	public class FuelStationRecord {

		public int id {
			get;
			set;
		}

		public string station_name {
			get;
			set;
		}

		public string street_address {
			get;
			set;
		}

		public string city {
			get;
			set;
		}

		public string state {
			get;
			set;
		}

		public string zip {
			get;
			set;
		}
	}

	public class NearestStationResponse {

		public int total_results {
			get;
			set;
		}

		public int offset {
			get;
			set;
		}

		public string station_locator_url {
			get;
			set;
		}

		public decimal latitude {
			get;
			set;
		}

		public decimal longitude {
			get;
			set;
		}	

		public IList<FuelStationRecord> fuel_stations {
			get;
			set;
		}
	}
}

