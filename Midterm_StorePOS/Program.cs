using System;
using System.Collections;


namespace Midterm_StorePOS
{

    class Program
    {
        const string FILENAME = "inventory.txt";
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to THE grocery store!!");
            //converts text file inventory into Arraylist menu
            ArrayList menu = Inventory.GetMenu(FILENAME);
            Cart cart = new Cart();

            //generate empty ArrayList to hold items selected from cart
            while (true)
            {
                Console.WriteLine("________________________________________________________________________________________________________");
                Console.WriteLine("Item # \tProduct \t\tCategory\tDescription\t\t\t\tPrice\tQuantity");
                Console.WriteLine("________________________________________________________________________________________________________");


                int itemNum = 0;
                foreach (Product item in menu)
                {
                    itemNum++;
                    Console.WriteLine($"{itemNum}. {item}");
                }
<<<<<<< HEAD
                Console.WriteLine($"{itemNum+1}. \tCheckout");
                Console.WriteLine("========================================================================================================");

                int selection = Validator.GetValidSelection($"\nSelect an item by the Item # or press {itemNum +1} to checkout?(1 - {itemNum + 1}):  ", itemNum+1, 1);
=======
                Console.WriteLine($"{itemNum + 1}. Checkout");
                Console.WriteLine();

                int selection = Validator.GetValidSelection($"Please select a menu option?(1 - {itemNum + 1}): ", itemNum + 1, 1);
>>>>>>> cbbe28d08afc93982f14b24b34965d3e76b9de29

                if (selection > 0 && selection < itemNum + 1)
                {
                    Console.Write($"\tYou selected\n{menu[selection - 1]}\nWould you like to add to cart (Y/N)?: ");
                    bool buy = Validator.GetYesorNo();
                    if (buy)
                    {
                        int quantity = Validator.GetValidSelection($"\nHow many would you like to buy (1 - {((Product)menu[selection - 1]).Quantity}):  ", ((Product)menu[selection - 1]).Quantity, 1);
                        Cart.AddtoCart(cart, (Product)menu[selection - 1], quantity);
                        Console.WriteLine($"\n{quantity} {((Product)menu[selection - 1]).Name}(s) added to your cart.");
                    }
                    else
                    {
                        Console.WriteLine($"{menu[selection - 1]} was not added to cart.");
                    }
<<<<<<< HEAD
=======



>>>>>>> cbbe28d08afc93982f14b24b34965d3e76b9de29
                }
                if (selection == itemNum + 1)
                {
                    int index = 0;
                    foreach (Product item in cart.UserCart)
                    {
                        Console.WriteLine($"{item.Name}(s) {item.Price} {(int)cart.QuantityOfItems[index]}");
                        index++;
                    }
<<<<<<< HEAD
                    Console.WriteLine($"\t\t\t\t\t\t\t\t\t${cart.GetFormattedTotal()} is the total");
=======

                    Console.WriteLine($"{cart.GetFormattedTotal()} is the subtotal");
>>>>>>> cbbe28d08afc93982f14b24b34965d3e76b9de29
                }
            }

        }


    }
}
