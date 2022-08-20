using Raider.Domain.Entities;
using System.Collections.Generic;

namespace Raider.Wpf.Services
{
    public interface ISpecialisationDataService
    {
        List<Specialisation> GetAll();
    }
}
