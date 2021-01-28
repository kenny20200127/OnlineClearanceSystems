﻿using EdoTrafficMgtCore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdoTrafficMgtWeb.ViewModels.Users
{
    public class UsersViewModel
    {
        public List<User> Users { get; set; }
        public IEnumerable<Role> Roles { get; set; }

    }
}
