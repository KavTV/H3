using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject
{
    public interface IAccount
    {
        bool WithdrawMoney(double amount);
        bool CheckPin(int pin);
    }
}
