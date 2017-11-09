using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Midterm_StorePOS
{
    class Checkout
    {

        public static void GetPayment(double grandTotal)
        {
            Console.WriteLine("How would you like to pay?\n1. Cash\n2. Credit\n3. Check");
            string input = Console.ReadLine();
            int.TryParse(input, out int Choice);
            if (Choice == 1)
            {
                Console.WriteLine($"Please insert " + string.Format("${0:0.00}", grandTotal) + ". If you have coins, please insert them first.");
                string input2 = Console.ReadLine();
                double.TryParse(input2, out double payment);
                double change = payment - grandTotal;
                Console.Write("Please remember to take your receipt and your change: " + string.Format("${0:0.00}",change) + "\n");

            }
            else if (Choice == 2)
            {
                Console.WriteLine("Please choose:\n1. Visa\n2. Mastercard\n3. Discover");
                input = Console.ReadLine();
                //TODO: add validation
                bool verify = false;
                while (!verify)
                {
                    Console.WriteLine("Please enter your 16 Digit Card Number.");
                    string cardNum = Console.ReadLine();
                    verify = VerifyCreditCard(cardNum);
                }
                verify = false;
                while (!verify)
                {
                    Console.WriteLine("Please enter the expiration date (MM/YYYY)");
                    string cardExpire = Console.ReadLine();
                    verify = VerifyCardExpire(cardExpire);
                }
                verify = false;
                while (!verify)
                {
                    Console.WriteLine("Please enter your CVV (last 3 digits on the back of the card)");
                    string cardCVV = Console.ReadLine();
                    verify = VerifyCardCVV(cardCVV);
                }

                    Console.WriteLine("Thank you! " + string.Format("${0:0.00}", grandTotal) +" has been charged to your credit card. Your payment is complete.");
            }
            else if (Choice == 3)
            {
                Console.WriteLine("Please enter your check number.");
                input = Console.ReadLine();
                Console.WriteLine("Thank you! You should see " + string.Format("${0:0.00}", grandTotal) + " charged to your account in 1-3 business days.");
            }
            //return grandtotal = Console.Read();
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
            bool valid = false;
            for (int j = numbers.Length - 1; j >= 0; j--)
            {
                int digit = numbers[j];
                if (valid)
                {
                    digit *= 2;
                    if (digit > 9)
                    {
                        digit -= 9;
                    }
                }
                sum += digit;
                valid = !valid;
            }
            return sum % 10 == 0;
        }

        public static bool VerifyCardExpire(string ExpirDate)
        {
            Regex monthCheck = new Regex(@"^(0[1-9]|1[0-2])$");
            Regex yearCheck = new Regex(@"^20[0-9]{2}$");
            string[] dateParts = ExpirDate.Split('/');
            if (!monthCheck.IsMatch(dateParts[0]) || !yearCheck.IsMatch(dateParts[1]))
            {
                return false;
            }
            int year = int.Parse(dateParts[1]);
            int month = int.Parse(dateParts[0]);
            int lastDateOfExpiryMonth = DateTime.DaysInMonth(year, month);
            DateTime cardExpiry = new DateTime(year, month, lastDateOfExpiryMonth, 23, 59, 59);

            return (cardExpiry > DateTime.Now && cardExpiry < DateTime.Now.AddYears(7));
        }

        public static bool VerifyCardCVV(string cardCVV)
        {
            Regex cvv = new Regex(@"^[0-9]{3}");
            if (cardCVV.Length > 3)
            {
                return false;
            }
            else if (!cvv.IsMatch(cardCVV))
            {
                return false;
            }
            return true;
                
            
        }
        
        public double GetSalesTax (double total)
        {
            double salestax = total * .06;
            return salestax;
        }
        
        public static string GetFormattedSalesTax (double salestax)
        {
            return string.Format("\t\t\t\t\t\t\t\t\t{0:0.00}", salestax);
        }
        public static double GetGrandTotal (double total)
        {
            double grandtotal = (total)*.06 + total;
            return grandtotal;
        }
        public static string GetFormattedGrandTotal(double grandtotal)
        {
            return string.Format("\t\t\t\t\t\t\t\t\t{0:0.00}", grandtotal);
        }
    }
}