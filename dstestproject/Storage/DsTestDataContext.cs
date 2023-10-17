using dstestproject.Storage.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dstestproject.Storage
{
    public class DsTestDataContext: DbContext
    {
        public DsTestDataContext(DbContextOptions<DsTestDataContext> options) : base(options)
        {

        }
        public DbSet<WeatherElement> WeatherElements { get; set; }

    }
}
