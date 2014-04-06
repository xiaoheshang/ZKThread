using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZKSynchonous
{
    public class Job
    {
        SharedState sharedState;
        private object syncRoot = new object();

        public Job(SharedState sharedState)
        {
            this.sharedState = sharedState;
        }

        public void doTheJob()
        {
            for (int i = 0; i < 5000; i++)
            {
                //lock (sharedState)
                //{
                //    sharedState.state += 1;
                //}
                sharedState.IncrementState();
            }
        }
    }
}
