using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EventPlanning.Models
{
    public class Member
    {
        [Key]
        public int Id { get; set; }
        public int IdEvent { get; set; }
        public string MemberName { get; set; }
    }
}