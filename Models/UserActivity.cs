using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ActivityCenter.Models
{
    public class UserActivity
    {
        [Key]
        public int UserActivityId { get;set;}

        public int UserId { get;set;}
        public User Participant { get;set;}

        public int ActivityId { get;set;}
        public Activity Activity { get;set;}

                public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}