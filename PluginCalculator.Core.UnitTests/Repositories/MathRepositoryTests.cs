using System;
using NUnit.Framework;
using PluginCalculator.Core.Repositories.Math;

namespace PluginCalculator.Core.UnitTests
{
	[TestFixture]
	public class MathRepositoryTests
	{
		private MathRepository _target;

		[SetUp]
		public void Setup() {
			_target = new MathRepository ();
		}

		[Test]
		public void CreateEquation_TestSubtraction() {
			var result = _target.CreateEquation ("1", MathOperation.Subtraction, "1");

			Assert.AreEqual ("1-1", result);
		}

		[Test]
		public void CreateEquation_TestAddition() {
			var result = _target.CreateEquation ("1", MathOperation.Addition, "1");

			Assert.AreEqual ("1+1", result);
		}

		[Test]
		public void CreateEquation_TestMultiplication() {
			var result = _target.CreateEquation ("1", MathOperation.Mulitiplication, "1");

			Assert.AreEqual ("1*1", result);
		}

		[Test]
		public void CreateEquation_TestDivision() {
			var result = _target.CreateEquation ("1", MathOperation.Division, "1");

			Assert.AreEqual ("1/1", result);
		}

		[Test]
		public void IsValid_Success() {
			var result = _target.IsValid ("1", MathOperation.Division, "1");

			Assert.AreEqual (EquationValidity.Valid, result);
		}

		[Test]
		public void IsValid_DivByZero() {
			var result = _target.IsValid ("1", MathOperation.Division, "0");

			Assert.AreEqual (EquationValidity.DivisionByZero, result);
		}
	}
}

