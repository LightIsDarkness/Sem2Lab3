using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem2Lab3
{
    public class Customer
    {
        public string Name { get; set; }
        public Order TempOrder { get; set; }
        
        public delegate void del(ArgsOfTaxiOrder order);
        public event del IWantToTakeATaxi;
        public void TakeATaxi()
        {
            IWantToTakeATaxi.Invoke(new ArgsOfTaxiOrder(TempOrder));
        }
    }
}
