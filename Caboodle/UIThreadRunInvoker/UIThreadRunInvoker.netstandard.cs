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
            throw new NotSupportedException("Calling on Main UI Thread from undefined platform not supported");
        }
    }
}
