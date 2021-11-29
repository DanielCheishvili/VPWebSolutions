using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VPWebSolutions.Models;

namespace VPWebSolutions.Data
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly MenuDbContext _ctx;

        public PizzaRepository(MenuDbContext ctx)
        {
            _ctx = ctx;  
        }
        public ApplicationUser GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public ApplicationUser GetUserByIdentityUserId(int currentUserId)
        {
            throw new NotImplementedException();
        }

        public bool SaveAll()
        {
            throw new NotImplementedException();
        }
    }
}
