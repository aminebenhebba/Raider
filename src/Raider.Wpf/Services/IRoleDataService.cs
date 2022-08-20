using Raider.Domain.Entities;
using System.Collections.Generic;

namespace Raider.Wpf.Services
{
    public interface IRoleDataService
    {
        List<Role> GetAll();
    }
}