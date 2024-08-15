using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ATM_APP
{
    class Program
    {
        static void Main(string[] args)
       {
            ATM ac = new ATM();
            while (true)
            {
                Console.Write("Enter Account no:");
                int ac_no = int.Parse(Console.ReadLine());


                if (ac.Is_account(ac_no))
                {
                    Console.WriteLine("     NAME    :" + ac.get_name(ac_no));
                    Console.WriteLine("____________________________________");
                    Console.WriteLine("1.withrawel.");
                    Console.WriteLine("2.deposit.");
                    Console.WriteLine("3.pin change.");
                    Console.WriteLine("4.check balence.");
                    Console.WriteLine("5.mini statement");
                    Console.Write("enter option:");
                    int n = int.Parse(Console.ReadLine());

                    switch (n)
                    {
                        case 1:
                            Console.Write("Enter amount:");
                            double with_amount = int.Parse(Console.ReadLine());
                            Console.Write("Enter pin:");
                            int pin = int.Parse(Console.ReadLine());
                            if (ac.Isvalid(ac_no, pin))
                            {
                                ac.withrawel(ac_no, pin, with_amount);
                                Console.WriteLine("success");
                                Console.WriteLine("balence:" + ac.check_bal(ac_no, pin));
                            }
                            else
                            { Console.WriteLine("wrong pin try again"); }

                            break;
                        case 2:
                            Console.WriteLine("Enter amount:");
                            double dep_amount = int.Parse(Console.ReadLine());
                            ac.deposit(ac_no, dep_amount);
                            Console.WriteLine("success");
                            break;
                        case 3:
                            Console.Write("Enter pin:");
                            int o_pin = int.Parse(Console.ReadLine());
                            if (ac.Isvalid(ac_no, o_pin))
                            {
                                Console.Write("Enter new pin:");
                                int n_pin = int.Parse(Console.ReadLine());
                                ac.change_pin(ac_no, o_pin, n_pin);
                                Console.WriteLine("success");

                            }
                            break;
                        case 4:
                            Console.Write("Enter pin:");
                            int c_pin = int.Parse(Console.ReadLine());
                            Console.WriteLine("balence:" + ac.check_bal(ac_no, c_pin));
                            break;
                        case 5:
                              Console.Write("Enter pin:");
                            int pin1 = int.Parse(Console.ReadLine());
                            ac.miniStatement(ac_no, pin1);
                            break;
                        default:
                            break;

                    }
                    Console.WriteLine("REMOVE YOUR CARD");
                    Thread.Sleep(9000);
                    Console.WriteLine("********* THANK YOU***********");
                }
                else
                {
                    Console.WriteLine("invalid account");
                }
            }

        }
    }
}
