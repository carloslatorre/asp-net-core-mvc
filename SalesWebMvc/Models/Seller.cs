using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SalesWebMvc.Models {
    public class Seller {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double BaseSalary { get; set; }
        public Department Depto { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> SalesRec { get; set; } = new List<SalesRecord>();

        public Seller() {

        }

        public Seller (int id, string name, string email, DateTime birth, double salary, Department dept) {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birth;
            BaseSalary = salary;
            Depto = dept;
        }

        public void AddSales (SalesRecord sr) {
            SalesRec.Add(sr);            
        }

        public void RemoveSales(SalesRecord sr) {
            SalesRec.Remove(sr);
        }

        public double TotalSales (DateTime ini, DateTime end) {
            return SalesRec.Where(sr => sr.Date >= ini && sr.Date <= end).Sum(sr => sr.Amount);
        }

    }
}
