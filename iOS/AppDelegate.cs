using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace FuelStation.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			App.SetPlatform (new iOSSqlitePlatform ());
			App.DataManager.Database.SetupDatabaseAsync ();

			global::Xamarin.Forms.Forms.Init ();

			LoadApplication (new App ());

			return base.FinishedLaunching (app, options);
		}
	}
}

