using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFactory
{
    public class Supply
    {

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private float buyValue;
        public float BuyValue
        {
            get { return buyValue; }
            set { buyValue = value; }
        }

        public Supply(string newName, float newBuyValue)
        {
            this.name = newName;
            this.buyValue = newBuyValue;
        }


    }
}
