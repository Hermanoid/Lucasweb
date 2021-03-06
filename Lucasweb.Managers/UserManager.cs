﻿using Lucasweb.Contracts;
using Lucasweb.DataContracts;
using Lucasweb.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucasweb.Managers
{
    public class UserManager : IUserManager
    {
        public int CreateUser(User user)
        {
            var userToCreate = new User()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                UniqueEncryptPassword = ClassFactory.CreateClass<IEncryptEngine>().CreatePassword()
            };

            return ClassFactory.CreateClass<IUserAccessor>().CreateUser(userToCreate);
        }

        public User GetUser(int userId)
        {
            return ClassFactory.CreateClass<IUserAccessor>().GetUserById(userId);
        }

        public List<User> GetUsers(int f_index, int l_index)
        {
            return ClassFactory.CreateClass<IUserAccessor>().GetUsersBetween(f_index, l_index);
        }

        public int TotalUsers()
        {
            return ClassFactory.CreateClass<IUserAccessor>().GetTotalUsers();
        }
    }
}
