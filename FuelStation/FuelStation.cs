using System;

using Xamarin.Forms;

namespace FuelStation
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application
			MainPage = new NavigationPage (new FuelStationsListPage ());
		}

		static FuelStationDataManager _dataMgr;

		public static void SetPlatform (IPlatform osPlatform)
		{
			_dataMgr = new FuelStationDataManager (osPlatform);
		}

		public static FuelStationDataManager DataManager 
		{
			get 
			{
				return _dataMgr;
			}
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

