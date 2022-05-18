using NUnit.Framework;

namespace ATMProject.UnitTest
{
    [TestFixture]
    public class ATMTests
    {
        [Test]
        public void CheckPin_CorrectPin_ReturnsTrue()
        {
            CreditCard card = new CreditCard() { pinCode = 2345};
            ATM atm = new ATM() { insertedCard = card};

            bool res = atm.CheckPin(2345);


            Assert.IsTrue(res);
        }

        [TestCase(5000,true)]
        [TestCase(10000,true)]
        [TestCase(999900,false)]
        [TestCase(574657354,false)]
        public void WithdrawMoney_Money_ReturnsExpected(double amount, bool expected)
        {
            CreditCard card = new CreditCard() { Account = new Account() };
            ATM atm = new ATM() { insertedCard = card };

            bool res = atm.WithdrawMoney(amount);


            Assert.AreEqual(expected, res);
        }
    }
}
