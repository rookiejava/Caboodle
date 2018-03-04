using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Caboodle
{
    public partial class UIThreadRunInvoker
    {
        // From NSObject derived classes
        // UIKit.UIApplication.SharedApplication.BeginInvokeOnMainThread;
        // From anywhere
        // CoreFoundation.DispatchQueue.MainQueue.DispatchAsync;

        public static void BeginInvokeOnUIThread(Action action)
        {
            UIKit.UIApplication.SharedApplication.BeginInvokeOnMainThread
                (
                    delegate { action(); }
                );

            return;
        }

        public static Task<T> BeginInvokeOnUIThreadAsync<T>(Func<T> action)
        {
            var tcs = new TaskCompletionSource<T>();
            UIKit.UIApplication.SharedApplication.BeginInvokeOnMainThread
                (
                    () => 
                    {
                        try
                        {
                            var result = action();
                            tcs.SetResult(result);
                        }
                        catch (Exception ex)
                        {
                            tcs.SetException(ex);
                        }
                    }
                );

            return tcs.Task;
        }

        public static Task BeginInvokeOnUIThreadAsync(Action action)
        {
            var tcs = new TaskCompletionSource<Task>();
            UIKit.UIApplication.SharedApplication.BeginInvokeOnMainThread
                (
                    () =>
                    {
                        try
                        {
                            action();
                            tcs.SetResult(new Task(action));
                        }
                        catch (Exception ex)
                        {
                            tcs.SetException(ex);
                        }
                    }
                );

            return tcs.Task;
        }
    }
}
