using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LsSocial_Backend.Models
{
    public class UserModel
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        public List<PostModel> Posts { get; set; }
    }
}