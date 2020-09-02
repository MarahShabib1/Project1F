using java.net;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
  public static  class Start
    {
      public static  List<product> productlist = new List<product>();
        public static List<EXPENSES> expenseslist = new List<EXPENSES>();
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
                Draw_Calculater();
            else
            {
                Console.WriteLine("Not understood");
                CommandLoop();
            }
        }

        private static void Managerside()
        {
            bool loop = true;
            while (loop) { 
            Console.WriteLine("Add a new product or press q to exit");
            var newproduct = Console.ReadLine().ToLower();
            if(newproduct.Length==1 && newproduct.StartsWith("q"))
            {
                    loop = false;
                CommandLoop();
            }
                if (newproduct.Length < 3)
                {
                    Console.WriteLine("Please enter the Name , UPC and Price for the product ");
                    Console.WriteLine("Add a new product or press q to exit");
                }
                else
                {
                    int tupc = 0;
                    double tprice = 0;
                    string[] cut = newproduct.Split(' ');
                    if (!(Int32.TryParse(cut[1], out tupc) && (double.TryParse(cut[2], out tprice))))
                    {
                        Console.WriteLine("Please Enter a valid numbers for UPC and Price");
                    }
                    else
                    {
                        var query = productlist.Where(c => c.upc == Int32.Parse(cut[1]));
                        if (query.Count() > 0)
                        {
                            Console.WriteLine("Product UPC already exist");
                        }
                         else
                        {

                            product product = new product()
                            {
                                name = cut[0],
                                upc = tupc,
                                price = tprice

                            };
                            productlist.Add(product);
                        }
                    }
                }
            }
        }

        public static void Draw_Calculater()
        {
            Console.WriteLine("");
            Console.WriteLine("               Price Calculater               "+'\n');
            Console.WriteLine(" 1.TAX        |  2.DICOUNT       |  3.REPORT  ");
            Console.WriteLine("-----------------------------------------------  ");
            Console.WriteLine(" 4.Selective  |  5.PRECEDENCE    |  6.EXPENSES  ");
            Console.WriteLine("-----------------------------------------------  ");
            Console.WriteLine(" 7.COMBINING  |  8.CAP           |  9.CURRENCY  ");
            Console.WriteLine("-----------------------------------------------  ");
            Console.WriteLine(" 10.PRECISION |  11.CONFIGURATOR |  12.EXIT  ");
            Customerside();
        }


        public static void Customerside()
        {
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("Enter a number from the calculater above or press q to exit");
                var read = Console.ReadLine();
                if (read.Equals("q"))
                {
                    loop = false;
                    CommandLoop();

                }
                else if (read.Equals("1"))
                {
                    loop = false;
                    var tax =Tax_Read();
                    print_tax_result(tax);

                }
                else if (read.Equals("2"))
                {
                    loop = false;
                    var tax = Tax_Read();
                    var discount = Discount_Read();
                    print_discount_result(tax, discount);

                }
                else if (read.Equals("3"))
                {
                    loop = false;
                    var tax = Tax_Read();
                    var discount = Discount_Read();
                    print_Report_result(tax, discount);

                }
                else if (read.Equals("4"))
                {
                    loop = false;
                    var tax = Tax_Read();
                    var discount = Discount_Read();
                    var upcdiscount = UPC_Discount_Read();
                    if (upcdiscount == 0)
                    {
                        print_selective_result(tax, discount, upcdiscount, -1);
                    }
                    else
                    {
                        var upcval = UPC_Val_Read();
                        print_selective_result(tax, discount, upcdiscount, upcval);
                    }

                }
                else if (read.Equals("5"))
                {
                    loop = false;
                    var tax = Tax_Read();
                    var discount = Discount_Read();
                    var upcdiscount = UPC_Discount_Read();
                    if (upcdiscount == 0)
                    {
                        var precedence = PRECEDENCE_Read();
                        print_precedence_result(tax, discount, upcdiscount, -1, precedence);
                    }
                    else
                    {
                        var upcval = UPC_Val_Read();
                        var precedence = PRECEDENCE_Read();
                        print_precedence_result(tax, discount, upcdiscount, upcval, precedence);
                    }   
                }
                else if (read.Equals("6"))
                {
                    loop = false;
                    var tax = Tax_Read();
                    var discount = Discount_Read();
                    var upcdiscount = UPC_Discount_Read();
                    if (upcdiscount == 0)
                    {       
                       Expenses_Read();  // to fill the list
                        print_Expenses_result(tax, discount, upcdiscount, -1);
                    }
                    else
                    {
                        var upcval = UPC_Val_Read();
                        Expenses_Read();
                        print_Expenses_result(tax, discount, upcdiscount, upcval);
                    }

                }
                else if (read.Equals("7"))
                {
                    loop = false;
                    var tax = Tax_Read();
                    var discount = Discount_Read();
                    var upcdiscount = UPC_Discount_Read();
                    if (upcdiscount == 0)
                    {
                        Expenses_Read();  // to fill the list
                        var method = combining_method_Read();
                        print_combinig_result(tax, discount, upcdiscount, -1,method);
                    }
                    else
                    {
                        var upcval = UPC_Val_Read();
                        Expenses_Read();
                        var method = combining_method_Read();
                        print_combinig_result(tax, discount, upcdiscount, upcval,method);
                    }

                }
                else if (read.Equals("8"))
                {
                    loop = false;
                    var tax = Tax_Read();
                    var discount = Discount_Read();
                    var upcdiscount = UPC_Discount_Read();
                    if (upcdiscount == 0)
                    {
                        Expenses_Read();  // to fill the list
                        var method = combining_method_Read();
                        Cap cap = Cap_Read();
                        print_Cap_result(tax, discount, upcdiscount, -1, method ,cap);
                    }
                    else
                    {
                        var upcval = UPC_Val_Read();
                        Expenses_Read();
                        var method = combining_method_Read();
                        Cap cap = Cap_Read();
                        print_Cap_result(tax, discount, upcdiscount, upcval, method,cap);
                    }

                }
                else if (read.Equals("9"))
                {
                    loop = false;
                    var tax = Tax_Read();
                    var discount = Discount_Read();
                    var upcdiscount = UPC_Discount_Read();
                    if (upcdiscount == 0)
                    {
                        Expenses_Read();  // to fill the list
                        var method = combining_method_Read();
                        Cap cap = Cap_Read();
                        var currency_converter= Currency_Read();
                        print_Currency_result(tax, discount, upcdiscount, -1, method, cap, currency_converter);
                    }
                    else
                    {
                        var upcval = UPC_Val_Read();
                        Expenses_Read();
                        var method = combining_method_Read();
                        Cap cap = Cap_Read();
                        var currency_converter = Currency_Read();
                        print_Currency_result(tax, discount, upcdiscount, upcval, method, cap, currency_converter);
                    }

                }
                else if (read.Equals("10"))
                {
                    loop = false;
                    var tax = Tax_Read();
                    var discount = Discount_Read();
                    var upcdiscount = UPC_Discount_Read();
                    if (upcdiscount == 0)
                    {
                        Expenses_Read();  // to fill the list
                        var method = combining_method_Read();
                        Cap cap = Cap_Read();
                        var currency_converter = Currency_Read();
                        print_PRECISION_result(tax, discount, upcdiscount, -1, method, cap, currency_converter);
                    }
                    else
                    {
                        var upcval = UPC_Val_Read();
                        Expenses_Read();
                        var method = combining_method_Read();
                        Cap cap = Cap_Read();
                        var currency_converter = Currency_Read();
                        print_PRECISION_result(tax, discount, upcdiscount, upcval, method, cap, currency_converter);
                    }

                }
                else
                {
                    Console.WriteLine("Please Enter a correct command");
                    
                }
            }

        }
        public static double Tax_Read()
        {
            bool loop = true;
            double tax = -1;
            while (loop)
            {
                
                Console.WriteLine("Tax amout =");
                var tax1 = Console.ReadLine();
                bool tax_correct = double.TryParse(tax1, out tax);
                if (tax_correct && tax >= 0)
                {
                    loop = false;
                    return tax;
                }
                else
                {
                    Console.WriteLine("Please Enter Valid Positive Number");

                }
            }
            return tax ;


        }
        public static double Discount_Read()
        {
            bool loop = true;
            double discount = -1;
            while (loop)
            {    
                
                Console.WriteLine("Universal-Discount amout =");
                var discount1 = Console.ReadLine();
                bool discount_correct = double.TryParse(discount1, out discount);
                if (discount_correct && discount >= 0)
                {
                    loop = false;
                    return discount;
                }
                else
                {
                    Console.WriteLine("Please Enter Valid Positive Number");

                }
            }
            return discount;
        }

        public static double UPC_Discount_Read()
        {
            bool loop = true;
            double discount = -1;
            while (loop)
            {

                Console.WriteLine("UPC-Discount amout =");
                var discount1 = Console.ReadLine();
                bool discount_correct = double.TryParse(discount1, out discount);
                if (discount_correct && discount >= 0)
                {
                    loop = false;
                    return discount;
                }
                else
                {
                    Console.WriteLine("Please Enter Valid Positive Number");

                }
            }
            return discount;
        }

        public static int UPC_Val_Read()
        {
            bool loop = true;
            int upcval = -1;
            while (loop)
            {
                Console.WriteLine("For UPC =");

                if (Int32.TryParse(Console.ReadLine(), out upcval))
                {
                    var query = productlist.Where(c => c.upc == upcval);
                    if (query.Count() == 0)
                    {
                        Console.WriteLine("UPC is not listed");
                    }
                    else
                    {
                        loop = false;
                        return upcval;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid postive number for upc");
                }
            }
            return upcval;

        }
        public static string PRECEDENCE_Read()
        {
            bool loop = true;
            string precedence = "";
            while (loop)
            {
                Console.WriteLine("Press A for After and B for Before Respectively" + '\n');
                Console.WriteLine("Universal-Discount After/Before tax ? UPC-Discount After/Before tax ? ");
                precedence = Console.ReadLine().ToUpper();
                if(precedence.Equals("AB") || precedence.Equals("BA") || precedence.Equals("AA")|| precedence.Equals("BB"))
                {
                    loop = false;
                    return precedence;
                }
                else
                {
                    Console.WriteLine("Please Enter Valid Syntax (AB||BA||AA||BB)");

                }
            }
            return  precedence;

        }
      public static void Expenses_Read()
        {
           bool loop = true;
            while (loop)
            {     
                Console.WriteLine("Press 1 if you want to add expenses or press q to exit");
                var read = Console.ReadLine();
                if (read.StartsWith("q"))
                {
                    loop = false;
                    return;
                }
                else if (read.StartsWith("1"))
                {
                    Console.WriteLine("Press A if the Cost is absolute value or Press P if the Cost is percentage of price ");
                    var cost = Console.ReadLine().ToUpper();
                    if (cost.StartsWith("A") || cost.StartsWith("P"))
                    {
                        bool is_absolute = false;
                        if (cost.StartsWith("A"))
                        {
                            is_absolute = true;
                        }
                        Console.WriteLine("Please enter name=cost");
                        var expense = Console.ReadLine();
                        if (expense.Contains('='))
                        { double costs;
                            string[] cut = expense.Split('=');
                           if( double.TryParse(cut[1], out costs))
                            {    
                                EXPENSES new_expense = new EXPENSES()
                                {
                                    name = cut[0],
                                    cost = costs,
                                    is_absolute_value= is_absolute

                                };
                                expenseslist.Add(new_expense);    
                            }
                        }
                        else
                        {
                           Console.WriteLine("Please enter Correct Command");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter Correct Command");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter Correct Command");
                }
            }
            }

         public static string combining_method_Read()
        {
            bool loop = true;
            string precedence = "";
            while (loop)
            {
                Console.WriteLine("Select additive or multiplicative method ?" + '\n');
                precedence = Console.ReadLine().ToLower();
                if (precedence.Equals("additive") || precedence.Equals("multiplicative") )
                {
                    loop = false;
                    return precedence;
                }
                else
                {
                    Console.WriteLine("Please Enter Valid Syntax (additive or multiplicative)");

                }
            }
            return precedence;
        }

        public static Cap Cap_Read()
        {
            bool loop = true;
            Cap cap = new Cap();
            while (loop)
            {
                Console.WriteLine("Press 1 if you want to add cap or press q to exit");
                var read = Console.ReadLine();
                if (read.StartsWith("q"))
                {
                    loop = false;
                    return cap;
                }
                else if (read.StartsWith("1"))
                {
                    Console.WriteLine("Press A if the Cap is absolute value or Press P if the Cap is percentage of price ");
                    var cost = Console.ReadLine().ToUpper();
                    if (cost.StartsWith("A") || cost.StartsWith("P"))
                    {
                        cap.is_absolute_value = false;
                        if (cost.StartsWith("A"))
                        {
                            cap.is_absolute_value = true;
                        }
                        Console.WriteLine("Please enter Cap value");
                        var cap_value = Console.ReadLine();
                            double costs;
                           
                            if (double.TryParse(cap_value, out costs))
                            {
                            cap.value = costs;
                                return cap;
                        }
                        else
                        {
                            Console.WriteLine("Please enter Correct Command");
                        }       
                    }
                    else
                    {
                        Console.WriteLine("Please enter Correct Command");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter Correct Command");
                }
            }
            return cap;
        }

        

         public static double Currency_Read()
        {
            bool loop = true;
            while (loop)
            {
                
                Console.WriteLine("Enter Curreny (USD/GBP) ");
                var currency = Console.ReadLine().ToUpper();
                if (currency.Equals("USD"))
                {
                    loop = false;
                    return 1;
                }
                else if (currency.Equals("GBP"))
                {
                    loop = false;
                    return .877;
                }else
                {
                    Console.WriteLine("Please select Currency from above ");
                }
            }
            return 0 ;


        }

        public static double Tax_Amount(double tax, double price ,int digit )
        {
            double tax_amount = 0;
            if (digit == 2)
            {
                tax_amount= Math.Round((price * tax) / 100, 2);
            }
            else if (digit == 4)
            {
                tax_amount = Math.Round((price * tax) / 100, 4);
            }

            return tax_amount;

        }
        public static double Discounts_Amount(double discount, double upcDiscount ,double price ,string method, int digit)
        {
            double DiscountAmount;
            double upcDiscountAmount = 0;

            DiscountAmount = (price * discount) / 100;
            if (method.Equals("additive")){
               
                upcDiscountAmount = (price * upcDiscount) / 100;
            }
            if (method.Equals("multiplicative"))
            {

                upcDiscountAmount = ((price - DiscountAmount) * upcDiscount) / 100;
            }
            if (digit == 2)
            {
                return Math.Round(DiscountAmount + upcDiscountAmount,2);
            }
            else if (digit == 4)
            {
                return Math.Round(DiscountAmount + upcDiscountAmount, 2);
            }

            return DiscountAmount + upcDiscountAmount;

        }
       



        public static void print_tax_result(double tax)
        {
            double newprice;
            foreach (var prod in productlist)
            {
             newprice = Math.Round((prod.price + Tax_Amount(tax , prod.price,2) ), 2);
            Console.WriteLine($"Product Name = {prod.name} , UPC = {prod.upc} , Price ={prod.price} ");
            Console.WriteLine($"Product price reported as $ {prod.price} before tax and $ {newprice} after {tax} % tax. " + '\n');
        }

            Customerside();
        }

        public static void print_discount_result(double tax ,double discount)
        {
            double newprice;
            foreach (var prod in productlist)
            {
                newprice = Math.Round((prod.price + Tax_Amount(tax, prod.price,2))-Discounts_Amount(discount,0,prod.price,"additive",2), 2);
                Console.WriteLine($"Product Name = {prod.name} , UPC = {prod.upc} , Price ={prod.price} ");
                Console.WriteLine($"Tax      Amount= ${Math.Round(Tax_Amount(tax, prod.price,2),2)}");
                Console.WriteLine($"Discount Amount= ${Math.Round(Discounts_Amount(discount, 0, prod.price, "additive",2), 2)}");
                Console.WriteLine($"Price before = $ {prod.price} ,price after = ${newprice} " + '\n');
            }

            Customerside();
        }

        public static void print_Report_result(double tax, double discount)
        {
            double newprice;
            foreach (var prod in productlist)
            {
                newprice = Math.Round((prod.price + Tax_Amount(tax, prod.price,2)) - Discounts_Amount(discount, 0, prod.price, "additive",2), 2);
                Console.WriteLine($"Product Name = {prod.name} , UPC = {prod.upc} , Price ={prod.price} ");
                Console.WriteLine($"Tax  = {tax} %  , Discount  = {discount} %  ");
                Console.WriteLine($"New price = ${newprice} "); 
                if(discount >0)
                Console.WriteLine($"${Math.Round(Discounts_Amount(discount, 0, prod.price, "additive",2), 2)}amount which was deduced"+'\n');
                else
                    Console.WriteLine($"Program doesn’t show any discounted amount." + '\n');
            }

            Customerside();
        }

        public static void print_selective_result(double tax, double discount ,double upcdiscount , int upcval)
        {
            double newprice;
            foreach (var prod in productlist)
            {
                Console.WriteLine($"Product Name = {prod.name} , UPC = {prod.upc} , Price ={prod.price} ");
                if (prod.upc == upcval)
                {
                    Console.WriteLine($"**Total discount amount ${Math.Round(Discounts_Amount(discount, upcdiscount, prod.price, "additive",2), 2)}");

                    newprice = Math.Round((prod.price + Tax_Amount(tax, prod.price,2)) - Discounts_Amount(discount, upcdiscount, prod.price, "additive",2), 2);
                }
                else
                {
                    Console.WriteLine($"Discount amount ${Math.Round(Discounts_Amount(discount,0, prod.price, "additive",2), 2)}");
                    newprice = Math.Round((prod.price + Tax_Amount(tax, prod.price,2)) - Discounts_Amount(discount, 0, prod.price, "additive",2), 2);
                }
                Console.WriteLine($"New price = ${newprice} " + '\n');
            }

            Customerside();
        }

        public static void print_precedence_result(double tax, double discount, double upcdiscount, int upcval, string precedence)
        {

            double newprice;
            double taxamount = 0;
            double discountamount = 0;
            double upc_discountamount;
            double save_upcdiscount = upcdiscount;
            foreach (var prod in productlist)
            {
                Console.WriteLine($"Product Name = {prod.name} , UPC = {prod.upc} , Price ={prod.price} ");
                if (!(prod.upc == upcval))
                {
                    upcdiscount = 0;
                }
                else
                {
                    upcdiscount = save_upcdiscount;
                }
                    switch (precedence)
                {
                    case "AA":
                        taxamount = Tax_Amount(tax, prod.price,2);
                        discountamount = Discounts_Amount(discount, upcdiscount, prod.price, "additive",2);
                        break;
                    case "BB":
                        discountamount = Discounts_Amount(discount, upcdiscount, prod.price, "additive",2);
                        taxamount = Tax_Amount(tax, (prod.price-discountamount),2);
                        break;
                    case "AB":
                        upc_discountamount = Discounts_Amount(0, upcdiscount, prod.price, "additive",2);
                        discountamount = upc_discountamount + Discounts_Amount(discount, 0, (prod.price - upc_discountamount), "additive",2);
                        taxamount = Tax_Amount(tax, (prod.price - upc_discountamount),2);
                        break;
                    case "BA":
                        discountamount = Discounts_Amount(discount, 0, prod.price, "additive",2);
                        upc_discountamount = Discounts_Amount(0, upcdiscount, (prod.price - discountamount), "additive",2);
                        discountamount = discountamount + upc_discountamount;
                       taxamount = Tax_Amount(tax, (prod.price - discountamount),2);
                        break;
                }

                if (prod.upc == upcval)
                {
                    Console.WriteLine($"**Total discount amount ${Math.Round((discountamount), 2)}");

                    newprice = Math.Round((prod.price + taxamount - discountamount), 2);
                }
                else
                {
                    Console.WriteLine($"Discount amount ${Math.Round((discountamount), 2)}");
                    newprice = Math.Round((prod.price + taxamount - discountamount), 2);
                }
                Console.WriteLine($"New price = ${newprice} " + '\n');
            }

            Customerside();
        }


        public static void print_Expenses_result(double tax, double discount, double upcdiscount, int upcval)
        {
            double newprice;
            foreach (var prod in productlist)
            {
                Console.WriteLine($"Product Name = {prod.name} , UPC = {prod.upc} , Price ={prod.price} ");
                Console.WriteLine($"Price = ${prod.price}");
                Console.WriteLine($"Tax = ${Math.Round(Tax_Amount(tax, prod.price,2), 2)}");
                if (prod.upc == upcval)
                {
                    Console.WriteLine($"**Total discounts = ${Math.Round(Discounts_Amount(discount, upcdiscount, prod.price, "additive",2), 2)}");

                    newprice = Math.Round((prod.price + Tax_Amount(tax, prod.price,2)) - Discounts_Amount(discount, upcdiscount, prod.price, "additive",2), 2);
                }
                else
                {
                    Console.WriteLine($"Discount =${Math.Round(Discounts_Amount(discount, 0, prod.price, "additive",2), 2)}");
                    newprice = Math.Round((prod.price + Tax_Amount(tax, prod.price,2)) - Discounts_Amount(discount, 0, prod.price, "additive",2), 2);
                }
                if (expenseslist.Count() > 0)
                {
                    
                     foreach(var ex in expenseslist)
                    {
                        var costnew = Math.Round(ex.cost, 2); 
                        if (!ex.is_absolute_value)
                            costnew = Math.Round((ex.cost * prod.price) /100,2);
                        Console.WriteLine($"{ex.name} = ${costnew} ");
                        newprice = newprice + ex.cost;
                    }
                }
                Console.WriteLine($"Total New price = ${newprice} " + '\n');
            }

            Customerside();
        }


        public static void print_combinig_result(double tax, double discount, double upcdiscount, int upcval,string method)
        {
            double newprice;
            foreach (var prod in productlist)
            {
                Console.WriteLine($"Product Name = {prod.name} , UPC = {prod.upc} , Price ={prod.price} ");
                Console.WriteLine($"Price = ${prod.price}");
                Console.WriteLine($"Tax = ${Math.Round(Tax_Amount(tax, prod.price,2), 2)}");
                if (prod.upc == upcval)
                {
                    Console.WriteLine($"**Total discounts = ${Math.Round(Discounts_Amount(discount, upcdiscount, prod.price, method,2), 2)}");

                    newprice = Math.Round((prod.price + Tax_Amount(tax, prod.price,2)) - Discounts_Amount(discount, upcdiscount, prod.price, method,2), 2);
                }
                else
                {
                    Console.WriteLine($"Discount =${Math.Round(Discounts_Amount(discount, 0, prod.price, method,2), 2)}");
                    newprice = Math.Round((prod.price + Tax_Amount(tax, prod.price,2)) - Discounts_Amount(discount, 0, prod.price, method,2), 2);
                }
                if (expenseslist.Count() > 0)
                {
                    foreach (var ex in expenseslist)
                    {
                        var costnew = Math.Round(ex.cost, 2);
                        if (!ex.is_absolute_value)
                            costnew = Math.Round((ex.cost * prod.price) / 100, 2);
                        Console.WriteLine($"{ex.name} = ${costnew} ");
                        newprice = newprice + costnew;
                    }
                }
                Console.WriteLine($"Total New price = ${newprice} " + '\n');
            }

            Customerside();
        }

        public static void print_Cap_result(double tax, double discount, double upcdiscount, int upcval, string method ,Cap cap)
        {
            double newprice;
            foreach (var prod in productlist)
            {
                Console.WriteLine($"Product Name = {prod.name} , UPC = {prod.upc} , Price ={prod.price} ");
                Console.WriteLine($"Price = ${prod.price}");
                Console.WriteLine($"Tax = ${Math.Round(Tax_Amount(tax, prod.price,2), 2)}");
                var cap_amount = Math.Round(cap.value, 2);
                if (!cap.is_absolute_value)
                    cap_amount = Math.Round((cap.value * prod.price) / 100, 2);

                if (prod.upc == upcval)
                {
                    var discountamount = Math.Round(Discounts_Amount(discount, upcdiscount, prod.price, method,2), 2);
                    if (discountamount > cap_amount)
                        discountamount = cap_amount;

                    Console.WriteLine($"**Total discounts = ${discountamount}");

                    newprice = Math.Round((prod.price + Tax_Amount(tax, prod.price,2)) - discountamount, 2);
                }
                else
                {
                    var discountamount = Math.Round(Discounts_Amount(discount, 0, prod.price, method,2), 2);
                    if (discountamount > cap_amount)
                        discountamount = cap_amount;
                    Console.WriteLine($"Discount =${discountamount}");
                    newprice = Math.Round((prod.price + Tax_Amount(tax, prod.price,2)) - discountamount, 2);
                }
                if (expenseslist.Count() > 0)
                {
                    foreach (var ex in expenseslist)
                    {
                        var costnew = Math.Round(ex.cost, 2);
                        if (!ex.is_absolute_value)
                            costnew = Math.Round((ex.cost * prod.price) / 100, 2);
                        Console.WriteLine($"{ex.name} = ${costnew} ");
                        newprice = newprice + costnew;
                    }
                }
                Console.WriteLine($"Total New price = ${newprice} " + '\n');
            }

            Customerside();
        }

        public static void print_Currency_result(double tax, double discount, double upcdiscount, int upcval, string method, Cap cap,double currency)
        {    
            double newprice;
            foreach (var prod in productlist)
            {
                Console.WriteLine($"Product Name = {prod.name} , UPC = {prod.upc} , Price ={Math.Round((prod.price *currency), 2)} ");
                Console.WriteLine($"Price = ${Math.Round((prod.price *currency), 2)}");
                Console.WriteLine($"Tax = ${Math.Round(Tax_Amount(tax, prod.price * currency,2), 2)}");
                var cap_amount = Math.Round(cap.value, 2);
                if (!cap.is_absolute_value)
                    cap_amount = Math.Round((cap.value * prod.price*currency) / 100, 2);

                if (prod.upc == upcval)
                {
                    var discountamount = Math.Round(Discounts_Amount(discount, upcdiscount, prod.price*currency, method,2), 2);
                    if (discountamount > cap_amount)
                        discountamount = cap_amount;

                    Console.WriteLine($"**Total discounts = ${discountamount}");

                    newprice = Math.Round(((prod.price * currency) + Tax_Amount(tax, prod.price * currency,2)) - discountamount, 2);
                }
                else
                {
                    var discountamount = Math.Round(Discounts_Amount(discount, 0, prod.price * currency, method,2), 2);
                    if (discountamount > cap_amount)
                        discountamount = cap_amount;
                    Console.WriteLine($"Discount =${discountamount}");
                    newprice = Math.Round((prod.price * currency + Tax_Amount(tax, prod.price,2)) - discountamount, 2);
                }
                if (expenseslist.Count() > 0)
                {
                    foreach (var ex in expenseslist)
                    {
                        var costnew = Math.Round(ex.cost, 2);
                        if (!ex.is_absolute_value)
                            costnew = Math.Round((ex.cost * prod.price * currency) / 100, 2);
                        Console.WriteLine($"{ex.name} = ${costnew} ");
                        newprice = newprice + costnew;
                    }
                }
                Console.WriteLine($"Total New price = ${newprice} " + '\n');
            }

            Customerside();
        }

        public static void print_PRECISION_result(double tax, double discount, double upcdiscount, int upcval, string method, Cap cap, double currency)
        {
            double newprice;
            foreach (var prod in productlist)
            {
                Console.WriteLine($"Product Name = {prod.name} , UPC = {prod.upc} , Price ={Math.Round((prod.price * currency), 2)} ");
                Console.WriteLine($"Price = ${Math.Round((prod.price * currency), 2)}");
                Console.WriteLine($"Tax = ${Math.Round(Tax_Amount(tax, prod.price * currency,4), 2)}");
                var cap_amount = Math.Round(cap.value, 2);
                if (!cap.is_absolute_value)
                    cap_amount = Math.Round((cap.value * prod.price * currency) / 100, 2);

                if (prod.upc == upcval)
                {
                    var discountamount = Math.Round(Discounts_Amount(discount, upcdiscount, prod.price * currency, method,4), 2);
                    if (discountamount > cap_amount)
                        discountamount = cap_amount;

                    Console.WriteLine($"**Total discounts = ${discountamount}");

                    newprice = Math.Round(((prod.price * currency) + Tax_Amount(tax, prod.price * currency,4)) - discountamount, 2);
                }
                else
                {
                    var discountamount = Math.Round(Discounts_Amount(discount, 0, prod.price * currency, method,4), 2);
                    if (discountamount > cap_amount)
                        discountamount = cap_amount;
                    Console.WriteLine($"Discount =${discountamount}");
                    newprice = Math.Round((prod.price * currency + Tax_Amount(tax, prod.price,4)) - discountamount, 2);
                }
                if (expenseslist.Count() > 0)
                {
                    foreach (var ex in expenseslist)
                    {
                        var costnew = Math.Round(ex.cost, 2);
                        if (!ex.is_absolute_value)
                            costnew = Math.Round((ex.cost * prod.price * currency) / 100, 2);
                        Console.WriteLine($"{ex.name} = ${costnew} ");
                        newprice = newprice + costnew;
                    }
                }
                Console.WriteLine($"Total New price = ${newprice} " + '\n');
            }

            Customerside();
        }

      










    }
}

