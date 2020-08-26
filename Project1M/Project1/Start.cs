using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
  public static  class Start
    {
      public static  List<product> productlist = new List<product>();
   
        public static void CommandLoop()
        {
            
                Console.WriteLine("If You are : " + "Manager press 1 " + "Customer press 2 ");
                var command = Console.ReadLine();
                commandroute(command);
            

        }

        private static void commandroute(string command)
        {
            if (command.StartsWith("1"))
                Managerside();
            else if (command.StartsWith("2"))
                Customerside();
            else
            {
                Console.WriteLine("Not understood");
                CommandLoop();
            }
               

        }

        private static void Managerside()
        {
            Console.WriteLine("Add a new product or press q to exit");
            var newproduct = Console.ReadLine().ToLower();
            if(newproduct.Length==1 && newproduct.StartsWith("q"))
            {
                CommandLoop();
            }
            if(newproduct.Length < 3)
            {
                Console.WriteLine("Please enter the Name , UPC and Price for the product ");
                Console.WriteLine("Add a new product or press q to exit");
            }
            else
            {
                string [] cut=newproduct.Split(' ');
                product product = new product()
                {
                    name = cut[0],
                    upc = Int32.Parse(cut[1]),
                    price = (double.Parse(cut[2]))

                };
                productlist.Add(product);
                Managerside();

            }


        }


        public static void Customerside()
        {
            
            Console.WriteLine("press TD to enter Tax and Discount amout or press q to exit");
            var read = Console.ReadLine().ToUpper();
            if (read.StartsWith("Q"))
            {
                CommandLoop();

            }
            else if (read.StartsWith("TD"))
            {
                Tax_Discount();
            }else
            {
                Console.WriteLine("Please Enter a correct command");
                Customerside();
            }

        }

        public static void Tax_Discount()
        {
            double tax;
            double discount;
            double TaxAmount;
            double DiscountAmount;

            Console.WriteLine("Tax amout =");
            var tax1 = Console.ReadLine();
            bool taxcorrect = double.TryParse(tax1, out tax);
            Console.WriteLine("Discount amout =");
            var discount1 = Console.ReadLine();
            bool discountcorrect = double.TryParse(discount1, out discount);
            if (taxcorrect && discountcorrect && tax>=0 && discount>=0) {
                foreach (var prod in productlist)
                {
                    TaxAmount = (prod.price * tax) / 100;
                    DiscountAmount = (prod.price * discount) / 100;
                    var newprice = Math.Round((prod.price + TaxAmount - DiscountAmount), 2);
                    Console.WriteLine($"Product Name = {prod.name} , UPC = {prod.upc} , Price ={prod.price} ");
                    Console.WriteLine($"Price before = {prod.price}   Price after = {newprice} ");
                }

            Customerside();
            }
            else
            {
                Console.WriteLine("Please Enter Valid Positive Numbers");
                Tax_Discount();
            }
        }

    }
}

