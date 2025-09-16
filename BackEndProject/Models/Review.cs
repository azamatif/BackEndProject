using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndProject.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        public string AuthorId { get; set; }

        [Required]
        [StringLength(1000)]
        public string Content { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; } = 5;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
    }
}