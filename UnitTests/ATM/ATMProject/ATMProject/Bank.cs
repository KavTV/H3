using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject
{
    public class Bank : IBank
    {
        List<Account> accounts;

        public bool WithdrawMoney(double amount, IAccount acc)
        {
            return acc.WithdrawMoney(amount);
        }
        public bool CheckPin(int pin, IAccount acc)
        {
            return acc.CheckPin(pin);
        }
    }
}
