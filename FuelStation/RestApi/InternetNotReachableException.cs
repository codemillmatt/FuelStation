using System;

namespace FuelStation
{
	public class InternetNotReachableException : Exception
	{
		public InternetNotReachableException () : base("Can not communicate to the internet")
		{
		}
	}
}

