using System;

using Xamarin.Forms;

namespace FuelStation
{
	public class FuelStationInfoPage : ContentPage
	{
		public FuelStationInfoPage (StationInfo fuelStation)
		{
			this.BindingContext = fuelStation;

			var stationNameLabel = new Label { HorizontalOptions = LayoutOptions.Center };
			var addressLabel = new Label { HorizontalOptions = LayoutOptions.Center };
			var cityStateLabel = new Label { HorizontalOptions = LayoutOptions.Center };
			var lastUpdatedLabel = new Label { HorizontalOptions = LayoutOptions.Center };

			stationNameLabel.SetBinding (Label.TextProperty, "StationName");
			addressLabel.SetBinding (Label.TextProperty, "Address");
			cityStateLabel.SetBinding (Label.TextProperty, "CityState");
			lastUpdatedLabel.SetBinding (Label.TextProperty, "LastUpdated");
			this.SetBinding (TitleProperty, "StationName");

			Content = new StackLayout { 
				Children = {
					stationNameLabel, addressLabel, cityStateLabel, lastUpdatedLabel
				}, VerticalOptions = LayoutOptions.Center
			};
		}
	}
}


