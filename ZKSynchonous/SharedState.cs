using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZKSynchonous
{
    public class SharedState
    {

        /**
         * 调用方法DomcTaskO方法的线程访问sharedstate类的gct存取器,以获得state的当前值,接
         * 着get存取器给state设置新值。在调用对象的get和set存取器期间,对象没有锁定,另一个线程可
         * 以获得临时值。
         * */
        //private int _state;
        //private object syncobj = new object();
        //public int state
        //{
        //    get { lock (syncobj) { return _state; } }
        //    set { lock (syncobj) { _state = value; } }
        //}

        //public int state { get; set; }

        private int state = 0;
        private object syncobj = new object();

        public int State
        {
            get { return state; }
        }

        public int IncrementState()
        {
            lock (syncobj)
            {
                return ++state;
            }
        }

    }
}
