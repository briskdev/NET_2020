using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWeb.Models
{
    //Darbinieku raksturo vārds, uzvārds, dzimšanas gads, amats un nodaļa. 
    public class EmployeeModel
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(50)]
        [Display(Name = "Name: ")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(50)]
        [Display(Name = "Surname: ")]
        public string Surname { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of birth: ")]
        public DateTime BirthDate { get; set; }

        [DataType(DataType.Text)]
        [StringLength(50)]
        [Display(Name = "Occupation: ")]
        public string Occupation { get; set; }

        [DataType(DataType.Text)]
        [StringLength(50)]
        [Display(Name = "Department: ")]
        public string Department { get; set; }
    }
}
