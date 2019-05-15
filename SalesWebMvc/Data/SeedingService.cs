using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Data {
    public class SeedingService {

        private SalesWebMvcContext Context;

        public SeedingService(SalesWebMvcContext context) {
            Context = context;
        }

        public void Seed() {
            if (Context.Department.Any() || Context.Seller.Any() || Context.SalesRecord.Any()) {
                return;
            }

            Department dept1 = new Department(1, "Computers");
            Department dept2 = new Department(2, "Electronics");
            Department dept3 = new Department(3, "Fashion");
            Department dept4 = new Department(4, "Books");

            Seller sel1 = new Seller(1, "John", "john@gmail.com", new DateTime(1980,5,2) , 1500.00, dept1 );
            Seller sel2 = new Seller(2, "Maria", "maria@gmail.com", new DateTime(1948, 2, 22), 2500.00, dept3);
            Seller sel3 = new Seller(3, "Alex", "alex@gmail.com", new DateTime(1990, 3, 15), 1300.00, dept2);
            Seller sel4 = new Seller(4, "Martha", "martha@gmail.com", new DateTime(1985, 5, 30), 1600.00, dept3);
            Seller sel5 = new Seller(5, "Donald", "donald@gmail.com", new DateTime(1974, 2, 12), 1400.00, dept4);
            Seller sel6 = new Seller(6, "Alex", "alex@gmail.com", new DateTime(1988, 10, 3), 1600.00, dept1);

            SalesRecord sr1 = new SalesRecord(1, new DateTime(2019, 3, 2), 800.00, SaleStatus.Billed, sel1);
            SalesRecord sr2 = new SalesRecord(2, new DateTime(2018, 2, 22), 1800.00, SaleStatus.Canceled, sel3);
            SalesRecord sr3 = new SalesRecord(3, new DateTime(2013, 1, 6), 200.00, SaleStatus.Pending, sel4);
            SalesRecord sr4 = new SalesRecord(4, new DateTime(2015, 3, 12), 300.00, SaleStatus.Billed, sel4);
            SalesRecord sr5 = new SalesRecord(5, new DateTime(2012, 5, 20), 550.00, SaleStatus.Billed, sel2);
            SalesRecord sr6 = new SalesRecord(6, new DateTime(2019, 5, 11), 1200.00, SaleStatus.Pending, sel1);
            SalesRecord sr7 = new SalesRecord(7, new DateTime(2009, 10, 20), 1800.00, SaleStatus.Canceled, sel4);
            SalesRecord sr8 = new SalesRecord(8, new DateTime(2008, 11, 14), 4800.00, SaleStatus.Canceled, sel2);
            SalesRecord sr9 = new SalesRecord(9, new DateTime(2009, 4, 12), 8000.00, SaleStatus.Billed, sel5);
            SalesRecord sr10 = new SalesRecord(10, new DateTime(2004, 7, 21), 2250.00, SaleStatus.Billed, sel6);
            SalesRecord sr11 = new SalesRecord(11, new DateTime(2000, 4, 17), 2600.00, SaleStatus.Billed, sel6);
            SalesRecord sr12 = new SalesRecord(12, new DateTime(2019, 1, 8), 3300.00, SaleStatus.Pending, sel3);
            SalesRecord sr13 = new SalesRecord(13, new DateTime(2010, 6, 11), 4500.00, SaleStatus.Billed, sel1);
            SalesRecord sr14 = new SalesRecord(14, new DateTime(2011, 5, 8), 200.00, SaleStatus.Canceled, sel3);
            SalesRecord sr15 = new SalesRecord(15, new DateTime(2007, 7, 19), 100.00, SaleStatus.Billed, sel3);
            SalesRecord sr16 = new SalesRecord(16, new DateTime(2005, 4, 14), 2400.00, SaleStatus.Canceled, sel1);
            SalesRecord sr17 = new SalesRecord(17, new DateTime(2001, 7, 29), 300.00, SaleStatus.Billed, sel6);
            SalesRecord sr18 = new SalesRecord(18, new DateTime(2011, 8, 25), 4600.00, SaleStatus.Pending, sel3);
            SalesRecord sr19 = new SalesRecord(19, new DateTime(2012, 8, 30), 5400.00, SaleStatus.Billed, sel2);
            SalesRecord sr20 = new SalesRecord(20, new DateTime(2004, 7, 21), 3250.00, SaleStatus.Billed, sel1);
            SalesRecord sr21 = new SalesRecord(21, new DateTime(2005, 4, 14), 2600.00, SaleStatus.Billed, sel6);
            SalesRecord sr22 = new SalesRecord(22, new DateTime(2019, 1, 8), 400.00, SaleStatus.Pending, sel5);
            SalesRecord sr23 = new SalesRecord(23, new DateTime(2001, 6, 1), 5500.00, SaleStatus.Billed, sel4);
            SalesRecord sr24 = new SalesRecord(24, new DateTime(2011, 6, 8), 700.00, SaleStatus.Canceled, sel1);
            SalesRecord sr25 = new SalesRecord(25, new DateTime(2007, 7, 19), 100.00, SaleStatus.Billed, sel2);
            SalesRecord sr26 = new SalesRecord(26, new DateTime(2005, 4, 14), 5400.00, SaleStatus.Canceled, sel3);
            SalesRecord sr27 = new SalesRecord(27, new DateTime(2001, 7, 9), 600.00, SaleStatus.Billed, sel4);
            SalesRecord sr28 = new SalesRecord(28, new DateTime(2011, 8, 25), 2600.00, SaleStatus.Pending, sel4);
            SalesRecord sr29 = new SalesRecord(29, new DateTime(2019, 8, 30), 6300.00, SaleStatus.Billed, sel1);
            SalesRecord sr30 = new SalesRecord(30, new DateTime(2019, 8, 30), 8400.00, SaleStatus.Billed, sel6);


            Context.Department.AddRange(dept1, dept2, dept3, dept4);

            Context.Seller.AddRange(sel1, sel2, sel3, sel4, sel5, sel6);

            Context.SalesRecord.AddRange(sr1, sr2, sr3, sr4, sr5, sr6, sr7, sr8, sr9, sr10, sr11, sr12, sr13, sr14, sr15, sr16, sr17, sr18, sr19, sr20, sr21, sr22, sr23, sr24, sr25, sr26, sr27, sr28, sr29, sr30);

            Context.SaveChanges();

        }

    }
}
