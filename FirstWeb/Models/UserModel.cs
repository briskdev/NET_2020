using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWeb.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(50)]
        [Display(Name = "Name:")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(200)]
        [Display(Name = "E-mail:")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [StringLength(15)]
        [Display(Name = "Phone number:")]
        public string Phone { get; set; }
    }
}