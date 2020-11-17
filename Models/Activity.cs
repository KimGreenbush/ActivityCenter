using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ActivityCenter.Extensions;

namespace ActivityCenter.Models
{
    public class Activity
    {
        [Key]
        public int ActivityId { get; set;}

        [Required]
        public string Title { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DateValidation]
        public DateTime Date { get; set; } //DateTime is whole object then cast to DateTime.Date for date and DateTime.TimeOfDay for time o'clock for separate inputs and rendering

        public string Time { get; set; }

        public string Duration { get; set; }

        public string DurationSpan { get; set; }

        [Required]
        public string Description { get; set; }

        public User Creator {get; set;}

        public List<UserActivity> Participants {get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}