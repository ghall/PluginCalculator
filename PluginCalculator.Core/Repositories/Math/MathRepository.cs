using System;

namespace PluginCalculator.Core.Repositories.Math
{
	public class MathRepository : IMathRepository
	{
		public MathRepository ()
		{
		}

		public string CreateEquation(string first, MathOperation operation, string second) {
			switch (operation) {
			case MathOperation.Subtraction:
				return string.Format ("{0}-{1}", first, second);
			case MathOperation.Addition:
				return string.Format ("{0}+{1}", first, second);
			case MathOperation.Division:
				return string.Format ("{0}/{1}", first, second);
			case MathOperation.Mulitiplication:
				return string.Format ("{0}*{1}", first, second);
			default:
				return null;
			}
		}

		public EquationValidity IsValid(string first, MathOperation operation, string second) {
			if (MathOperation.Division == operation && second == "0")
				return EquationValidity.DivisionByZero;

			return EquationValidity.Valid;
		}
	}
}