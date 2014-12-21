using Cirrious.MvvmCross.Droid.Views;
using Cirrious.MvvmCross.ViewModels;

namespace PluginCalculator.Droid.Views
{
    public class BaseView<T> : MvxActivity where T : MvxViewModel
    {
        private readonly int _layoutId;

        public BaseView(int layoutId)
        {
            _layoutId = layoutId;
        }

        public new T ViewModel
        {
            get { return (T) base.ViewModel; }
            set { base.ViewModel = value; }
        }

        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();
            SetContentView(_layoutId);
        }

    }
}