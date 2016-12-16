using System;
using MvvmCross.Platform.Platform;

namespace MvvmCross.iOS.Support.XamarinSidebarSample.iOS
{
    using UIKit;

    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            try
            {
                UIApplication.Main(args, null, "AppDelegate");
            }
            catch (Exception ex)
            {
                MvxTrace.Error(ex.ToString());
            }
        }
    }
}
