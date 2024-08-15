using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ATM_APP
{
   public class ATM
    {
     public  Dictionary<int, Account> AtmDic = new Dictionary<int, Account>();
        public ATM()
        {
            AtmDic.Add(123456, new Account(123456, "martin", 1231, 5000));
            AtmDic.Add(123457, new Account(123457, "arun", 1232, 6000));
            AtmDic.Add(123458, new Account(123458, "ravi", 1234, 57000));
            AtmDic.Add(123459, new Account(123459, "anand", 1233, 53000));
            AtmDic.Add(123455, new Account(123455, "kumar", 1235, 51000));
            AtmDic.Add(123454, new Account(123454, "aravind", 1236, 15000));
            AtmDic.Add(123453, new Account(123453, "deepak", 1237, 95000));
            string path=@"C:\Users\ELCOT\Documents\Visual Studio 2012\Projects\ATM_APP\file";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);


                foreach (var entry in AtmDic)
                {
                    string filePath = Path.Combine(path, entry.Key + ".txt");

                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        writer.Write( entry.Value.Account_no + ",");
                        writer.Write( entry.Value.Name + ",");

                        writer.Write(entry.Value.Pin + ",");
                        writer.Write(entry.Value.Balence + ",");
                        writer.Write( entry.Value.Balence + ";");
                    }
                }
            }
            else
            {
                if (Directory.Exists(path))
                {
                    AtmDic = new Dictionary<int, Account>(); 
                    string[] files = Directory.GetFiles(path, "*.txt");

                    foreach (string file in files)
                    {
                        string filePath = Path.Combine(path, file);
                        string[] lines = File.ReadAllLines(filePath);
                        
                         int accountNumber=0;
                              string name="";
                                   int pin=0;
                                   double balance=0;
                      string item=lines[lines.Length-1];
                            string[] s = item.Split(',').ToArray();
                          accountNumber = int.Parse(s[0]);
                            name = s[1];
                           pin = int.Parse(s[2]);
                           balance = double.Parse(s[4].Trim(';'));
                       
                       

                        // Create Account object and add it to the dictionary
                        AtmDic.Add(accountNumber, new Account(accountNumber, name, pin, balance));
                    }
                }
            }

        }
      
        public bool Isvalid(int ac, int pin)
        {  bool isva = false;
            if (AtmDic.ContainsKey(ac))
            {
               
                Account b = AtmDic[ac];
                if (b.Pin == pin)
                {
                    isva = true;
                }
            }
            return isva;
        }
        public bool Is_account(int ac)
        {
            bool isva = false;
            if (AtmDic.ContainsKey(ac))
            {

                    isva = true;
                
            }
            return isva;
        }
        public void withrawel(int ac, int pin, double amount)
        {
            if (Isvalid(ac, pin))
            {
                Account b = AtmDic[ac];
              double bal=  b.withrawel(amount);
              string s = ac.ToString() + "," + b.Name + "," + pin.ToString() + "," + "-" + amount + "," + bal + ";";
                addnewline(ac + ".txt", s);
            }
        }
        public void deposit(int ac, double amount)
        {
            if (Is_account(ac))
            {
                Account b = AtmDic[ac];
              double bal=  b.deposit( amount);
                string s = ac.ToString() + ","+b.Name +","+ b.Pin.ToString() + "," + "+" + amount + "," + bal + ";";
                addnewline(ac + ".txt", s);
            }
        }
        public void change_pin(int ac, int pin, int new_pin)
        {
            if (Isvalid(ac, pin))
            {
                Account b = AtmDic[ac];
                b.change_pin(new_pin);
                string s = ac.ToString() + "," + b.Name + "," + b.Pin.ToString() + "," + "-" + "," + b.Balence + ";";
                addnewline(ac + ".txt", s);
            }
        }
        public double check_bal(int ac, int pin)
        { Account b = AtmDic[ac];
        return b.Balence;
        }
        public string get_name(int ac)
        {
            
                Account b = AtmDic[ac];
                return b.Name;
               
            
        }
        private void addnewline(string fname, string data)
        {
            string path = @"C:\Users\ELCOT\Documents\Visual Studio 2012\Projects\ATM_APP\file";
            string filePath = Path.Combine(path, fname);
            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                writer.WriteLine(data);
            }
        }
        public void miniStatement(int ac,int pin)
        {
            if (Isvalid(ac, pin))
            {
                string path = @"C:\Users\ELCOT\Documents\Visual Studio 2012\Projects\ATM_APP\file";
                Account b = AtmDic[ac];
                string filePath = Path.Combine(path, ac + ".txt");
                string[] lines = File.ReadAllLines(filePath);

                Console.WriteLine("ac no       name       cr/depit      balence");
                for (int i = lines.Length - 5; i < lines.Length; i++)
                {
                    string item = lines[i];
                    string[] s = item.Split(',').ToArray();               
                   
                    Console.Write((s[0])+"       ");
                    Console.Write(s[1]+"      ");
                    Console.Write(s[3] + "      ");
                    Console.WriteLine(s[4] + "   ");
                }
            }
          
          
        
        }

        

    }
}
