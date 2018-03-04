using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Caboodle
{
    using UIContext = Android.Content.Context;

    public partial class UIThreadRunInvoker
    {
        public static void BeginInvokeOnUIThread(Action action)
        {
            if (Platform.CurrentActivity != null)
            {
                Platform.CurrentActivity.RunOnUiThread(action);
            }
            else
            {
                action();
            }

            return;
        }
    }
}
