using System;

namespace PluginCalculator.Core.NativePlugins
{
	public interface IDialogPlugin
	{
		void ShowMessage(string title, string message, string button);
	}
}