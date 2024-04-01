namespace Sem2Lab3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            TaxiAggregator aggregator = new TaxiAggregator();
            Driver driver1 = new Driver()
            {
                ball = 127,
                HisCar = new Car() { Mark = "Toyota", ChildSeat = true, StateNumber = "1" },
                Load = true,
                Name = "1",
                Coordinates = new Tuple<double, double>(90, 95)
            };
            aggregator.AddNewTaxiDriver(driver1);

            Driver driver2 = new Driver()
            {
                ball = 123,
                HisCar = new Car() { Mark = "Reno", ChildSeat = true, StateNumber = "2" },
                Load = true,
                Name = "2",
                Coordinates = new Tuple<double, double>(90, 99)
            };
            aggregator.AddNewTaxiDriver(driver2);

            Driver driver3 = new Driver()
            {
                ball = 127,
                HisCar = new Car() { Mark = "Lada", ChildSeat = false, StateNumber = "3" },
                Load = true,
                Name = "3",
                Coordinates = new Tuple<double, double>(89, 100)
            };
            aggregator.AddNewTaxiDriver(driver3);



            Customer customer = new Customer() { Name = "1" };
            Address destination = new Address() { Coordinates = new Tuple<double, double>(55.994637, 92.798755), House = "", Street = "ИКИТ" }; 
            Address depurture = new Address() { Coordinates = new Tuple<double, double>(56.004256, 92.772263), House = "", Street = "ГОС" };


            aggregator.CreateAnOrder(customer, destination, depurture, true);
        }
    }
}
