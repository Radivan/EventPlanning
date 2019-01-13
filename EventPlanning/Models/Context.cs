using EventPlanning.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EventPlanning.Models
{
    public class Context : IdentityDbContext<ApplicationUser>
    {
        public Context() : base("EventPlanningDB") { }

        public static Context Create()
        {
            return new Context();
        }
    }
}