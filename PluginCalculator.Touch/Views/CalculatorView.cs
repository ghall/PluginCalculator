﻿using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;
using PluginCalculator.Core.ViewModels;
using MBProgressHUD;

namespace PluginCalculator.Touch.Views
{
	public partial class CalculatorView : MvxViewController
	{
		private bool _inProgress;
		private MTMBProgressHUD _hud;

		public CalculatorView () : base ("CalculatorView", null)
		{
		}

		public override UIStatusBarStyle PreferredStatusBarStyle ()
		{
			return UIStatusBarStyle.LightContent;
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			NavigationController.NavigationBarHidden = true;

			_hud = new MTMBProgressHUD (View) {
				LabelText = "Executing..."
			};

			View.AddSubview (_hud);

			var set = this.CreateBindingSet<CalculatorView, CalculatorViewModel> ();
			set.Bind (ResultField).For(v => v.Text).To (vm => vm.DisplayField);
			set.Bind (Zero).To (vm => vm.ZeroPressed);
			set.Bind (One).To (vm => vm.OnePressed);
			set.Bind (Two).To (vm => vm.TwoPressed);
			set.Bind (Three).To (vm => vm.ThreePressed);
			set.Bind (Four).To (vm => vm.FourPressed);
			set.Bind (Five).To (vm => vm.FivePressed);
			set.Bind (Six).To (vm => vm.SixPressed);
			set.Bind (Seven).To (vm => vm.SevenPressed);
			set.Bind (Eight).To (vm => vm.EightPressed);
			set.Bind (Nine).To (vm => vm.NinePressed);
			set.Bind (Decimal).To (vm => vm.DecimalPressed);
			set.Bind (ToggleSign).To (vm => vm.ToggleSignPressed);
			set.Bind (Clear).To (vm => vm.ClearPressed);
			set.Bind (Divise).To (vm => vm.DividePressed);
			set.Bind (Multiply).To (vm => vm.TimesPressed);
			set.Bind (Plus).To (vm => vm.PlusPressed);
			set.Bind (Minus).To (vm => vm.MinusPressed);
			set.Bind (Equals).To (vm => vm.EqualsPressed);
			set.Bind (this).For (v => v.InProgress).To (vm => vm.IsLoading);
			set.Apply ();
		}

		public bool InProgress {
			get { return _inProgress; }
			set {
				_inProgress = value;

				if (null == _hud)
					return;

				if (_inProgress)
					_hud.Show (true);
				else
					_hud.Hide (true);
			}
		}
	}
}

