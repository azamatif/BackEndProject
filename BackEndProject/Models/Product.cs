using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackEndProject.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public string Slug { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Review> Reviews { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
