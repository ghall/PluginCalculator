using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;
using PluginCalculator.Core.ViewModels;

namespace PluginCalculator.Touch.Views
{
	public partial class CalculatorView : MvxViewController
	{
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

			var set = this.CreateBindingSet<CalculatorView, CalculatorViewModel> ();
			set.Bind (ResultField).For(v => v.Text).To (vm => vm.ResultField);
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
			set.Apply ();
		}
	}
}

