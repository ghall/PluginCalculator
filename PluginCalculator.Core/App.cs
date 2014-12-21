using Cirrious.CrossCore.IoC;
using PluginCalculator.Core.ViewModels;

namespace PluginCalculator.Core
{
    public class App : Cirrious.MvvmCross.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
				
			RegisterAppStart<CalculatorViewModel>();
        }
    }
}