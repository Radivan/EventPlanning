using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EventPlanning.Models
{
    public class EventsEntities : DbContext
    {
        public EventsEntities() : base("EventPlanningDB") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Member>().ToTable("Members");
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Member> Members { get; set; }
    }
}