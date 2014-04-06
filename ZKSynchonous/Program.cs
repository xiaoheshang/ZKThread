using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZKSynchonous
{
    class Program
    {
        static void Main(string[] args)
        {
            int tasknum = 20;
            var sharedState = new SharedState();
            var tasks = new Task[tasknum]; 
            //sharedState.state = 0;

            for (int i = 0; i < 20; i++)
            {
                tasks[i] = new Task(new Job(sharedState).doTheJob);
                tasks[i].Start();
            }

            for (int i = 0; i < 20; i++)
            {
                tasks[i].Wait();
            }

            Console.WriteLine("20个任务，每个任务加50000 结果是：{0}", sharedState.State);
        }
    }
}
