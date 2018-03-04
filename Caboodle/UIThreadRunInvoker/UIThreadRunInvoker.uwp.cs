using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Caboodle
{
    public partial class UIThreadRunInvoker
    {
        public static void BeginInvokeOnUIThread(Action action)
        {
            var dispatcher = Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher;
            var t = dispatcher.RunAsync
                             (
                                Windows.UI.Core.CoreDispatcherPriority.Normal,
                                delegate{ action(); }
                             );
        }
    }
}
