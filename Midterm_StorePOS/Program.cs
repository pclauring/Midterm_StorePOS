using System;
using System.Collections;
using System.IO;


namespace Midterm_StorePOS
{

    class Program
    {
        const string FILENAME = "inventory.txt";
        static void Main(string[] args)
        {
            StreamReader menuMaker = new StreamReader(FILENAME);
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
            foreach (Product item in menu)
            {
                Console.WriteLine(item);
            }
        }
    }
}
