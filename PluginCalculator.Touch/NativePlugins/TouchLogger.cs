using System;
using PluginCalculator.Core.NativePlugins;

namespace PluginCalculator.Touch.NativePlugins
{
	public class TouchLogger : ILogger
	{

		public void Log (object sender, string message)
		{
			Console.WriteLine ("Sender: {0}, Message: {1}", null != sender ? sender.GetType ().Name : string.Empty, message);
		}


	}
}