using Lucasweb.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucasweb.Contracts
{
    public interface IUserAccessor
    {
        int CreateUser(User user);
        User GetUserById(int userId);
        List<User> GetUsersBetween(int f_index, int l_index);
    }
}
