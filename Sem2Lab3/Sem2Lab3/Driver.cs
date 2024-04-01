using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem2Lab3
{
    public class Driver
    {
        public string Name { get; set; }
        public Tuple<double, double>? Coordinates;
        public bool Load { get; set; }
        public Car HisCar { get; set; }
        public delegate void NotificationOfDriver();

        public event NotificationOfDriver? RespondedToOrder;

        public ArgsOfTaxiOrder? ArgsOfTaxiOrder;

        private int MaxDistant = 80;
        public double ball;

        public void GoToOrder(ArgsOfTaxiOrder argsOfTaxiOrder)
        {
            double distance = Math.Sqrt(Math.Pow(Coordinates.Item1 - argsOfTaxiOrder.Order.Destination.Coordinates.Item1, 2) + 
                              Math.Pow(Coordinates.Item2 - argsOfTaxiOrder.Order.Destination.Coordinates.Item2, 2));

            if (Load && (argsOfTaxiOrder.Order.NeedChildSeat & HisCar.ChildSeat | argsOfTaxiOrder.Order.NeedChildSeat == false) & distance < MaxDistant)
            {
                RespondedToOrder?.Invoke();
            }
        }
    }
}
