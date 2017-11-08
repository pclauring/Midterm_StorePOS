﻿using System.Collections;
using System;


namespace Midterm_StorePOS
{
    class Cart
    {
        private ArrayList userCart;

        public ArrayList UserCart
        {
            get { return userCart; }
            set { userCart = value; }
        }

        private ArrayList quantityOfItems;

        public ArrayList QuantityOfItems
        {
            get { return quantityOfItems; }
            set { quantityOfItems = value; }
        }


        public Cart()
        {
            ArrayList cart = new ArrayList();
            ArrayList quantities = new ArrayList();
            userCart = cart;
            QuantityOfItems = quantities;
        }

        public static void AddtoCart(Cart cart, Product selection, int quantity)
        {
            cart.userCart.Add(selection);
            cart.quantityOfItems.Add(quantity);
        }

        public double GetTotal()
        {
            double total = 0;
            int index = 0;
            foreach (Product item in userCart)
            {
                double price = item.Price;
                int quantity = (int)quantityOfItems[index];
                index++;
                total += (price * quantity);
            }
            return total;
        }

        public string GetFormattedTotal()
        {
            return FormatNumber(GetTotal());
        }

        private string FormatNumber(double x)
        {
            return string.Format("{0:0.00}", x);
        }

    }


}