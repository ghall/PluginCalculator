using System;
using PluginCalculator.Core.NativePlugins;

namespace PluginCalculator.Droid.NativePlugins
{
    public class DroidLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}