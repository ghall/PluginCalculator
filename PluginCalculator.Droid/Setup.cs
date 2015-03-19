using Android.Content;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.Droid.Platform;
using Cirrious.MvvmCross.ViewModels;
using PluginCalculator.Core.NativePlugins;
using PluginCalculator.Core.Repositories.Math;
using PluginCalculator.Core.Repositories.Result;
using PluginCalculator.Droid.NativePlugins;
using PluginCalculator.Core.Providers.JsonHttpProvider;

namespace PluginCalculator.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }
		
        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        protected override void InitializeLastChance()
        {
            base.InitializeLastChance();

            Mvx.LazyConstructAndRegisterSingleton<IMathRepository, MathRepository>();
            Mvx.LazyConstructAndRegisterSingleton<ILogger, DroidLogger>();
            Mvx.LazyConstructAndRegisterSingleton<IDialogPlugin, DroidDialogPlugin>();
            Mvx.LazyConstructAndRegisterSingleton<IResultRepository, JsonResultRepository>();
			Mvx.LazyConstructAndRegisterSingleton<IJsonHttpProvider, JsonHttpProvider> ();
        }
    }
}