using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTest
{
    public class Reservation
    {
        public User MadeBy;

        public Reservation(User user)
        {
            MadeBy = user;
        }

        public bool CanBeCancelledBy(User user)
        {
            if (user.IsAdmin)
            {
                return true;
            }
            if (MadeBy == user)
            {
                return true;
            }

            return false;
        }
    }
}
