using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArghoC_Assign1
{
    internal class Product
    {
        public string ProductName//read-only property. It cannot be changed afterwards.
        {
            get;
        }

        public double PricePerUnit//read-only property. It cannot be changed afterwards.
        {
            get;
        }
        public int Quantity//Read-write property. It can be changed later.
        {
            get; set;
        }
        public double ProductTotalBeforeTax//computed read-only property
        {
            get
            {
                return PricePerUnit * Quantity;//realtime calculations
            }
        }

        public double ProductTax//computed read-only property
        {
            get
            {
                return ProductTotalBeforeTax * .08;
            }
        }
        public double ProductTotalAfterTax//computed read-only property
        {
            get
            {
                return ProductTotalBeforeTax + ProductTax;
            }
        }

        public Product( string productName, double pricePerUnit)//constructor 1(With two parameters). Added this to check the connection between manin() and product class
        {
            ProductName = productName;
            PricePerUnit = pricePerUnit;
            
            
        }

        public Product(string productName, double pricePerUnit, int quantity)//this is the actual constructor I've used in the entire program.
        {
            ProductName = productName;
            PricePerUnit = pricePerUnit;
            Quantity = quantity;
        }




        public override string ToString()//The tostring() used por displaying primary data ie.(per unit price, name of the product
        {
            string outputStr = ProductName + "with price per unit " + PricePerUnit.ToString("C");
                               
            return outputStr;
                                
        }
    }
}
