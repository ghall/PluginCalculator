using System;
using PluginCalculator.Core.NativePlugins;

namespace PluginCalculator.Droid.NativePlugins
{
    public class DroidLogger : ILogger
    {
        public void Log(object sender, string message)
        {
			Android.Util.Log.Debug (null != sender ? sender.GetType ().Name : "PluginCalculator.Droid", message);
        }
    }
}