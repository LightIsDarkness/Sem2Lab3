using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem2Lab3
{
    internal class TaxiAggregator
    {
        private List<Customer> Customers = new List<Customer>();
        private List<Driver> Drivers = new List<Driver>();
        private List<Driver> DriversTemp = new List<Driver>();
        public void CreateAnOrder(Customer customer, Address destination, Address departure, bool ChildSeat) 
        {
            for (int i = 0; i < Drivers.Count; i++)
            {
                customer.IWantToTakeATaxi += Drivers[i].GoToOrder;
            }
            ArgsOfTaxiOrder argsOfTaxiOrder = new ArgsOfTaxiOrder(new Order()
            {
                Destination = destination,
                Departure = departure,
                NeedChildSeat = ChildSeat,
                Distance = Math.Sqrt(Math.Pow(destination.Coordinates.Item1 - departure.Coordinates.Item1, 2) +
                Math.Pow(destination.Coordinates.Item2 - departure.Coordinates.Item2, 2))
            });

            customer.TempOrder = argsOfTaxiOrder.Order; 

            customer.TakeATaxi();

            if (DriversTemp.Count > 0)
            {
                double maxballs = -1;
                Driver tDriver = new();
                for (int i = 0; i < DriversTemp.Count; i++)
                {
                    if (DriversTemp[i].ball > maxballs)
                    {
                        tDriver = DriversTemp[i];
                        maxballs = DriversTemp[i].ball;
                    }
                }
                Console.WriteLine($"Водитель {tDriver.Name} на {tDriver.HisCar.Mark} с гос. номером {tDriver.HisCar.StateNumber}\n" +
                    $" отправилась на заказ: \n от {destination.Street} {destination.House} {destination.Coordinates.Item1} " +
                    $"{destination.Coordinates.Item2}\n до {departure.Street} {departure.House} {departure.Coordinates.Item1} " +
                    $"{departure.Coordinates.Item2}\n");

                tDriver.ball += customer.TempOrder.Distance; // Начисляем баллы

                DriversTemp.Clear();
                RemoveTaxiDriver(tDriver);

            }
            else
            {
                Console.WriteLine("Свободных таксистов нет");
            }
        }
        public void AddNewTaxiDriver(Driver driver)
        {
            driver.RespondedToOrder += () => DriversTemp.Add(driver);
            Drivers.Add(driver);
        }

        public void RemoveTaxiDriver(Driver driver)
        {

            Drivers.Remove(driver);
            DriversTemp.Remove(driver);

        }
    }
}
