using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ArghoC_Assign1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product product1 = new Product("Disposable Masks Pack ", 12.99,0);//calling the constructor
            Product product2 = new Product("Hand Sanitizer ",6.99,0);//used 0 as initial quantity
            Product product3 = new Product("Printer Paper Stack ", 17.99, 0);//as quantity is read-write, we change it later
            WriteLine("The products we have in stock are..."+"\n"+
                        product1.ToString()+"\n"+product2.ToString()+"\n"+product3.ToString()+"\n"+"\n"+"\n");//called the tostring() to display the product information
            WriteLine("Let's begin by entering the quantities for each of these products");
            UpdateProductQty(product1);//update method call with parameter product1
            UpdateProductQty(product2);
            UpdateProductQty(product3);

            if(product1.Quantity>0)//checking the quantity. This will check if the user had enterd a valid input or not. Here anything above 0 is valid.
            {
                WriteLine("The quantities for each product has been entered");
            }
            else if(product2.Quantity>0)
            {
                WriteLine("The quantities for each product has been entered");
            }
            else if (product3.Quantity > 0)
            {
                WriteLine("The quantities for each product has been entered");
            }
            else
            {
                WriteLine("Enter a valid quantity");
            }
            ChooseAction(product1, product2, product3);

        }

        static void UpdateProductQty(Product anyProduct)//this is for updating the quantity. It will take an input form the used and parse it as an integer.
        {
           
            
            Write("Enter the quantity for "+ anyProduct.ProductName+ ": ");
            anyProduct.Quantity = int.Parse(ReadLine());
        }

       static void ChooseAction(Product product1, Product product2, Product product3)//this mehtod will ask the user to choose an action.
        {
            WriteLine("\n", "\n", "\n");
            WriteLine("What would you like to do?");
            Write("Press 1 for View Cart, Press 2 for Update Cart, Press 3 for quitting the application: ");
            int option = int.Parse(ReadLine());
            if(option == 1)//if the user choose 1 then it will show the entire cart details by calling the ViewCart() method.
            {
                ViewCart(product1,product2,product3);
            }
            else if(option == 2)//if the user choose 2 then it will take the user to update quantity by calling the UpdateCart() method.
            {
                UpdateCart(product1, product2, product3);
            }
            else if(option == 3)//if the user choose 3 then the program will clear the entries in the console window and display a message.
            {
                Console.Clear();
                WriteLine("Thank you for placing an order with us. Good Bye!");
            }
            else//if the user doesn't choose any of the options then it will give an error message.
            {
                WriteLine("Enter a valid choise!");
            }
        }
        static void ViewCart(Product product1,Product product2,Product product3)//this method is used to show the output in a specific format.
        {
            double totalAfterDiscount = GetCartTotalSummary(product1, product2, product3, out double totalBeforeDiscount, out double discountAmount);//GetCartTotalSummary is called to load the properties.
            WriteLine("\n", "\n", "\n");//this is for adding space between the messages.
            WriteLine("Okay! let's view your order!");
            string asterikline = new string('*', 70);
            WriteLine("\n"+"\n" + asterikline);
            WriteLine("*{0, 30}: {1,-36}*", "Product Name: ", product1.ProductName);//string astrickline = new string('*',70); wr
            WriteLine("*{0, 30}: {1,-36}*", "Price Per Unit: ", product1.PricePerUnit);
            WriteLine("*{0, 30}: {1,-36}*", "Quantity: ", product1.Quantity);
            WriteLine("*{0, 30}: {1,-36}*", "Product Before Tax: ", product1.ProductTotalBeforeTax);//writeline("*{0,30}: {-1,27}*,"Product Name: ", product1.ProductName)
            WriteLine("*{0, 30}: {1,-36}*", "Product Tax: ", product1.ProductTax);
            WriteLine("*{0, 30}: {1,-36}*", "Product After Tax: ", product1.ProductTotalAfterTax);
            WriteLine("*{0,30} {1,-37}*","","");
            WriteLine("*{0, 30}: {1,-36}*", "Product Name: ", product2.ProductName);
            WriteLine("*{0, 30}: {1,-36}*", "Price Per Unit: ", product2.PricePerUnit);
            WriteLine("*{0, 30}: {1,-36}*", "Quantity: ", product2.Quantity);
            WriteLine("*{0, 30}: {1,-36}*", "Product Before Tax: ", product2.ProductTotalBeforeTax);
            WriteLine("*{0, 30}: {1,-36}*", "Product Tax: ", product2.ProductTax);
            WriteLine("*{0, 30}: {1,-36}*", "Product After Tax: ", product2.ProductTotalAfterTax);
            WriteLine("*{0,30} {1,-37}*", "", "");
            WriteLine("*{0, 30}: {1,-36}*", "Product Name: ", product3.ProductName);
            WriteLine("*{0, 30}: {1,-36}*", "Price Per Unit: ", product3.PricePerUnit);
            WriteLine("*{0, 30}: {1,-36}*", "Quantity: ", product3.Quantity);
            WriteLine("*{0, 30}: {1,-36}*", "Product Before Tax: ", product3.ProductTotalBeforeTax);
            WriteLine("*{0, 30}: {1,-36}*", "Product Tax: ", product3.ProductTax);
            WriteLine("*{0, 30}: {1,-36}*", "Product After Tax: ", product3.ProductTotalAfterTax);
            WriteLine("*{0,30} {1,-37}*", "", "");
            WriteLine("*{0, 30}: {1,-36}*", "Total Before Discount: ",totalBeforeDiscount);
            WriteLine("*{0, 30}: {1,-36}*", "Discount:  ", discountAmount);
            WriteLine("*{0, 30}: {1,-36}*", "Total After Discount: ", totalAfterDiscount);
            WriteLine(asterikline);
            ChooseAction(product1, product2, product3);//called the method to display choice options.
        }

        static double GetCartTotalSummary(Product product1, Product product2, Product product3, out double totalBeforeDiscount, out double discountAmount)//this method is  used for calculating the discount amount.
        {
            totalBeforeDiscount = product1.ProductTotalAfterTax + product2.ProductTotalAfterTax + product3.ProductTotalAfterTax;//total for all three products
            if (totalBeforeDiscount > 100)//if the value is more than 100, it will assign 10% discount.
            {
                discountAmount = totalBeforeDiscount*.10;
            }
            else//thse the discount will be 0.
            {
                discountAmount=0;
            }
            double totalAfterDiscount = totalBeforeDiscount - discountAmount;
            return totalAfterDiscount;//as the method is not void, it will return a double.
        }

        static void UpdateCart(Product product1, Product product2, Product product3)//this method is for updating the quantity.
        {
            WriteLine("Okay! Lets update your order!","\n","\n","\n");
            WriteLine("Press 1 to update quantity for Disposable Mask Pack \n" +
                "Press 2 to update quantity for Hand Sanitizer\n" +
                "Press 3 to update quantity for Printer Paper Stack");
            Write("Enter the number(1,2 or 3): ");
            int choice = int.Parse(ReadLine());//the method will only take integers as input.
            if (choice == 1)//this part is for validating the user-input and act on the input.
            {
                UpdateProductQty(product1);
                WriteLine("Great! Quantity for " + product1.ProductName + "has been updated to " + product1.Quantity);
            }
            else if (choice == 2)
            {
                UpdateProductQty(product2);
                WriteLine("Great! Quantity for " + product2.ProductName + "has been updated to " + product2.Quantity);
            }
            else if (choice == 3)
            {
                UpdateProductQty(product3);
                WriteLine("Great! Quantity for " + product3.ProductName + "has been updated to " + product3.Quantity);
            }
            else
            {
                WriteLine("Enter a Valid Input!");
            }
            ChooseAction(product1, product2, product3);//again called this method to display the choices. This will help the user to choose an action again.
        }
        
    }
}
