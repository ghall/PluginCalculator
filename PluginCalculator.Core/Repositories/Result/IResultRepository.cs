using System;

namespace PluginCalculator.Core.Repositories.Result
{
	public interface IResultRepository
	{
		/// <summary>
		/// Execute the specified mathString to get the result. Must use *,/,+,- operators.
		/// </summary>
		/// <param name="mathString">Math string.</param>
		string Execute(string mathString);
	}
}