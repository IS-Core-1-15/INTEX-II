using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEX_II.Models
{
    public class EFCrashRepository : ICrashRepository
    {
        private CrashContext _context { get; set; }

        public EFCrashRepository (CrashContext temp)
        {
            _context = temp;
        }

        public IQueryable<Crash> Crashes => _context.table_name;

        public void CreateCrash(Crash c)
        {
            _context.Add(c);
            _context.SaveChanges();
        }

        public void DeleteCrash(Crash c)
        {
            _context.Remove(c);
            _context.SaveChanges();
        }

        public void SaveCrash(Crash c)
        {
            _context.Update(c);
            _context.SaveChanges();
        }
    }
}
