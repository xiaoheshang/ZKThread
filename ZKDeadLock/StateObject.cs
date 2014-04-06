using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ZKDeadLock
{
    public class StateObject
    {
        private int state = 5;
        object syn = new object();


        public void changeState(int loop)
        {
            //将共享对象设置为线程安全的对象
            //lock (syn)
            //{
                if (state == 5)
                {
                    state++;
                    Trace.Assert(state == 6, "Race Condition occurred after loop:" + loop);
                }
                state = 5;
            //}
        }
    }
}
