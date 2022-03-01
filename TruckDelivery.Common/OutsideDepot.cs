using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckDelivery.Common
{
    public class OutsideDepot : DepotObject
    {
        public static int MaxCapacity = 1_000;

        public int Capacity { get; set; }

        public int Distance { get; set; }



    }
}
