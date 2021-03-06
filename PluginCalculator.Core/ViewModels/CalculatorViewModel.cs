﻿using System;
using Cirrious.MvvmCross.ViewModels;
using PluginCalculator.Core.Repositories.Math;
using System.Threading.Tasks;
using PluginCalculator.Core.Repositories.Result;
using PluginCalculator.Core.NativePlugins;

namespace PluginCalculator.Core.ViewModels
{
	public class CalculatorViewModel : MvxViewModel
	{
		private readonly IMathRepository _mathRepository;
		private readonly IResultRepository _resultRepository;
		private readonly IDialogPlugin _dialogPlugin;
		private readonly ILogger _logger;

		private string _resultField;
		private string _resultBacklog;
		private bool _hasPendingOperation;
		private bool _shouldClearOnNumberPress;
		private MathOperation _pendingOperation;
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
		private IMvxCommand _clearPressed;
		private IMvxCommand _plusPressed;
		private IMvxCommand _minusPressed;
		private IMvxCommand _timesPressed;
		private IMvxCommand _dividePressed;
		private IMvxCommand _equalsPressed;
		private bool _isLoading;

		public CalculatorViewModel (IMathRepository mathRepository, IResultRepository resultRepository, IDialogPlugin dialogPlugin, ILogger logger)
		{
			_mathRepository = mathRepository;
			_resultRepository = resultRepository;
			_dialogPlugin = dialogPlugin;
			_logger = logger;
		}

		public string DisplayField {
			get { return !_hasPendingOperation ? ResultField : ResultBacklog; }
		}

		public string ResultBacklog {
			get { return _resultBacklog; }
			set { 
				_resultBacklog = value;
				RaisePropertyChanged (() => ResultBacklog);
				RaisePropertyChanged (() => DisplayField);
			}
		}

		public string ResultField {
			get { return _resultField ?? "0"; }
			set { 
				_resultField = value;
				RaisePropertyChanged (() => ResultField);
				RaisePropertyChanged (() => DisplayField);
			}
		}

		public MathOperation PendingOperation {
			get { return _pendingOperation; }
		}

		public bool IsLoading {
			get { return _isLoading; }
			set { 
				_isLoading = value;
				RaisePropertyChanged (() => IsLoading);
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

		public IMvxCommand ClearPressed {
			get { return _clearPressed ?? (_clearPressed = new MvxCommand(DoClearPressed)); }
		}

		public IMvxCommand PlusPressed {
			get { return _plusPressed ?? (_plusPressed = new MvxCommand(DoPlusPressed)); }
		}

		public IMvxCommand MinusPressed {
			get { return _minusPressed ?? (_minusPressed = new MvxCommand(DoMinusPressed)); }
		}

		public IMvxCommand TimesPressed {
			get { return _timesPressed ?? (_timesPressed = new MvxCommand(DoTimesPressed)); }
		}

		public IMvxCommand DividePressed {
			get { return _dividePressed ?? (_dividePressed = new MvxCommand(DoDividePressed)); }
		}

		public IMvxCommand EqualsPressed {
			get { return _equalsPressed ?? (_equalsPressed = new MvxCommand(DoEqualsPressed)); }
		}
			
		private void NumberPressed(int number) {
			if (IsLoading)
				return;

			if (_shouldClearOnNumberPress) {
				_shouldClearOnNumberPress = false;
				ResultField = "0";
			}

			if (_hasPendingOperation) {
				_hasPendingOperation = false;
				ResultField = "0";
			}

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
			if (IsLoading)
				return;

			if (_shouldClearOnNumberPress) {
				_shouldClearOnNumberPress = false;
				ResultField = "0";
			}

			if (_hasPendingOperation) {
				_hasPendingOperation = false;
				ResultField = "0";
			}

			if (ResultField.Contains ("."))
				return;

			ResultField += ".";
		}

		private void DoToggleSignPressed() {
			if (IsLoading)
				return;

			if (ResultField.StartsWith ("-"))
				ResultField = ResultField.Substring (1);
			else if ("0" != ResultField)
				ResultField = "-" + ResultField;
		}

		private void DoClearPressed() {
			if (IsLoading)
				return;

			_hasPendingOperation = false;
			ResultField = null;
			ResultBacklog = null;
		}

		private void DoPlusPressed() {
			OperatorPressed (MathOperation.Addition);
		}

		private void DoMinusPressed() {
			OperatorPressed (MathOperation.Subtraction);
		}

		private void DoTimesPressed() {
			OperatorPressed (MathOperation.Mulitiplication);
		}

		private void DoDividePressed() {
			OperatorPressed (MathOperation.Division);
		}

		private void OperatorPressed(MathOperation operation) {
			if (IsLoading)
				return;

			_hasPendingOperation = true;
			_pendingOperation = operation;
			ResultBacklog = ResultField;
			ResultField = null;
		}

		private void DoEqualsPressed() {
			if (IsLoading)
				return;

			if (null == ResultBacklog)
				return;

			switch (_mathRepository.IsValid (ResultBacklog, PendingOperation, ResultField)) {
			case EquationValidity.Valid:
				break;
			case EquationValidity.DivisionByZero:
				_dialogPlugin.ShowMessage ("Error", "Division by zero", "Cancel");
				return;
			}

			var equation = _mathRepository.CreateEquation (ResultBacklog, PendingOperation, ResultField);

			IsLoading = true;

			Task.Run (() => {
				try {
					var result = _resultRepository.Execute (equation);
					if (null == result) {
						_dialogPlugin.ShowMessage("Error", "Server error", "Cancel");
						return;
					}

					ResultBacklog = null;
					ResultField = result;
					_shouldClearOnNumberPress = true;
				} catch (Exception e) {
					_logger.Log(this, e.Message);
					_logger.Log(this, e.StackTrace);
					_dialogPlugin.ShowMessage("Exception", "Internal error: " + e.Message, "Cancel");
				} finally {
					IsLoading = false;
				}
			});
		}
	}
}

