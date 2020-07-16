using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak_1
{
    class Program
    {
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
        public static void PrintVehiclesCreated(Vehicle[] vehicles)
        {
            Console.WriteLine("Total number of vehicles is: {0}", vehicles.Length);
            for (int i = 0; i < vehicles.Length; i++)
            {
                Console.WriteLine("Vehicle no " + vehicles[i].OrderNo + "goes to direction: " + vehicles[i].DirectionV);
            }
        }

        static void Main(string[] args)
        {
            Stopwatch swApp = new Stopwatch();
            swApp.Start();
            int num = GetNoOfVehicle();
            Vehicle[] vehicles = new Vehicle[num];
            for (int i = 0; i < num; i++)
            {
                Vehicle car = new Vehicle(i + 1);
                vehicles[i] = car;
            }
            PrintVehiclesCreated(vehicles);

            swApp.Stop();
            Console.WriteLine(swApp.ElapsedMilliseconds);
        }
    }
}
