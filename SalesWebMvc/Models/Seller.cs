using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace SalesWebMvc.Models {
    public class Seller {

        public int Id { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} must be between 3 and 60 char")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Range(100.0, 50000.0, ErrorMessage = "{0} must be from {1} to {2}")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Display(Name = "Base salary")]
        [DataType(DataType.Currency)]
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
