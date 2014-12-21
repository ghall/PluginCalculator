using System;
using PluginCalculator.Core.NativePlugins;

namespace PluginCalculator.Touch.NativePlugins
{
	public class TouchLogger : ILogger
	{

		public void Log (string message)
		{
			Console.WriteLine (message);
		}


	}
}