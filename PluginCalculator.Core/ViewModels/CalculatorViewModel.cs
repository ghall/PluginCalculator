using System;
using Cirrious.MvvmCross.ViewModels;

namespace PluginCalculator.Core.ViewModels
{
	public class CalculatorViewModel : MvxViewModel
	{
		private string _resultField;
		private IMvxCommand _zeroPressed;
		private IMvxCommand _onePressed;
		private IMvxCommand _twoPressed;
		private IMvxCommand _threePressed;
		private IMvxCommand _fourPressed;
		private IMvxCommand _fivePressed;
		private IMvxCommand _sixPressed;
		private IMvxCommand _sevenPressed;
		private IMvxCommand _eightPressed;
		private IMvxCommand _ninePressed;
		private IMvxCommand _decimalPressed;
		private IMvxCommand _toggleSignPressed;

		public CalculatorViewModel ()
		{
		}

		public string ResultField {
			get { return _resultField ?? "0"; }
			set { 
				_resultField = value;
				RaisePropertyChanged (() => ResultField);
			}
		}

		public IMvxCommand ZeroPressed {
			get { return _zeroPressed ?? (_zeroPressed = new MvxCommand(DoZeroPressed)); }
		}

		public IMvxCommand OnePressed {
			get { return _onePressed ?? (_onePressed = new MvxCommand(DoOnePressed)); }
		}

		public IMvxCommand TwoPressed {
			get { return _twoPressed ?? (_twoPressed = new MvxCommand(DoTwoPressed)); }
		}

		public IMvxCommand ThreePressed {
			get { return _threePressed ?? (_threePressed = new MvxCommand(DoThreePressed)); }
		}

		public IMvxCommand FourPressed {
			get { return _fourPressed ?? (_fourPressed = new MvxCommand(DoFourPressed)); }
		}

		public IMvxCommand FivePressed {
			get { return _fivePressed ?? (_fivePressed = new MvxCommand(DoFivePressed)); }
		}

		public IMvxCommand SixPressed {
			get { return _sixPressed ?? (_sixPressed = new MvxCommand(DoSixPressed)); }
		}

		public IMvxCommand SevenPressed {
			get { return _sevenPressed ?? (_sevenPressed = new MvxCommand(DoSevenPressed)); }
		}

		public IMvxCommand EightPressed {
			get { return _eightPressed ?? (_eightPressed = new MvxCommand(DoEightPressed)); }
		}

		public IMvxCommand NinePressed {
			get { return _ninePressed ?? (_ninePressed = new MvxCommand(DoNinePressed)); }
		}

		public IMvxCommand DecimalPressed {
			get { return _decimalPressed ?? (_decimalPressed = new MvxCommand(DoDecimalPressed)); }
		}

		public IMvxCommand ToggleSignPressed {
			get { return _toggleSignPressed ?? (_toggleSignPressed = new MvxCommand(DoToggleSignPressed)); }
		}
			
		private void NumberPressed(int number) {
			if ("0" == ResultField)
				ResultField = string.Empty;

			ResultField += number.ToString();
		}

		private void DoZeroPressed() {
			NumberPressed (0);
		}

		private void DoOnePressed() {
			NumberPressed (1);
		}

		private void DoTwoPressed() {
			NumberPressed (2);
		}

		private void DoThreePressed() {
			NumberPressed (3);
		}

		private void DoFourPressed() {
			NumberPressed (4);
		}

		private void DoFivePressed() {
			NumberPressed (5);
		}

		private void DoSixPressed() {
			NumberPressed (6);
		}

		private void DoSevenPressed() {
			NumberPressed (7);
		}

		private void DoEightPressed() {
			NumberPressed (8);
		}

		private void DoNinePressed() {
			NumberPressed (9);
		}

		private void DoDecimalPressed() {
			if (ResultField.Contains ("."))
				return;

			ResultField += ".";
		}

		private void DoToggleSignPressed() {
			if (ResultField.StartsWith ("-"))
				ResultField = ResultField.Substring (1);
			else
				ResultField = "-" + ResultField;
		}
	}
}

