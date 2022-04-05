using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEX_II.Models
{
    public class CrashContext : DbContext
    {
        public CrashContext()
        {
         
        }

        public CrashContext(DbContextOptions<CrashContext> options) : base(options)
        {

        }

        public DbSet<Crash> CrashData { get; set; }
    }
}
