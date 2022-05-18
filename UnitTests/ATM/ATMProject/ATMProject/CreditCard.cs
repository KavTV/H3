using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject
{
    public class CreditCard
    {
        public int CardId;
        public IAccount Account;

        public int pinCode;

        public bool CheckPin(double pin)
        {
            return pinCode == pin;
        }

    }
}
