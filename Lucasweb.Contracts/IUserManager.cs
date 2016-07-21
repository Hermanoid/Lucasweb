using Lucasweb.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucasweb.Contracts
{
    public interface IUserManager
    {

        int CreateUser(User user);
        User GetUser(int userId);
        List<User> GetUsers(int f_index, int l_index);
        int TotalUsers();
    }
}
