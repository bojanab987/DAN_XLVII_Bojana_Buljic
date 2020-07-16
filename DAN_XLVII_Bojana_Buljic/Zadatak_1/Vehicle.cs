using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak_1
{
    enum Direction { north, south }

    class Vehicle
    {
        //random instance for generating random directions
        Random rnd = new Random();

        #region Vehicle properties
        //public string Name { get; set; }
        public int OrderNo { get; set; }
        /// <summary>
        /// direction property of the vehicle
        /// </summary>
        private string direction;
        public string DirectionV
        {
            get
            {
                return direction;
            }
            set
            {
                direction = ((Direction)rnd.Next(0, Enum.GetNames(typeof(Direction)).Length)).ToString();
            }

        }
        #endregion

        #region Constructor
        
        public Vehicle()
        {


        }
        public Vehicle(int order)
        {
            OrderNo = order;
            
        }
        #endregion
    }
}
