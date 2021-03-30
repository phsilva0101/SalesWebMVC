using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Models
{
    public class Seller
    {
        //ID
        public int Id { get; set; }

        //--------------------------------------------------------------------------------------------------

        //NAME
        [Required(ErrorMessage = "{0} required")] // Torna o campo obrigatorio, {0} pega e mostra o nome do atributo
        [StringLength(60, MinimumLength = 3, ErrorMessage = " {0} size should be between {2} and {1} characters")]
        public string Name { get; set; }

        //--------------------------------------------------------------------------------------------------

        //EMAIL
        [Required(ErrorMessage = "{0} required")]
        [EmailAddress(ErrorMessage = " Enter with a valid email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        //--------------------------------------------------------------------------------------------------

        //BIRTHDATE
        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Birth Date")] // Annotation para exibir na tela um elemento customizado, diferente do instanciado na prop.
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        //--------------------------------------------------------------------------------------------------

        //BASESALARY
        [Required(ErrorMessage = "{0} required")]
        [Range(850.0, 50000.0, ErrorMessage = "{0} must be from {1} to {2}")]
        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double BaseSalary { get; set; }

        //--------------------------------------------------------------------------------------------------

        //DEPARTMENTS
        public Department Department { get; set; }
        public int DepartmentId { get; set; }

        //--------------------------------------------------------------------------------------------------

        //SALES RECORD
        public ICollection<SalesRecord> SalesRecords { get; set; } = new List<SalesRecord>();

        //--------------------------------------------------------------------------------------------------

        //Constructors
        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        //--------------------------------------------------------------------------------------------------

        //Methods
        public void AddSales(SalesRecord salesRecord)
        {
            SalesRecords.Add(salesRecord);
        }

        public void RemoveSales(SalesRecord salesRecord)
        {
            SalesRecords.Remove(salesRecord);
        }

        public double TotalSales( DateTime initial, DateTime final)
        {
            return SalesRecords.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}
