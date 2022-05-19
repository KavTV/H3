using Moq;
using NUnit.Framework;

namespace ATMProject.UnitTest
{
    public class BankTests
    {
        [Test]
        public void WithdrawMoney_EnoughMoney_ReturnsTrue()
        {
            //Make a mock of the object beccause it is interacting with database
            var mock = new Mock<IAccount>();
            mock.Setup(x => x.WithdrawMoney(It.IsAny<double>()))
                .Returns(true);

            Bank bank = new Bank();

            Assert.IsTrue(bank.WithdrawMoney(2000, mock.Object));
        }

        [Test]
        public void WithdrawMoney_InsufficientMoney_ReturnsFalse()
        {
            //Make a mock of the object beccause it is interacting with database
            var mock = new Mock<IAccount>();
            mock.Setup(x => x.WithdrawMoney(It.IsAny<double>()))
                .Returns(false);

            Bank bank = new Bank();

            Assert.IsFalse(bank.WithdrawMoney(3000, mock.Object));
        }

        [TestCase(1234, true)]
        [TestCase(5214, false)]
        [TestCase(1647, false)]
        public void CheckPin_PinTrue_ReturnsTrue(int pin, bool expected)
        {
            //Make a mock of the object beccause it is interacting with database
            var mock = new Mock<IAccount>();
            mock.Setup(x => x.CheckPin(1234))
                .Returns(true);

            Bank bank = new Bank();

            Assert.AreEqual(expected, bank.CheckPin(pin, mock.Object));
        }
    }
}
