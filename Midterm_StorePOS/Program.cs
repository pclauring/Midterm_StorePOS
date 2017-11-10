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
            bool keepShopping = true;

            while (keepShopping)
            {

                Cart cart = new Cart();

                //generate empty ArrayList to hold items selected from cart
                bool checkout = false;
                while (!checkout)
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
                    Console.WriteLine($"{itemNum + 1}. \tCheckout");
                    Console.WriteLine($"{itemNum + 2}. \tAdd New Product");

                    Console.WriteLine("========================================================================================================");

                    int selection = Validator.GetValidSelection($"\nSelect an item by the Item # or enter {itemNum + 1} to checkout?(1 - {itemNum + 2}):  ", itemNum + 2, 1);

                    if (selection > 0 && selection < itemNum + 1)
                    {
                        Console.Write($"\tYou selected\n{menu[selection - 1]}\n\nWould you like to add to cart (Y/N)?: ");
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


                    }
                    if (selection == itemNum + 1)
                    {
                        checkout = true;
                        
                        if (cart.UserCart.Count == 0)
                        {
                            Console.WriteLine("You don't have anything in your cart!");
                        }
                        else
                        {
                            Cart.GetReceipt(cart);
                            Checkout.GetFormattedSalesTax(cart.GetTotal());
                            Checkout.GetFormattedGrandTotal(cart.GetTotal());
                            Checkout.GetPayment(Checkout.GetGrandTotal(cart.GetTotal()));
                            Cart.GetCartItemized(cart);
                        }

                        checkout = true;

                        Console.Write("Would you like to keep shopping? (Y/N): ");
                        keepShopping = Validator.GetYesorNo();
                    }
                    if (selection == itemNum + 2)
                    {
                        Console.WriteLine("Please enter what you wanted to add to the store.\nEnter the item name, category, description, price (ex:13.34), and quantity with a single tab in beweteen each part.");
                        Inventory.AddToMenu(FILENAME, menu);
                        menu = Inventory.GetMenu(FILENAME);
                    }
                }
            } Console.WriteLine("Thank you for shopping at THE Grocery Store!");
        }
    }
}
            

