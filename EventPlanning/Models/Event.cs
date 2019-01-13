using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventPlanning.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Place { get; set; }
        public string Organizer { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date of birth")]
        public DateTime? Date { get; set; }
    }
}