using System;
using MvvmCross.Platform;
using MvvmCross.Platform.Core;

namespace MvvmCross.iOS.Support.XamarinSidebarSample.Core.ViewModels
{
    using MvvmCross.Core.ViewModels;

    public class BaseViewModel : MvxViewModel
    {
        public string ExampleValue { get; set; }

        public void RequestMainThreadAction(Action action)
        {
            Mvx.Resolve<IMvxMainThreadDispatcher>().RequestMainThreadAction(action);
        }
    }
}