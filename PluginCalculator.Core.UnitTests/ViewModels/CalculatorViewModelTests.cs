using System;
using NUnit.Framework;
using PluginCalculator.Core.ViewModels;
using Cirrious.MvvmCross.Test.Core;

namespace PluginCalculator.Core.UnitTests.ViewModels
{
	[TestFixture]
	public class CalculatorViewModelTests : MvxIoCSupportingTest
	{
		private CalculatorViewModel _target;

		[SetUp]
		public void Setup() {
			base.Setup ();

			_target = new CalculatorViewModel ();
		}

		[Test]
		public void ResultField_TestProperty() {
			Assume.That (_target.ResultField, Is.EqualTo("0"));

			_target.ResultField = "7";

			Assert.AreEqual ("7", _target.ResultField);
		}

		[Test]
		public void ResultField_CanNotBeNull() {
			_target.ResultField = null;

			Assert.NotNull (_target.ResultField);
		}

		[Test]
		public void ZeroPressed_Success() {
			_target.ResultField = "1";

			_target.ZeroPressed.Execute ();

			Assert.AreEqual ("10", _target.ResultField);
		}

		[Test]
		public void ZeroPressed_NoDoubleZeros() {
			_target.ResultField = "0";

			_target.ZeroPressed.Execute ();

			Assert.AreEqual ("0", _target.ResultField);
		}

		[Test]
		public void OnePressed_Success() {
			_target.OnePressed.Execute ();

			Assert.AreEqual ("1", _target.ResultField);
		}

		[Test]
		public void OnePressed_Success_Append() {
			_target.ResultField = "1";

			_target.OnePressed.Execute ();

			Assert.AreEqual ("11", _target.ResultField);
		}

		[Test]
		public void OnePressed_NoLeadingZeros() {
			_target.ResultField = "0";

			_target.OnePressed.Execute ();

			Assert.AreEqual ("1", _target.ResultField);
		}

		[Test]
		public void TwoPressed_Success() {
			_target.TwoPressed.Execute ();

			Assert.AreEqual ("2", _target.ResultField);
		}

		[Test]
		public void TwoPressed_Success_Append() {
			_target.ResultField = "1";

			_target.TwoPressed.Execute ();

			Assert.AreEqual ("12", _target.ResultField);
		}

		[Test]
		public void TwoPressed_NoLeadingZeros() {
			_target.ResultField = "0";

			_target.TwoPressed.Execute ();

			Assert.AreEqual ("2", _target.ResultField);
		}

		[Test]
		public void ThreePressed_Success() {
			_target.ThreePressed.Execute ();

			Assert.AreEqual ("3", _target.ResultField);
		}

		[Test]
		public void ThreePressed_Success_Append() {
			_target.ResultField = "1";

			_target.ThreePressed.Execute ();

			Assert.AreEqual ("13", _target.ResultField);
		}

		[Test]
		public void ThreePressed_NoLeadingZeros() {
			_target.ResultField = "0";

			_target.ThreePressed.Execute ();

			Assert.AreEqual ("3", _target.ResultField);
		}

		[Test]
		public void FourPressed_Success() {
			_target.FourPressed.Execute ();

			Assert.AreEqual ("4", _target.ResultField);
		}

		[Test]
		public void FourPressed_Success_Append() {
			_target.ResultField = "1";

			_target.FourPressed.Execute ();

			Assert.AreEqual ("14", _target.ResultField);
		}

		[Test]
		public void FourPressed_NoLeadingZeros() {
			_target.ResultField = "0";

			_target.FourPressed.Execute ();

			Assert.AreEqual ("4", _target.ResultField);
		}

		[Test]
		public void FivePressed_Success() {
			_target.FivePressed.Execute ();

			Assert.AreEqual ("5", _target.ResultField);
		}

		[Test]
		public void FivePressed_Success_Append() {
			_target.ResultField = "1";

			_target.FivePressed.Execute ();

			Assert.AreEqual ("15", _target.ResultField);
		}

		[Test]
		public void FivePressed_NoLeadingZeros() {
			_target.ResultField = "0";

			_target.FivePressed.Execute ();

			Assert.AreEqual ("5", _target.ResultField);
		}

		[Test]
		public void SixPressed_Success() {
			_target.SixPressed.Execute ();

			Assert.AreEqual ("6", _target.ResultField);
		}

		[Test]
		public void SixPressed_Success_Append() {
			_target.ResultField = "1";

			_target.SixPressed.Execute ();

			Assert.AreEqual ("16", _target.ResultField);
		}

		[Test]
		public void SixPressed_NoLeadingZeros() {
			_target.ResultField = "0";

			_target.SixPressed.Execute ();

			Assert.AreEqual ("6", _target.ResultField);
		}

		[Test]
		public void SevenPressed_Success() {
			_target.SevenPressed.Execute ();

			Assert.AreEqual ("7", _target.ResultField);
		}

		[Test]
		public void SevenPressed_Success_Append() {
			_target.ResultField = "1";

			_target.SevenPressed.Execute ();

			Assert.AreEqual ("17", _target.ResultField);
		}

		[Test]
		public void SevenPressed_NoLeadingZeros() {
			_target.ResultField = "0";

			_target.SevenPressed.Execute ();

			Assert.AreEqual ("7", _target.ResultField);
		}

		[Test]
		public void EightPressed_Success() {
			_target.EightPressed.Execute ();

			Assert.AreEqual ("8", _target.ResultField);
		}

		[Test]
		public void EightPressed_Success_Append() {
			_target.ResultField = "1";

			_target.EightPressed.Execute ();

			Assert.AreEqual ("18", _target.ResultField);
		}

		[Test]
		public void EightPressed_NoLeadingZeros() {
			_target.ResultField = "0";

			_target.EightPressed.Execute ();

			Assert.AreEqual ("8", _target.ResultField);
		}

		[Test]
		public void NinePressed_Success() {
			_target.NinePressed.Execute ();

			Assert.AreEqual ("9", _target.ResultField);
		}

		[Test]
		public void NinePressed_Success_Append() {
			_target.ResultField = "1";

			_target.NinePressed.Execute ();

			Assert.AreEqual ("19", _target.ResultField);
		}

		[Test]
		public void NinePressed_NoLeadingZeros() {
			_target.ResultField = "0";

			_target.NinePressed.Execute ();

			Assert.AreEqual ("9", _target.ResultField);
		}

		[Test]
		public void DecimalPressed_Success() {
			_target.ResultField = "13";

			_target.DecimalPressed.Execute ();

			Assert.AreEqual ("13.", _target.ResultField);
		}

		[Test]
		public void DecimalPressed_AlreadyContainsDecimal() {
			_target.ResultField = "13.37";

			_target.DecimalPressed.Execute ();

			Assert.AreEqual ("13.37", _target.ResultField);
		}

		[Test]
		public void ToggleSignPressed_FromPositive() {
			_target.ResultField = "13.37";

			_target.ToggleSignPressed.Execute ();

			Assert.AreEqual ("-13.37", _target.ResultField);
		}

		[Test]
		public void ToggleSignPressed_ZeroCanNotGoNegative() {
			_target.ResultField = "0";

			_target.ToggleSignPressed.Execute ();

			Assert.AreEqual ("0", _target.ResultField);
		}

		[Test]
		public void ToggleSignPressed_FromNegative() {
			_target.ResultField = "-13.37";

			_target.ToggleSignPressed.Execute ();

			Assert.AreEqual ("13.37", _target.ResultField);
		}
	}
}

