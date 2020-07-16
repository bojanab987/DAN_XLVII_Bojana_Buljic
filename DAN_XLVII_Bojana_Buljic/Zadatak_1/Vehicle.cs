using System;
using System.Collections.Generic;
using System.Threading;

namespace Zadatak_1
{
    class Vehicle
    {
        #region Vehicle properties        
        public int OrderNo { get; set; }
        /// <summary>
        /// direction property of the vehicle
        /// </summary>        
        public string Direction { get; set; }
        #endregion

        //random instance for generating random directions
        Random rnd = new Random();
        public static string currentDirection = "";
        //string array with two possible directions for vehicle
        string[] Directions = { "North", "South" };

        /// <summary>
        /// Event for creating one vehicle at a time
        /// </summary>
        private static AutoResetEvent vehicleEvent = new AutoResetEvent(true);
        /// <summary>
        /// event for wait all vehicles created
        /// </summary>
        private static CountdownEvent countdown = new CountdownEvent(Program.vehiclesNum);
        //list of all vehicles created
        public static List<Vehicle> allVehicles = new List<Vehicle>();

        //delegate 
        public delegate void Notification();
        //event based on delegate
        public event Notification OnNotification;

        //rais an event
        public void Notify()
        {
            if (OnNotification != null)
            {
                OnNotification();
            }
        }

        #region Constructor
        public Vehicle(int orderNo, string direction)
        {
            OrderNo = orderNo;
            Direction = direction;
        }

        public Vehicle()
        {

        }
        #endregion

        public void CreateVehicle()
        {
            int order;
            string direction;

            vehicleEvent.WaitOne();
            //sets the order number for a vehicle
            order = allVehicles.Count + 1;
            //get random direction for a vehicle from Directions array
            direction = Directions[rnd.Next(0, 2)];
            Vehicle vehicle = new Vehicle(order, direction);
            allVehicles.Add(vehicle);

            if (allVehicles.Count == Program.vehiclesNum)
            {
                OnNotification = Program.PrintVehiclesCreated;
                Notify();
            }
            //signal when all vehicles are created
            countdown.Signal();

            vehicleEvent.Set();

            //allow one at a time vehicle to cross the bridge
            Bridge.next.WaitOne();
            countdown.Wait();

            Bridge bridge = new Bridge();
            bridge.PassTheBridge(direction, order);
        }
    }
}
