using Raider.Domain.Entities;
using Raider.Wpf.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace Raider.Wpf.Services
{
    public class RoleDataService : IRoleDataService
    {
        private readonly RaiderDbContext _context;

        public RoleDataService(RaiderDbContext context)
        {
            _context = context;
        }

        public List<Role> GetAll()
        {
            return _context.Roles.ToList();
        }
    }
}