using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm_StorePOS
{
    class Checkout
    {
        static int grandtotal = 0;
        static double total = 0;
        static double subtotal = 0;
        static double change = 0;

        public static double GetPayment(double total)
        {
            Console.WriteLine("How would you like to pay?\n1. Cash\n2. Credit\n3. Check");
            string input = Console.ReadLine();
            int.TryParse(input, out int Choice);
            if (Choice == 1)
            {
                Console.WriteLine($"Please insert ${total}. If you have coins, please insert them first.");
                string input2 = Console.ReadLine();
                double.TryParse(input2, out double change);
                subtotal = total - change;

            }
            else if (Choice == 2)
            {
                Console.WriteLine("Please choose:\n1. Visa\n2. Mastercard\n3. Discover.");
                string input3 = Console.ReadLine();
                int.TryParse(input3, out int CardChoice);
                bool verify = false;

                while (!verify)
                if (CardChoice == 1)
                {


                    Console.WriteLine("Please enter your 16 Digit Card Number.");
                    string cardNum = Console.ReadLine();
                    verify = VerifyCreditCard(cardNum);
                    

                    Console.WriteLine("Please enter the expiration date (MM/YY)");
                    string cardExpire = Console.ReadLine();
                    Console.WriteLine((cardExpire));

                    Console.WriteLine("Please enter your CVV (last 3 digits on the back of the card)");
                    int cardCVV = Console.Read();
                    verify = VerifyCardCVV(cardCVV);

                }
                else if (CardChoice == 2)
                {
                    Console.WriteLine("Please enter your 16 Digit Card Number.");
                    string cardNum = Console.ReadLine();
                    Console.WriteLine(VerifyCreditCard(cardNum));
                    string cardNumber = Console.ReadLine();


                    Console.WriteLine("Please enter the expiration date (MM/YY)");
                    string cardExpire = Console.ReadLine();
                    Console.WriteLine(cardExpire);

                    Console.WriteLine("Please enter your CCV (last 3 digits on the back of the card)");
                    string cardCCV = Console.ReadLine();


                    Console.WriteLine($"Thank you! ${total} has been charged to your credit card. Your payment is complete.");
                }
                else if (CardChoice == 3)
                {
                    Console.WriteLine("Please enter your 16 Digit Card Number.");
                    string cardNum = Console.ReadLine();
                    Console.WriteLine(VerifyCreditCard(cardNum));
                    string cardNumber = Console.ReadLine();


                    Console.WriteLine("Please enter the expiration date (MM/YY)");
                    string cardExpire = Console.ReadLine();
                    Console.WriteLine(cardExpire);

                    Console.WriteLine("Please enter your CCV (last 3 digits on the back of the card)");
                    string cardCCV = Console.ReadLine();


                    Console.WriteLine($"Thank you! ${total} has been charged to your credit card. Your payment is complete.");
                }
            }
            else if (Choice == 3)
            {
                Console.WriteLine("Please enter your check number.");
            }
            Console.WriteLine($"Thank you! ${total} has been charged to your credit card. Your payment is complete.");
            return grandtotal = Console.Read();
        }
        public static bool VerifyCreditCard(string cardNumber)
        {
            cardNumber = cardNumber.Replace("-", "").Replace(" ", "");
            int[] numbers = new int[cardNumber.Length];
            for (int i = 0; i < cardNumber.Length; i++)
            {
                numbers[i] = Int32.Parse(cardNumber.Substring(i, 1));
            }
            int sum = 0;
            bool valid = true;
            for (int j = numbers.Length - 1; j >= 0; j--)
            {
                int Number = numbers[j];
                if (valid)
                {
                    Number *= 2;
                    if (Number > 9)
                    {
                        Number -= 9;
                    }
                }
                sum += Number;
                valid = !valid;
            }
            return sum % 10 == 0;
        }

        public static bool VerifyCardExpire(string cardExpire)
        {
            cardExpire = cardExpire.Replace("/", "");
            int[] numbers = new int[cardExpire.Length];
            for (int i = 0; i < cardExpire.Length; i++)
            {
                numbers[i] = Int32.Parse(cardExpire.Substring(i, 1));
            }
        }

        public static bool VerifyCardCVV(int cardCVV)
        {
            cardCVV = Console.Read();

            if (cardCVV >= 0 && cardCVV <= 999 )
            {
                return true;
            }
            else
            {
                return VerifyCardCVV(cardCVV);
                
            }
        }
        
        public double GetSalesTax (double total)
        {
           
            return total;
        }
    }
}