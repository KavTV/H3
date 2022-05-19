using Moq;
using NUnit.Framework;

namespace ATMProject.UnitTest
{
    public class BankTests
    {
        [Test]

        public void WithdrawMoney_EnoughMoney_ReturnsTrue(double money)
        {
            var mock = new Mock<IAccount>();
            mock.Setup(x => x.WithdrawMoney(It.IsAny<double>()))
                .Returns(true);

            Bank bank = new Bank();

            Assert.IsTrue(bank.WithdrawMoney(2000, mock.Object));
        }
    }
}
