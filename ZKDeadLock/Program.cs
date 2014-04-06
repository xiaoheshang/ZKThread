using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ZKDeadLock
{
    class Program
    {
        static void Main(string[] args)
        {
            var state1 = new StateObject();
            var state2 = new StateObject();

            new Task(new SampleThread(state1, state2).deadlock1).Start();
            new Task(new SampleThread(state1, state2).deadlock2).Start();
            //Parallel.Invoke(new SampleThread(state1, state2).deadlock1, new SampleThread(state1, state2).deadlock2);


            Console.ReadKey();
        }
    }
}
