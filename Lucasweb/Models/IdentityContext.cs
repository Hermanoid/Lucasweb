﻿using Lucasweb.DataContracts;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucasweb.Models
{
    public class IdentityContext : IdentityDbContext<AppUserId>
    {
        public IdentityContext() : base("name=LucaswebContext")
        {

        }
    }
}
