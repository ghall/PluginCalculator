using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Touch.Views;

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
		}
	}
}

