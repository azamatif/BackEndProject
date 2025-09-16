using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackEndProject.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(150)]
        public string Slug { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();

    }

}