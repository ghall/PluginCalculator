using MonoTouch.UIKit;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Touch.Platform;
using Cirrious.CrossCore;
using PluginCalculator.Core.Repositories.Math;
using PluginCalculator.Core.NativePlugins;
using PluginCalculator.Touch.NativePlugins;
using PluginCalculator.Core.Repositories.Result;
using PluginCalculator.Core.Providers.JsonHttpProvider;

namespace PluginCalculator.Touch
{
	public class Setup : MvxTouchSetup
	{
		public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
		{
		}

		protected override IMvxApplication CreateApp ()
		{
			return new Core.App();
		}
		
        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

		protected override void InitializeLastChance ()
		{
			base.InitializeLastChance ();

			Mvx.LazyConstructAndRegisterSingleton<IMathRepository, MathRepository> ();
			Mvx.LazyConstructAndRegisterSingleton<ILogger, TouchLogger> ();
			Mvx.LazyConstructAndRegisterSingleton<IDialogPlugin, TouchDialogPlugin> ();
			Mvx.LazyConstructAndRegisterSingleton<IResultRepository, JsonResultRepository> ();
			Mvx.LazyConstructAndRegisterSingleton<IJsonHttpProvider, JsonHttpProvider> ();
		}
	}
}