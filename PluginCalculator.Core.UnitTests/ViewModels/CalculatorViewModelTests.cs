using System;
using NUnit.Framework;
using PluginCalculator.Core.ViewModels;
using Cirrious.MvvmCross.Test.Core;
using PluginCalculator.Core.Repositories.Math;
using Moq;
using PluginCalculator.Core.Repositories.Result;
using System.Threading;
using PluginCalculator.Core.NativePlugins;

namespace PluginCalculator.Core.UnitTests.ViewModels
{
	[TestFixture]
	public class CalculatorViewModelTests : MvxIoCSupportingTest
	{
		private CalculatorViewModel _target;
		private Mock<IMathRepository> _mathRepository;
		private Mock<IResultRepository> _resultRepository;
		private Mock<IDialogPlugin> _dialogPlugin;
		private Mock<ILogger> _loggerPlugin;

		[SetUp]
		public void Setup() {
			base.Setup ();

			_mathRepository = new Mock<IMathRepository> ();
			_resultRepository = new Mock<IResultRepository> ();
			_dialogPlugin = new Mock<IDialogPlugin> ();
			_loggerPlugin = new Mock<ILogger> ();

			_target = new CalculatorViewModel (_mathRepository.Object, _resultRepository.Object, _dialogPlugin.Object, _loggerPlugin.Object);
		}

		[Test]
		public void IsLoading_TestProperty() {
			Assume.That (_target.IsLoading, Is.EqualTo (false));

			_target.IsLoading = true;

			Assert.AreEqual (true, _target.IsLoading);
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

		[Test]
		public void ClearPressed_Success() {
			_target.ResultField = "-13.37";

			_target.ClearPressed.Execute ();

			Assert.AreEqual ("0", _target.ResultField);
		}

		[Test]
		public void PlusPressed_Success() {
			_target.ResultField = "3";

			_target.PlusPressed.Execute ();

			Assert.AreEqual ("3", _target.ResultBacklog);
			Assert.AreEqual (MathOperation.Addition, _target.PendingOperation);
		}

		[Test]
		public void MinusPressed_Success() {
			_target.ResultField = "3";

			_target.MinusPressed.Execute ();

			Assert.AreEqual ("3", _target.ResultBacklog);
			Assert.AreEqual (MathOperation.Subtraction, _target.PendingOperation);
		}

		[Test]
		public void TimesPressed_Success() {
			_target.ResultField = "3";

			_target.TimesPressed.Execute ();

			Assert.AreEqual ("3", _target.ResultBacklog);
			Assert.AreEqual (MathOperation.Mulitiplication, _target.PendingOperation);
		}

		[Test]
		public void DividePressed_Success() {
			_target.ResultField = "3";

			_target.DividePressed.Execute ();

			Assert.AreEqual ("3", _target.ResultBacklog);
			Assert.AreEqual (MathOperation.Division, _target.PendingOperation);
		}

        [Test]
        public void EqualsPressed_Success()
        {
            _mathRepository
                .Setup(x => x.IsValid(It.IsAny<string>(), It.IsAny<MathOperation>(), It.IsAny<string>()))
                .Returns(EquationValidity.Valid);
            _mathRepository
                .Setup(x => x.CreateEquation(It.IsAny<string>(), It.IsAny<MathOperation>(), It.IsAny<string>()))
                .Returns("3/2");
            _resultRepository
                .Setup(x => x.Execute(It.IsAny<string>()))
                .Returns("1.5");
            _target.ResultField = "3";
            _target.DividePressed.Execute();
            _target.ResultField = "2";

            Assume.That(_target.ResultBacklog, Is.EqualTo("3"));
            Assume.That(_target.PendingOperation, Is.EqualTo(MathOperation.Division));
            Assume.That(_target.ResultField, Is.EqualTo("2"));

            _target.EqualsPressed.Execute();

            Thread.Sleep(100);

            Assert.IsNull(_target.ResultBacklog);
            Assert.AreEqual("1.5", _target.ResultField);
        }

        [Test]
        public void EqualsPressed_Success_ClearsAfterExecution()
        {
            _mathRepository
                .Setup(x => x.IsValid(It.IsAny<string>(), It.IsAny<MathOperation>(), It.IsAny<string>()))
                .Returns(EquationValidity.Valid);
            _mathRepository
                .Setup(x => x.CreateEquation(It.IsAny<string>(), It.IsAny<MathOperation>(), It.IsAny<string>()))
                .Returns("3/2");
            _resultRepository
                .Setup(x => x.Execute(It.IsAny<string>()))
                .Returns("1.5");
            _target.ResultField = "3";
            _target.DividePressed.Execute();
            _target.ResultField = "2";
            _target.EqualsPressed.Execute();
            Thread.Sleep(100);

            _target.FourPressed.Execute();

            Assert.AreEqual("4", _target.ResultField);
        }

        [Test]
        public void EqualsPressed_Success_DecimalClearsAfterExecution()
        {
            _mathRepository
                .Setup(x => x.IsValid(It.IsAny<string>(), It.IsAny<MathOperation>(), It.IsAny<string>()))
                .Returns(EquationValidity.Valid);
            _mathRepository
                .Setup(x => x.CreateEquation(It.IsAny<string>(), It.IsAny<MathOperation>(), It.IsAny<string>()))
                .Returns("3/2");
            _resultRepository
                .Setup(x => x.Execute(It.IsAny<string>()))
                .Returns("1.5");
            _target.ResultField = "3";
            _target.DividePressed.Execute();
            _target.ResultField = "2";
            _target.EqualsPressed.Execute();
            Thread.Sleep(100);

            _target.DecimalPressed.Execute();

            Assert.AreEqual("0.", _target.ResultField);
        }


		[Test]
		public void EqualsPressed_DivByZero() {
			_mathRepository
				.Setup (x => x.IsValid (It.IsAny<string> (), It.IsAny<MathOperation> (), It.IsAny<string> ()))
				.Returns (EquationValidity.DivisionByZero);
			_mathRepository
				.Setup (x => x.CreateEquation (It.IsAny<string> (), It.IsAny<MathOperation> (), It.IsAny<string> ()))
				.Returns ("3/0");
			_resultRepository
				.Setup (x => x.Execute (It.IsAny<string> ()))
				.Returns (() => null);
			_target.ResultField = "3";
			_target.DividePressed.Execute ();
			_target.ResultField = "0";

			Assume.That (_target.ResultBacklog, Is.EqualTo ("3"));
			Assume.That (_target.PendingOperation, Is.EqualTo (MathOperation.Division));
			Assume.That (_target.ResultField, Is.EqualTo ("0"));

			_target.EqualsPressed.Execute ();

			Thread.Sleep (100);

			_dialogPlugin.Verify (x => x.ShowMessage (It.IsAny<string> (), It.Is<string> (s => "Division by zero" == s), It.IsAny<string> ()), Times.Once);
			Assert.AreEqual ("3", _target.ResultBacklog);
			Assert.AreEqual ("0", _target.ResultField);
		}

		[Test]
		public void EqualsPressed_ServerError() {
			_mathRepository
				.Setup (x => x.IsValid (It.IsAny<string> (), It.IsAny<MathOperation> (), It.IsAny<string> ()))
				.Returns (EquationValidity.Valid);
			_mathRepository
				.Setup (x => x.CreateEquation (It.IsAny<string> (), It.IsAny<MathOperation> (), It.IsAny<string> ()))
				.Returns ("3/2");
			_resultRepository
				.Setup (x => x.Execute (It.IsAny<string> ()))
				.Returns (() => null);
			_target.ResultField = "3";
			_target.DividePressed.Execute ();
			_target.ResultField = "2";

			Assume.That (_target.ResultBacklog, Is.EqualTo ("3"));
			Assume.That (_target.PendingOperation, Is.EqualTo (MathOperation.Division));
			Assume.That (_target.ResultField, Is.EqualTo ("2"));

			_target.EqualsPressed.Execute ();

			Thread.Sleep (100);

			_dialogPlugin.Verify (x => x.ShowMessage (It.IsAny<string> (), It.Is<string> (s => "Server error" == s), It.IsAny<string> ()), Times.Once);
			Assert.AreEqual ("3", _target.ResultBacklog);
			Assert.AreEqual ("2", _target.ResultField);
		}

		[Test]
		public void EqualsPressed_ExceptionPath() {
			_mathRepository
				.Setup (x => x.IsValid (It.IsAny<string> (), It.IsAny<MathOperation> (), It.IsAny<string> ()))
				.Returns (EquationValidity.Valid);
			_mathRepository
				.Setup (x => x.CreateEquation (It.IsAny<string> (), It.IsAny<MathOperation> (), It.IsAny<string> ()))
				.Returns ("3/2");
			_resultRepository
				.Setup (x => x.Execute (It.IsAny<string> ()))
				.Throws(new Exception());
			_target.ResultField = "3";
			_target.DividePressed.Execute ();
			_target.ResultField = "2";

			Assume.That (_target.ResultBacklog, Is.EqualTo ("3"));
			Assume.That (_target.PendingOperation, Is.EqualTo (MathOperation.Division));
			Assume.That (_target.ResultField, Is.EqualTo ("2"));

			_target.EqualsPressed.Execute ();

			Thread.Sleep (100);

			_dialogPlugin.Verify (x => x.ShowMessage (It.Is<string> (s => "Exception" == s), It.IsAny<string> (), It.IsAny<string> ()), Times.Once);
			_loggerPlugin.Verify(x => x.Log(It.IsAny<string>()), Times.AtLeast(2));
			Assert.AreEqual ("3", _target.ResultBacklog);
			Assert.AreEqual ("2", _target.ResultField);
		}

        [Test]
	    public void DisplayField_Test()
	    {
	        _target.ResultField = "3";
            
            Assert.AreEqual("3", _target.DisplayField);
	    }

        [Test]
	    public void DisplayField_Test_AfterOperation()
	    {
	        _target.ResultField = "3";
            _target.PlusPressed.Execute();

            Assert.AreEqual("3", _target.DisplayField);
            Assert.AreNotEqual("3", _target.ResultField);
	    }

	    [Test]
	    public void DisplayField_Test_AfterOperationWithValue()
	    {
	        _target.ResultField = "3";
            _target.PlusPressed.Execute();
            _target.OnePressed.Execute();

            Assert.AreEqual("1", _target.DisplayField);
	    }

        [Test]
        public void NumberPressed_DisableWhileLoading()
        {
            _target.ResultField = "3";
            _target.IsLoading = true;
            _target.OnePressed.Execute();

            Assert.AreEqual("3", _target.ResultField);
        }

        [Test]
        public void DecimalPressed_DisableWhileLoading()
        {
            _target.ResultField = "3";
            _target.IsLoading = true;
            _target.DecimalPressed.Execute();

            Assert.AreEqual("3", _target.ResultField);
        }

        [Test]
        public void ToggleSignPressed_DisableWhileLoading()
        {
            _target.ResultField = "3";
            _target.IsLoading = true;
            _target.ToggleSignPressed.Execute();

            Assert.AreEqual("3", _target.ResultField);
        }

        [Test]
        public void ClearPressed_DisableWhileLoading()
        {
            _target.ResultField = "3";
            _target.IsLoading = true;
            _target.ClearPressed.Execute();

            Assert.AreEqual("3", _target.ResultField);
        }

        [Test]
        public void OperatorPressed_DisableWhileLoading()
        {
            _target.ResultField = "3";
            _target.IsLoading = true;
            _target.MinusPressed.Execute();

            Assert.AreEqual("3", _target.ResultField);
        }

        [Test]
        public void EqualsPressed_DisableWhileLoading()
        {
            _target.ResultField = "3";
            _target.IsLoading = true;
            _target.EqualsPressed.Execute();

            Assert.AreEqual("3", _target.ResultField);
            _mathRepository.Verify(x => x.IsValid(It.IsAny<string>(), It.IsAny<MathOperation>(), It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void EqualsPressed_NothingInBacklog()
        {
            _target.ResultField = "3";
            _target.EqualsPressed.Execute();

            Assert.AreEqual("3", _target.ResultField);
            _mathRepository.Verify(x => x.IsValid(It.IsAny<string>(), It.IsAny<MathOperation>(), It.IsAny<string>()), Times.Never);
        }
	}
}

