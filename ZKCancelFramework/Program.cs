using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ZKCancelFramework
{
    class Program
    {
        /**
         * 取消架构，在线程运行时取消当前运行的线程所有操作
         * */
        static void Main(string[] args)
        {
            var cts = new CancellationTokenSource();
            cts.Token.Register(() =>
                {
                    Console.WriteLine("****token canceled");
                });

            //start a task that sends a cancel after 500ms
            new Task(() =>
            {
                Thread.Sleep(500);
                cts.Cancel(false);
            }).Start();

            try
            {
                ParallelLoopResult result = Parallel.For(0, 100,
                    new ParallelOptions() { CancellationToken = cts.Token },
                    x =>
                    {
                        //启动的迭代操作允许完成,因为取消操作总是以协作方式进行,以避免在取消迭代操作的中间泄露资源
                        //所以这里启动的循环都会执行完，而取消的操作所有的步骤均会取消，在输出中是看不到取消的线程或者任务的
                        Console.WriteLine("Loop {0} started,Thread {1}", x,Thread.CurrentThread.ManagedThreadId);
                        int sum = 0;
                        for (int i = 0; i < 100; i++)
                        {
                            Thread.Sleep(2);
                            sum += i;
                        }
                        Console.WriteLine("Loop {0} finished,Thread {1}", x, Thread.CurrentThread.ManagedThreadId);
                    });

            }
            catch(OperationCanceledException ex)
            {
                Console.WriteLine("Thread:{0} msg:{1}", Thread.CurrentThread.ManagedThreadId, ex.Message);
            }
        }
    }
}
