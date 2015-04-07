using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;
using Connectivity.Plugin;

namespace FuelStation
{
	public class FuelStationsListPage : ContentPage
	{
		ListView _stationsListView;
		ObservableCollection<StationInfo> _stationList;
		SearchBar _searchBar;

		bool _isConnected;

		public FuelStationsListPage ()
		{
			Title = "Fuel Stations";
		
			_stationList = new ObservableCollection<StationInfo> ();

			_stationsListView = new ListView {
				ItemsSource = _stationList,
				RowHeight = 40
			};

			_stationsListView.ItemTemplate = new DataTemplate (typeof(TextCell)) { 
				Bindings = {
					{ TextCell.TextProperty, new Binding ("StationName") },
					{ TextCell.DetailProperty, new Binding ("CityState") }
				}
			};
					
			_stationsListView.ItemTapped += async (sender, e) => {				
				_stationsListView.SelectedItem = null;

				var station = e.Item as StationInfo;

				var fsip = new FuelStationInfoPage (station);
				await Navigation.PushAsync (fsip);
			};

			_searchBar = new SearchBar ();
			_searchBar.SearchButtonPressed += (sender, e) => LoadStations (_searchBar.Text);

			Content = new StackLayout { 
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = {
					_searchBar,
					_stationsListView
				}
			};

		}

		private async Task LoadStations (string location)
		{			
			_stationList.Clear ();
		
			await LoadStationsFromNetwork (location);

			if (!_isConnected) {
				var searchedStations = await App.DataManager.Database.GetStationsNear (location);

				foreach (var item in searchedStations) {
					_stationList.Add (item);
				}
			}
		
			Title = _isConnected ? "Fuel Stations - C" : "Fuel Stations - N";
		}

		private async Task LoadStationsFromNetwork (string location)
		{
			try {
				var searchedStations = await new NearestStationService ().GetNearestStations (location);

				foreach (var item in searchedStations) {
					_stationList.Add (item);
				}

				await App.DataManager.Database.SaveStations (_stationList);

				_isConnected = true;

			} catch (InternetNotReachableException) {
				_isConnected = false;
			}
		}

			
	}
}
	