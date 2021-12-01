using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VPWebSolutions.Data.Entities;
using VPWebSolutions.Models;

namespace VPWebSolutions.Data
{
    public interface IPizzaRepository
    {
        bool SaveAll();
        UserData GetUserById(int id);
        UserData GetUserByIdentityUserId(string currentUserId);
    }
}
