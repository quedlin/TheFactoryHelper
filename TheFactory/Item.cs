using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TheFactory
{
    public class Item
    {

        enum ProductType { Sat, Sun, Mon, Tue, Wed, Thu, Fri };
        string[] names = new string[3] { "Matt", "Joanne", "Robert" };


        //public string type;
        public string name;
        public List<string> recipe;
        //public ProductType type

        private float sellValue;
        public float SellValue
        {
            get { return sellValue; }
            set { sellValue = value; }
        }





        public Item(string name, float newSellValue, string recipe)
        {
            //this.type = type;
            this.name = name;
            this.sellValue = newSellValue;
            this.recipe = new List<string>();

            //Regex.Replace(recipe, @"\s+", "");
            string[] items = recipe.Split(',');

            for (int i = 0; i < items.Length; i += 2)
            {
                //TODO: validation
                string what = items[i];
                float amount = Int32.Parse(items[i + 1]);

                for (int k = 0; k < amount; k++)
                {
                    this.recipe.Add(what);
                }
            }            
        }





    }
}
