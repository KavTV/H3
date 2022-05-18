using NUnit.Framework;

namespace FirstTest.UnitTest
{
    [TestFixture]
    public class ReservationTests
    {
        [Test]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
        {
            Reservation res = new Reservation(new User());

            bool result = res.CanBeCancelledBy(new User() { IsAdmin=true});

            Assert.IsTrue(result);
        }

        [Test]
        public void CanBeCancelledBy_UserMadeReservation_ReturnsTrue()
        {
            User user = new User() { IsAdmin = false };

            Reservation res = new Reservation(user);

            bool result = res.CanBeCancelledBy(user);

            Assert.IsTrue(result);
        }

        [Test]
        public void CanBeCancelledBy_UserIsNotAdminAndNoReservation_ReturnsFalse()
        {
            User user = new User() { IsAdmin = false };

            Reservation res = new Reservation(new User());

            bool result = res.CanBeCancelledBy(user);

            Assert.IsFalse(result);
        }
    }
}
