using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Zadatak_1
{
    class Program
    {
        public static int vehiclesNum;

        public static Stopwatch swApp = new Stopwatch();
        /// <summary>
        /// Method for generating number of vehicles
        /// </summary>
        /// <returns></returns>
        static int GetNoOfVehicle()
        {
            Random rnd = new Random();
            int noOfVehicles = rnd.Next(1, 16);
            return noOfVehicles;
        }

        /// <summary>
        /// Method for printing notifications about total number of vehicles and oreder and direction of each vehicle
        /// </summary>
        /// <param name="vehicles"></param>
        public static void PrintVehiclesCreated()
        {
            List<Vehicle> vehicles = Vehicle.allVehicles.ToList();

            Console.WriteLine("Total number of vehicles is: {0}", vehiclesNum);
            for (int i = 0; i < vehicles.Count; i++)
            {
                Console.WriteLine("Vehicle no " + vehicles[i].OrderNo + " goes to direction: " + vehicles[i].Direction);
            }
        }

        static void Main(string[] args)
        {
            swApp.Start();
            vehiclesNum = GetNoOfVehicle();
            List<Thread> threads = new List<Thread>();
            Vehicle vehicle = new Vehicle();

            for (int i = 0; i < vehiclesNum; i++)
            {
                Thread th = new Thread(vehicle.CreateVehicle);
                threads.Add(th);
            }

            foreach (var t in threads)
            {
                t.Start();
            }

            Console.ReadLine();
        }
    }
}
