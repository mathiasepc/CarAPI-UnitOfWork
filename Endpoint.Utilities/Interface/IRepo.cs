using Endpoint.Utilities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endpoint.Utilities.Interface;

public interface IRepo
{
    Task<IEnumerable<Make>> GetMake();
    Task<IEnumerable<Feature>> GetFeatured();
    Task<bool> Insert(Vehicle vehicle);
    Task<Vehicle> GetById(Guid id);
}
