using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject
{
    public interface IBank
    {
        bool WithdrawMoney(double amount, IAccount acc);
    }
}
