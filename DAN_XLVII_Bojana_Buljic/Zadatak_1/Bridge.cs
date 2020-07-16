using System;
using System.Threading;

namespace Zadatak_1
{
    class Bridge
    {
        /// <summary>
        /// event for wait vehicle if one is going in opposite direction
        /// </summary>
        private static EventWaitHandle waitDir = new AutoResetEvent(true);
        /// <summary>
        /// allow vehicle to start crossing the bridge
        /// </summary>
        public static EventWaitHandle next = new AutoResetEvent(true);

        public void PassTheBridge(string direction, int orderNo)
        {
            waitDir.WaitOne();
            if (orderNo == 1)
            {
                Vehicle.currentDirection = direction;
                Console.WriteLine("Vehicle with order no_{0} crossing the bridge in direction {1}.", orderNo, direction);
                waitDir.Set();
                //next vehicle going the same direction can start crossing the bridge
                next.Set();
                Thread.Sleep(500);
            }
            else if (Vehicle.currentDirection == direction)
            {
                Console.WriteLine("Vehicle with order no_{0} crossing the bridge in direction {1}.", orderNo, direction);
                waitDir.Set();
                //next vehicle going the same direction can start crossing the bridge
                next.Set();
                Thread.Sleep(500);

                if (orderNo == Vehicle.allVehicles.Count)
                {
                    Program.swApp.Stop();
                    Program.swApp.Stop();
                    long time = Program.swApp.ElapsedMilliseconds;

                    Console.WriteLine("\n Application run time is: " + time + " milliseconds");
                }
            }
            else
            {
                Console.WriteLine("Vehicle with order no_{0}, waiting to cross the bridge in {1} direction", orderNo, direction);
                Vehicle.currentDirection = direction;
                Thread.Sleep(500);
                waitDir.Set();
                PassTheBridge(direction, orderNo);
            }
        }
    }
}
