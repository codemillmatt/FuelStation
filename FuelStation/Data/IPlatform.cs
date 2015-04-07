using System;
using SQLite.Net.Interop;

namespace FuelStation
{
	public interface IPlatform
	{
		string DBPath { get; }
		ISQLitePlatform OSPlatform { get; }
	}
}

