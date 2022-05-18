using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject
{
    public class Account : IAccount
    {
        double money = 50000;

        public bool WithdrawMoney(double amount)
        {
            if (money >= amount)
            {
                money =- amount;
                return true;
            }
            return false;
        }
    }
}
