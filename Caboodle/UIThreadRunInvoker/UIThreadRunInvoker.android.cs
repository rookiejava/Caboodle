using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Caboodle
{
    using UIContext = Android.Content.Context;

    public partial class UIThreadRunInvoker
    {
        public static UIContext Context
        {
            get;
            set;
        }

        static UIThreadRunInvoker()
        {
            return;
        }

        public static void BeginInvokeOnUIThread(Action action)
        {
            var activity = UIThreadRunInvoker.Context as Android.App.Activity;
            if (activity != null)
            {
                activity.RunOnUiThread(action);
            }
            else
            {
                action();
            }

            return;
        }
    }
}
