using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_APP
{
  public  class Account
    {
       private int _account_no;

        public int Account_no
        {
            get { return _account_no; }
        }
       private string _name;

        public string Name
        {
            get { return _name; }
          
        }
        int _pin;

      public  int Pin
        {
            get { return _pin; }
         
        }
       private double _balence;

        public double Balence
        {
            get { return _balence; }
         
        }
        public Account() { }
        public Account(int account_no,string name,int pin,double balence)
        {
            this._account_no = account_no;
            this._name = name;
            this._pin = pin;
            this._balence = balence;
        }
        private bool ISavailable( double amount)
        {
            bool avail = false;
            if (amount < Balence)
            {
                avail =true;
            }
            return avail;
        }
        public double withrawel(double amount)
        {
            if (ISavailable( amount))
            {
                _balence -= amount;
                return Balence;
            }
            return -1;
        }
        public double deposit(double amount)
        {
            _balence+=amount;
            return _balence;
        }
        public void change_pin( int new_pin)
        {
            _pin = new_pin;
        
        }
       

        

    }
}
