using System;

namespace PluginCalculator.Core.NativePlugins
{
	public interface ILogger
	{
		void Log(object sender, string message);
	}
}