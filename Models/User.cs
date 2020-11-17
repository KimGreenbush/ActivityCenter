using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ActivityCenter.Extensions;

namespace ActivityCenter.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage="Name must be longer than 2 letters")]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage="Please enter a valid email")]
        public string Email { get; set; }

        [Required]
        // [MinLength(8, ErrorMessage="Password must be at least 8 characters")]
        [PasswordValidation]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped]
        [Compare("Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm PW")]
        public string Confirm { get; set; }

        public List<UserActivity> Activities {get; set;}

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}