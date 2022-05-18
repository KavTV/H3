using Moq;
using NUnit.Framework;

namespace ATMProject.UnitTest
{
    [TestFixture]
    public class AccountTests
    {
        [Test]
        public void WithdrawMoney_ProperBalance_ReturnsTrue()
        {
            //Simulating account that tries to withdraw an amount that has enough money
            var mock = new Mock<IAccount>();
            mock.Setup(x => x.WithdrawMoney(4000))
                .Returns(true);
            

            Assert.IsTrue(mock.Object.WithdrawMoney(4000));
        }

        [Test]
        public void WithdrawMoney_InvalidBalance_ReturnsFalse()
        {
            //Simulating account that tries to withdraw an amount that has insufficient money
            var mock = new Mock<IAccount>();
            mock.Setup(x => x.WithdrawMoney(6907800))
                .Returns(false);


            Assert.IsFalse(mock.Object.WithdrawMoney(6907800));
        }

    }
}
