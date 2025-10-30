using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaCalcolatrice
{
    public class SystemClock : ICLock
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }
    }
}
