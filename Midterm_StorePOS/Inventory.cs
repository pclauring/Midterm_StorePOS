using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

namespace Midterm_StorePOS
{
    class Inventory
    {
        public static ArrayList GetMenu(string filename)
        {
            StreamReader menuMaker = new StreamReader(filename);
            ArrayList menu = new ArrayList();
            while (true)
            {

                string menuLine = menuMaker.ReadLine();
                if (string.IsNullOrEmpty(menuLine))
                {
                    break;
                }

                string[] itemParts = menuLine.Split('\t');
                string name = itemParts[0];
                string category = itemParts[1];
                string description = itemParts[2];
                // needs better validation
                double.TryParse(itemParts[3], out double price);
                // needs better validation
                int.TryParse(itemParts[4], out int quantity);

                Product menuItem = new Product(name, category, description, price, quantity);
                quantity = menuItem.Quantity;
                menu.Add(menuItem);

            }
            menuMaker.Close();



            return menu;
        }

        public static void AddToMenu (string filename, ArrayList Menu)
        {
            string input = Console.ReadLine();
            using (StreamWriter menuAdd = File.AppendText(filename))
            {
                menuAdd.WriteLine(input);
                
            }
            
        }
    }
}
