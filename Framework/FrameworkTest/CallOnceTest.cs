using System;
using System.Threading;
using CommonLibary.CallOnce;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FrameworkTest
{
    /// <summary>
    /// 并发只调用一次方法测试
    /// </summary>
    [TestClass]
    public class CallOnceTest
    {
        static OnceFlag _flag = new OnceFlag();

        [TestMethod]
        public void TestMethod1()
        {
            var t1 = new Thread(() => DoOnce(1));
            var t2 = new Thread(() => DoOnce(2));
            var t3 = new Thread(() => DoOnce(3));
            var t4 = new Thread(() => DoOnce(4));

            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();

            t1.Join();
            t2.Join();
            t3.Join();
            t4.Join();
        }

        private static void DoOnce(int index)
        {
            CalledOnce.Once(_flag, () => Console.WriteLine("Callled (" + index + ")"));
        }
    }
}
