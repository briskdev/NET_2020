using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebCatalog.Models
{
    public class ItemModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name: ")]
        [DataType(DataType.Text)]
        [StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Description: ")]
        [DataType(DataType.Text)]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Price: ")]
        public decimal Price { get; set; }

        [Display(Name = "Location: ")]
        [DataType(DataType.Text)]
        [StringLength(150)]
        public string Location { get; set; }

        [Display(Name = "Category: ")]
        [DataType(DataType.Text)]
        [StringLength(20)]
        public string CategoryName { get; set; }

        public CategoryModel Category { get; set; }
    }
}
