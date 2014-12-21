using Android.App;
using Android.Content.PM;
using PluginCalculator.Core.ViewModels;

namespace PluginCalculator.Droid.Views
{
    [Activity(ScreenOrientation = ScreenOrientation.Portrait)]
    public class CalculatorView : BaseView<CalculatorViewModel>
    {

        public CalculatorView() : base(Resource.Layout.CalculatorView)
        {
        }

    }
}