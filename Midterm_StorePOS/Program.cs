using System;
using System.Collections;


namespace Midterm_StorePOS
{

    class Program
    {
        const string FILENAME = "inventory.txt";
        static void Main(string[] args)
        {
            Checkout checkout = new Checkout();
            Checkout.GetPayment();
            //converts text file inventory into Arraylist menu
            ArrayList menu = Inventory.GetMenu(FILENAME);
            Cart cart = new Cart();

            //generate empty ArrayList to hold items selected from cart
            while (true)
            {

                int itemNum = 0;
                foreach (Product item in menu)
                {
                    itemNum++;
                    Console.WriteLine($"{itemNum}. {item}");
                }
                Console.WriteLine($"{itemNum + 1}. Checkout");
                Console.WriteLine();

                int selection = Validator.GetValidSelection($"Please select a menu option?(1 - {itemNum + 1}): ", itemNum + 1, 1);

                if (selection > 0 && selection < itemNum + 1)
                {
                    Console.Write($"You selected\n{menu[selection - 1]}\nWould you like to add to cart (Y/N)?: ");
                    bool buy = Validator.GetYesorNo();
                    if (buy)
                    {
                        int quantity = Validator.GetValidSelection($"How many would you like to buy (1 - {((Product)menu[selection - 1]).Quantity}): ", ((Product)menu[selection - 1]).Quantity, 1);
                        Cart.AddtoCart(cart, (Product)menu[selection - 1], quantity);
                        Console.WriteLine($"{quantity} {((Product)menu[selection - 1]).Name}(s) added to cart.");
                    }
                    else
                    {
                        Console.WriteLine($"{menu[selection - 1]} not added to cart.");
                    }



                }
                if (selection == itemNum + 1)
                {
                    int index = 0;
                    foreach (Product item in cart.UserCart)
                    {
                        Console.WriteLine($"{item.Name}(s) {item.Price} {(int)cart.QuantityOfItems[index]}");
                        index++;
                    }

                    Console.WriteLine($"{cart.GetFormattedTotal()} is the subtotal");
                }
            }

        }


    }
}
