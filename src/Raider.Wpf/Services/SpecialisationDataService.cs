using Raider.Domain.Entities;
using Raider.Wpf.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace Raider.Wpf.Services
{
    public class SpecialisationDataService : ISpecialisationDataService
    {
        private readonly RaiderDbContext _context;

        public SpecialisationDataService(RaiderDbContext context)
        {
            _context = context;
        }

        public List<Specialisation> GetAll()
        {
            var result = _context.Specialisations.ToList();
            return result;
        }
    }
}