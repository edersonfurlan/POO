using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() || _context.Seller.Any() || _context.SalesRecord.Any())
                return; //o banco de dados já foi populado

            Department d1 = new Department(1, "Computers");
            Seller s1 = new Seller(1, "Bob Brown", "bob@gmail.com", new DateTime(1988, 05, 22), 1000.0, d1);
            SalesRecord sr1 = new SalesRecord(1, new DateTime(2021, 10, 19), 11000.0, SaleStatus.Billed, s1);

            _context.Department.AddRange(d1);
            _context.Seller.AddRange(s1);
            _context.SalesRecord.AddRange(sr1);

            _context.SaveChanges();
        }
    }
}
