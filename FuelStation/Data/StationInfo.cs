using System;

using SQLite.Net.Attributes;

namespace FuelStation
{
	public class StationInfo
	{
		public StationInfo ()
		{
		}

		[PrimaryKey]
		public int StationID {
			get;
			set;
		}

		public string StationName {
			get;
			set;
		}

		public string Address {
			get;
			set;
		}

		public string City {
			get;
			set;
		}

		public string State {
			get;
			set;
		}

		public string Zip {
			get;
			set;
		}

		public DateTime LastUpdated {
			get; 
			set;
		}

		[Ignore]
		public string CityState {
			get { return string.Format("{0}, {1}", City, State); }
		}
	}
}

