﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VPWebSolutions.Models;

namespace VPWebSolutions.Data
{
    public interface IPizzaRepository
    {
        bool SaveAll();
        ApplicationUser GetUserById(int id);
        ApplicationUser GetUserByIdentityUserId(int currentUserId);

    }
}
