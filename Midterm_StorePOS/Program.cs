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
                Product menuItem = new Product();
                string menuLine = menuMaker.ReadLine();
                if (menuLine == null || menuLine == "")
                {
                    break;
                }

                string[] itemParts = menuLine.Split('\t');
                itemParts[0] = menuItem.Name;
                itemParts[1] = menuItem.Category;
                itemParts[2] = menuItem.Description;
                // needs better validation
                double.TryParse(itemParts[3], out double price);
                price = menuItem.Price;
                // needs better validation
                int.TryParse(itemParts[4], out int quantity);
                quantity = menuItem.Quantity;
                menu.Add(menuItem);

            }
            menuMaker.Close();
            foreach (Product item in menu)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}
