using System;

namespace PluginCalculator.Core.Repositories.Result
{
	public interface IResultRepository
	{
		string Execute(string mathString);
	}
}