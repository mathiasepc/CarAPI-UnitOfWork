using Endpoint.Repository.Database;
using Endpoint.Utilities.Interface;
using Endpoint.Utilities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endpoint.Repository.Repositories;

public class Repo : IRepo
{
    private readonly DatabaseContext _context;
    public Repo(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Make>> GetMake()
    {
        return await _context.Makes.Include(m => m.Models).ToListAsync();
    }
}
