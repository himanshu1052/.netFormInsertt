using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public  class UserDAL
    {
        public void Insertuser(User user)
        {
            using (var context = new db())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }

        }

        public List <User> GetAllUsers()
        {
            using (var context = new db()) {

                return context.Users.ToList();
            }

        }

    }
}
