using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VPWebSolutions.Data.Entities;
using VPWebSolutions.Models;

namespace VPWebSolutions.Data
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly BusinessDbContext _ctx;
        public PizzaRepository(BusinessDbContext ctx)
        {
            _ctx = ctx;
        }
        
        UserData IPizzaRepository.GetUserById(int id)
        {
            return _ctx.UserDatas.SingleOrDefault(p => p.UserDataId == id);
        }

        UserData IPizzaRepository.GetUserByIdentityUserId(int currentUserId)
        {
            return _ctx.UserDatas.SingleOrDefault(p => p.IdentityUserId == currentUserId.ToString());
        }

        bool IPizzaRepository.SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }
    }
}
