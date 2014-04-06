using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZKDeadLock
{
    public class SampleThread
    {
        public SampleThread(StateObject s1, StateObject s2)
        {
            this.s1 = s1;
            this.s2 = s2;
        }

        private StateObject s1;
        private StateObject s2;

        public void deadlock1()
        {
            int i = 0;
            while (true)
            {
                lock (s1)
                {
                    lock (s2)
                    {
                        s1.changeState(i);
                        s2.changeState(i++);
                        Console.WriteLine("1-->Still running...");
                    }
                }
            }
        }

        public void deadlock2()
        {
            int i = 0;
            while (true)
            {
                lock (s2)
                {
                    lock (s1)
                    {
                        s1.changeState(i);
                        s2.changeState(i++);
                        Console.WriteLine("2-->Still running...");
                    }
                }
            }
        }
    }
}
