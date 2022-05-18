using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject
{
    public class ATM
    {
        public CreditCard insertedCard;

        public bool WithdrawMoney(double amount)
        {
            return insertedCard.Account.WithdrawMoney(amount);
        }

        public bool CheckPin(int pin)
        {
            return insertedCard.CheckPin(pin);
        }

    }
}
