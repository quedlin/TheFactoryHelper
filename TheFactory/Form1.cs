using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheFactory
{
    public partial class Form1 : Form
    {
        public List<Supply> supplies;   //TODO: egyiket törölni
        public Dictionary<string, float> supplyMap;

        public List<Item> productTier1;
        public List<Item> productTier2;
        public List<Item> productTier3;
        public List<Item> productTier4;


        class ProductListItem
        {
            public string Name { get; set; }
            public string DisplayName { get; set; }
            public float SellValue { get; set; }
        }

        /*
        yourListBox.DisplayMember = "DisplayName";
        yourListBox.ValueMember = "Name";

        yourListBox.Items.Add(new ProductListItem {
            Name = "FooName",
            DisplayName = "FooName",
            SellValue = "FooId"
        });
        */
        public bool isSupply(string name)
        {
            for (int i=0; i<supplies.Count; i++)
            {
                if (supplies[i].Name.Equals(name)) return true;
            }
            return false;
        }

        public int findItem(List<Item> list, string name)
        {
            int n = -1;
            for (int i = 0; i < list.Count; i++)
            {
                if (name.Equals(list[i].name))
                {
                    n = i;
                    break;
                }
            }
            return n;
        }

        public struct ItemCountPair
        {
            public string name;
            public int num;
        };

        public List<ItemCountPair> aggregate(List<string> list)
        {
            List<ItemCountPair> listResult = new List<ItemCountPair>();

            for (int i=0; i<list.Count; i++)
            {
                string item = list[i];

                bool alreadyAdded = false;
                for (int k = 0; k < listResult.Count; k++)
                {
                    if (listResult[k].name.Equals(item))
                    {
                        alreadyAdded = true;
                        //listResult[k].num += 1;
                        ItemCountPair tmp = listResult[k];
                        tmp.num += 1;
                        listResult[k] = tmp;

                    }


                }
                if (!alreadyAdded)
                {
                    ItemCountPair newPair;
                    newPair.name = item;
                    newPair.num = 1;
                    listResult.Add(newPair);
                }

            }



                return listResult;
        }

        public float getSupplyValue(string supplyName)
        {
            for (int i = 0; i < supplies.Count; i++)
            {
                if (supplies[i].Name.Equals(supplyName))
                    return supplies[i].BuyValue;
            }
            return 0.0f;
        }

        public float getSupplyCosts(List<ItemCountPair> supplyList)
        {
            float sum = 0.0f;

            for (int i=0; i<supplyList.Count; i++)
            {
                sum += getSupplyValue(supplyList[i].name) * supplyList[i].num;
            }

            return sum;
        }

        
        public Form1()
        {
            InitializeComponent();

            supplies = new List<Supply>();
            supplies.Add(new Supply("Cardboard", 0.24f));
            supplies.Add(new Supply("Concrete", 4.19f));
            supplies.Add(new Supply("Magnet", 5.68f));
            supplies.Add(new Supply("Metal", 3.40f));
            supplies.Add(new Supply("Paint", 2.26f));
            supplies.Add(new Supply("Plastic", 0.60f));
            supplies.Add(new Supply("Rare metal", 7.81f));
            supplies.Add(new Supply("Rubber", 1.10f));
            supplies.Add(new Supply("Wire", 1.71f));

            supplyMap = new Dictionary<string, float>();
            supplyMap.Add("Cardboard", 0.24f);
            supplyMap.Add("Concrete", 4.19f);
            supplyMap.Add("Magnet", 5.68f);
            supplyMap.Add("Metal", 3.40f);
            supplyMap.Add("Paint", 2.26f);
            supplyMap.Add("Plastic", 0.60f);
            supplyMap.Add("Rare metal", 7.81f);
            supplyMap.Add("Rubber", 1.10f);
            supplyMap.Add("Wire", 1.71f);
            

            productTier1 = new List<Item>();
            productTier1.Add(new Item("Adv concrete", 14.47f, "Concrete,2,Metal,2"));
            productTier1.Add(new Item("Belt", 2.60f, "Rubber,2"));
            productTier1.Add(new Item("Box", 2.21f, "Cardboard,4"));
            productTier1.Add(new Item("Cable", 3.28f, "Metal,1"));
            productTier1.Add(new Item("Circuit", 3.54f, "Plastic,2,Wire,1"));
            productTier1.Add(new Item("Gear", 6.56f, "Metal,2"));
            productTier1.Add(new Item("Hose", 2.60f, "Rubber,2"));
            productTier1.Add(new Item("Metal wheel", 6.56f, "Metal,2"));
            productTier1.Add(new Item("Motor", 17.40f, "Magnet,2,Metal,1,Wire,2"));
            productTier1.Add(new Item("Plastic wheel", 1.72f, "Plastic,2"));
            productTier1.Add(new Item("Pump", 8.72f, "Metal,2,Plastic,1,Rubber,1"));
            productTier1.Add(new Item("Garden gnome", 15.90f, "Concrete,1,Paint,1,Box,1"));
            productTier1.Add(new Item("Speakers", 29.42f, "Magnet,2,Plastic,2,Wire,1,Box,1"));
            productTier1.Add(new Item("Toaster", 22.74f, "Metal,2,Wire,2,Box,1"));


            productTier2 = new List<Item>();            
            productTier2.Add(new Item("Air gun", 19.78f, "Metal,4,Hose,2"));
            productTier2.Add(new Item("Arm", 51.68f, "Metal,2,Circuit,1,Motor,2"));
            productTier2.Add(new Item("Conveyor", 102.58f, "Belt,1,Gear,2,Metal wheel,8,Motor,1"));
            productTier2.Add(new Item("Lifter", 55.46f, "Metal,3,Cable,2,Hose,2,Motor,1,Pump,1"));
            productTier2.Add(new Item("Logic unit", 26.75f, "Wire,5,Circuit,4"));
            productTier2.Add(new Item("Mover", 113.65f, "Metal,3,Gear,4,Metal wheel,4,Motor,2"));
            productTier2.Add(new Item("Road", 49.80f, "Concrete,4,Adv concrete,2"));
            productTier2.Add(new Item("Support", 40.53f, "Metal,2,Adv concrete,2"));
            productTier2.Add(new Item("Thing-a-ma-jig", 61.02f, "Circuit,3,Hose,2,Motor,1,Pump,2"));
            productTier2.Add(new Item("Widget", 14.78f, "Metal,1,Plastic,4,Wire,2,Circuit,1"));
            productTier2.Add(new Item("Toy car", 35.38f, "Metal,1,Paint,1,Plastic,3,Plastic wheel,4,Box,1"));
            productTier2.Add(new Item("Water gun", 29.62f, "Paint,1,Plastic,6,Hose,2,Box,1"));
            

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //TODO: sell valuevel kiegészíteni
            this.listBox1.DisplayMember = "DisplayName";
            this.listBox1.ValueMember = "Name";

            
            for (int i = 0; i < productTier1.Count; i++)
            {
                //this.listBox1.Items.Add(productTier1[i].name);
                this.listBox1.Items.Add(new ProductListItem
                {
                    Name = productTier1[i].name,
                    DisplayName = productTier1[i].name + " " + productTier1[i].SellValue + "$",
                    SellValue = productTier1[i].SellValue
                });
            }


            this.listBox1.Items.Add("-");

            for (int i = 0; i < productTier2.Count; i++)
            {
                //this.listBox1.Items.Add(productTier2[i].name);
                this.listBox1.Items.Add(new ProductListItem
                {
                    Name = productTier2[i].name,
                    DisplayName = productTier2[i].name + " " + productTier2[i].SellValue + "$",
                    SellValue = productTier2[i].SellValue
                });

            }



        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            int type = -1;
            int n = -1;

            float sellValue = (float)(((ProductListItem)(listBox1.SelectedItem))).SellValue;

            /*
            for (int i = 0; i < productTier1.Count; i++)
            {
                if (listBox1.SelectedItem.Equals(productTier1[i].name))
                {
                    type = 1;
                    n = i;
                    break;
                }
            }
            */
            int n1 = findItem(productTier1, (string)(((ProductListItem)(listBox1.SelectedItem))).Name);
            if (n1!=-1)
            {
                type = 1;
                n = n1;
            }


            for (int i = 0; i < productTier2.Count; i++)
            {
                if (((ProductListItem)(listBox1.SelectedItem)).Name.Equals(productTier2[i].name))
                {
                    type = 2;
                    n = i;
                    break;
                }
            }

            // If no real product has been selected (for example a list separator)
            if (type == -1) return;

            // Clear the results text box
            textBox1.Text = "";
            //textBox1.Text = textBox1.Text + "Type: " + type + Environment.NewLine;
            //textBox1.Text = textBox1.Text + "n: " + n + Environment.NewLine;


            if (type == 1)
            {
                Item item = productTier1[n];
                List<string> recipeFinal0 = new List<string>();
                for (int k = 0; k < item.recipe.Count; k++)
                {
                    //recipeFinal0.Add(item.recipe[k]);
                    string recipeItem = item.recipe[k];
                    if (isSupply(recipeItem)) recipeFinal0.Add(recipeItem);
                    else
                    {
                        int tmpN1 = findItem(productTier1, recipeItem);
                        if (tmpN1 != -1)
                        {
                            recipeFinal0.AddRange(productTier1[tmpN1].recipe);
                        }

                    }

                }
                List<ItemCountPair> listResult = aggregate(recipeFinal0);
                for (int i=0; i<listResult.Count; i++)
                {
                    textBox1.Text = textBox1.Text + "-" + listResult[i].name + " " + listResult[i].num + Environment.NewLine;
                }
                
                textBox1.Text = textBox1.Text + "Buy value: " + getSupplyCosts(listResult) + Environment.NewLine;

            }
            else if (type == 2)
            {
                Item item = productTier2[n];
                List<string> recipeFinal0 = new List<string>();  // Here it needs only one
                for (int k = 0; k < item.recipe.Count; k++)
                {
                    string recipeItem = item.recipe[k];
                    if (isSupply(recipeItem)) recipeFinal0.Add(recipeItem);
                    else
                    {
                        int tmpN1 = findItem(productTier1, recipeItem);
                        if (tmpN1!=-1)
                        {
                            recipeFinal0.AddRange(productTier1[tmpN1].recipe);
                        }

                    }



                }
                for (int k=0; k<recipeFinal0.Count; k++)
                {
                    textBox1.Text = textBox1.Text + "-" + recipeFinal0[k] + Environment.NewLine;
                }


            }














            }
    }
}
