using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EventPlanning.Models
{
    public class ApplicationUser: IdentityUser
    {
        public int Year { get; set; }
        public ApplicationUser()
        {
        }
    }
}