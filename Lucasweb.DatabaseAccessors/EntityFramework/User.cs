using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lucasweb.DatabaseAccessors.EntityFramework
{
    public class User
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [StringLength(256)]
        public string Email { get; set; }

        [StringLength(256)]
        public string FirstName { get; set; }

        [StringLength(256)]
        public string LastName { get; set; }

        [Required]
        [StringLength(256)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string UniqueEncryptPassword { get; set; }

        public static explicit operator DataContracts.User(User EFUser)
        {
            return new DataContracts.User()
            {
                Email = EFUser.Email,
                FirstName = EFUser.FirstName,
                LastName = EFUser.LastName,
                UniqueEncryptPassword = EFUser.UniqueEncryptPassword,
                UserId = EFUser.UserId,
                UserName = EFUser.UserName
            };
        }

        public static explicit operator User(DataContracts.User DCUser)
        {
            return new EntityFramework.User()
            {
                Email = DCUser.Email,
                FirstName = DCUser.FirstName,
                LastName = DCUser.LastName,
                UniqueEncryptPassword = DCUser.UniqueEncryptPassword,
                UserId = DCUser.UserId,
                UserName = DCUser.UserName
            };
        }
    }
}