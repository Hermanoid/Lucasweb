using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucasweb.Contracts;
using Lucasweb.DataContracts;
using Lucasweb.DatabaseAccessors.EntityFramework;

namespace Lucasweb.DatabaseAccessors
{
    public class UserAccessor : IUserAccessor
    {

        public int CreateUser(DataContracts.User user)
        {
            EntityFramework.User userToCreate = (EntityFramework.User) user;
            using (var db = new DatabaseContext())
            {
                var result = db.Users.Add(userToCreate);
                db.SaveChanges();
                return result.UserId;
            }
        }

        public DataContracts.User GetUserById(int userId)
        {
            using (var db = new DatabaseContext())
            {
                return (DataContracts.User)db.Users.Find(userId);
            }
        }
    }
}
