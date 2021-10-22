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
            Department d2 = new Department(2, "Books");
            Seller s1 = new Seller(1, "Bob Brown", "bob@gmail.com", new DateTime(1988, 05, 22), 1000.0, d1);
            Seller s2 = new Seller(2, "Greta Blue", "greta@gmail.com", new DateTime(2000, 06, 27), 3000.0, d2);
            SalesRecord sr1 = new SalesRecord(1, new DateTime(2021, 10, 19), 11000.0, SaleStatus.Billed, s1);
            SalesRecord sr2 = new SalesRecord(2, new DateTime(2021, 10, 20), 15000.0, SaleStatus.Billed, s2);


            _context.Department.AddRange(d1);
            _context.Department.AddRange(d2);
            _context.Seller.AddRange(s1);
            _context.Seller.AddRange(s2);
            _context.SalesRecord.AddRange(sr1);
            _context.SalesRecord.AddRange(sr2);

            _context.SaveChanges();
        }
    }
}
