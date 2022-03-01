using TruckDelivery.Common;

namespace TruckDelivery.Logic
{
    public class DeliveryAsync
    {
        public static async Task<IEnumerable<DepotObject>> DeliveringAsync()
        {
            var result = new List<DepotObject>();

            MainDepot mainDepot = new MainDepot();

            DeliveryTruck truckA = new DeliveryTruck();
            DeliveryTruck truckB = new DeliveryTruck();
            DeliveryTruck truckC = new DeliveryTruck();

            var fillTasks = new List<Task<DeliveryTruck>>();

          

           


            OutsideDepot outsideDepotA = new OutsideDepot()
            {
                Distance = 1
            };
            OutsideDepot outsideDepotB = new OutsideDepot()
            {
                Distance = 2
            };
            OutsideDepot outsideDepotC = new OutsideDepot()
            {
                Distance = 4
            };



            var driveTasks = new List<Task>();


            driveTasks.Add(fillingDepot(mainDepot, truckA, outsideDepotA));
            driveTasks.Add(fillingDepot(mainDepot, truckB, outsideDepotB));
            driveTasks.Add(fillingDepot(mainDepot, truckC, outsideDepotC));

            await Task.WhenAny(driveTasks);

            driveTasks.Remove(driveTasks.First());
            Console.WriteLine("Fill A to B");
            driveTasks.Add(fillingDepot(mainDepot, truckA, outsideDepotB));
            await Task.WhenAny(driveTasks);
            await Task.WhenAny(driveTasks);
            driveTasks.Remove(driveTasks.First());
            driveTasks.Remove(driveTasks.Last());
            Console.WriteLine("Fill A and B to C");
            driveTasks.Add(fillingDepot(mainDepot, truckA, outsideDepotC));
            driveTasks.Add(fillingDepot(mainDepot, truckB, outsideDepotC));
            await Task.WhenAll(driveTasks);

            


            return result;
        }

        public static async Task fillingDepot(MainDepot depot, DeliveryTruck truck, OutsideDepot outdepot)
        {
            while(outdepot.Capacity < 1000)
            {
                await truck.FillingAsync(depot);
                await truck.DeliveryAsync(outdepot);
            }
        }
       
    }
}

