using System;

namespace PluginCalculator.Core.Repositories.Math
{
	public interface IMathRepository {
		string CreateEquation(string first, MathOperation operation, string second);
		EquationValidity IsValid(string first, MathOperation operation, string second);
	}	
}