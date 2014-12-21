using System;
using PluginCalculator.Core.Repositories.Result;
using NUnit.Framework;

namespace PluginCalculator.Core.IntegrationTests.Repositories.Result
{
	public abstract class BaseResultRepositoryTests
	{
		public abstract IResultRepository GetTarget ();

		[Test]
		public void AdditionTest() {
			var result = GetTarget ().Execute ("1+1");
			Assert.AreEqual ("2", result);
		}

		[Test]
		public void SubtractionTest() {
			var result = GetTarget ().Execute ("2-1");
			Assert.AreEqual ("1", result);
		}

		[Test]
		public void MultiplicationTest() {
			var result = GetTarget ().Execute ("2*2");
			Assert.AreEqual ("4", result);
		}

		[Test]
		public void DivisionTest() {
			var result = GetTarget ().Execute ("3/2");
			Assert.AreEqual ("1.5", result);
		}
	}
}

