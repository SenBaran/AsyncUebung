using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckDelivery.Common
{
    public class DeliveryTruck : DepotObject
    {
        public static int Capacity = 100;
        public static bool IsDriving { get; set; } = false;

        public bool IsFull { get; set; } = false;
        public static bool IsFilling { get; set; } = false;

        public Task<DeliveryTruck> FillingAsync(MainDepot depot)
        {
            if(depot == null)
                throw new ArgumentNullException(nameof(depot));
            if (depot.Capactiy < 100)
                throw new ArgumentException("MainDepot is Empty");
         

            return Task.Run(() =>
            {
               // Console.WriteLine("Is Filling Up....");
                IsFilling = true;
                //Task.Delay(1000).Wait();
                depot.Capactiy -= 100;
               // Console.WriteLine("Truck Filled Up");
                IsFilling = false;


                return new DeliveryTruck()
                {
                    IsFull = true,
                };
            });
        }

        public  Task<DeliveryTruck> DeliveryAsync(OutsideDepot depot)
        {
            if (depot == null)
                throw new ArgumentNullException(nameof(depot));
            if (depot.Capacity > 1000)
                throw new ArgumentException("Depot is Full");

            return Task.Run(() =>
            {
                //Console.WriteLine("Truck is Delivering...");
                IsDriving = true;
                Task.Delay(2 * depot.Distance * 1000).Wait();
                depot.Capacity += 100;
               // Console.WriteLine("Truck is back....");
                IsDriving = false;

                return new DeliveryTruck()
                {
                    IsFull = false,

                };
            });


        }
    }
}
