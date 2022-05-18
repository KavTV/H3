using NUnit.Framework;

namespace ATMProject.UnitTest
{
    public class CreditCardTests
    {
        [TestCase(8654357)]
        [TestCase(537322434)]
        [TestCase(1111)]
        [TestCase(5373)]
        [TestCase(4535)]
        public void CheckPin_CorrectPin_ReturnsTrue(int pin)
        {
            CreditCard card = new CreditCard() { pinCode = pin };

            bool res = card.CheckPin(pin);

            Assert.IsTrue(res);
        }

        [TestCase(8654357)]
        [TestCase(537322434)]
        [TestCase(1111)]
        [TestCase(5373)]
        [TestCase(4535)]
        public void CheckPin_IncorrectPin_ReturnsFalse(int pin)
        {
            CreditCard card = new CreditCard() { pinCode = 1234 };

            bool res = card.CheckPin(pin);

            Assert.IsFalse(res);
        }
    }
}
