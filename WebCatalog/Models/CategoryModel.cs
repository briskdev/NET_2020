using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebCatalog.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name: ")]
        [DataType(DataType.Text)]
        [StringLength(20)]
        public string Name { get; set; }
    }
}
