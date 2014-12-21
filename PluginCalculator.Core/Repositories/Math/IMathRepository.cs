using System;

namespace PluginCalculator.Core.Repositories.Math
{
	public interface IMathRepository {

		/// <summary>
		/// Takes the first part of an equation, the operator, and the second part, combines and returns the equation in string format using +,-,/,* operators.
		/// </summary>
		/// <returns>The equation.</returns>
		/// <param name="first">First part of the equation</param>
		/// <param name="operation">Operation to be performed</param>
		/// <param name="second">Second part of the equation</param>
		string CreateEquation(string first, MathOperation operation, string second);

		/// <summary>
		/// Determines whether this instance is valid for the specified equation parts.
		/// </summary>
		/// <returns><c>Valid</c> if valid, <c>DivisionByZero</c> if attempting to perform division by zero.</returns>
		/// <param name="first">First.</param>
		/// <param name="operation">Operation.</param>
		/// <param name="second">Second.</param>
		EquationValidity IsValid(string first, MathOperation operation, string second);
	}	
}