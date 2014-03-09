using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommonLibary.CallOnce
{
    public static class CalledOnce
    {
        public static void Once(OnceFlag flag, Action action)
        {
            if (flag.CheckIfCalledAndSet)
            {
                action.Invoke();
            }
        }
    }

    public class OnceFlag
    {
        private const int NotCalled = 0;
        private const int Called = 1;
        private int _state = NotCalled;
        internal bool CheckIfCalledAndSet
        {
            get
            {
                var prev = Interlocked.Exchange(ref _state, Called);

                return prev == NotCalled;
            }
        }

        internal void Reset()
        {
            Interlocked.Exchange(ref _state, NotCalled);
        }
    }
}
