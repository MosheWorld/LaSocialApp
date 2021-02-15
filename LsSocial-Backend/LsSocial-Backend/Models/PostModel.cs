using System;
using System.ComponentModel.DataAnnotations;

namespace LsSocial_Backend.Models
{
    public class PostModel
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        [Required]
        public Guid UserID { get; set; }

        [Required]
        public UserModel User { get; set; }
    }
}