using Android.App;
using Android.Content.PM;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Droid.Platform;
using Cirrious.MvvmCross.Binding.BindingContext;
using PluginCalculator.Core.ViewModels;

namespace PluginCalculator.Droid.Views
{
    [Activity(ScreenOrientation = ScreenOrientation.Portrait)]
    public class CalculatorView : BaseView<CalculatorViewModel>
    {
        private bool _inProgress;
        private ProgressDialog _dialog;

        public CalculatorView() : base(Resource.Layout.CalculatorView)
        {
        }

        protected override void OnCreate(Android.OS.Bundle bundle)
        {
            base.OnCreate(bundle);

            var set = this.CreateBindingSet<CalculatorView, CalculatorViewModel>();
            set.Bind(this).For(v => v.InProgress).To(vm => vm.IsLoading);
            set.Apply();
        }

        public bool InProgress
        {
            get { return _inProgress; }
            set
            {
                _inProgress = value;

                if (_inProgress)
                {
                    _dialog = new ProgressDialog(Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity);
                    _dialog.SetTitle("Executing...");
                    _dialog.Show();
                }
                else
                {
                    if (null != _dialog) _dialog.Hide();
                    _dialog = null;
                }
            }
        }

    }
}