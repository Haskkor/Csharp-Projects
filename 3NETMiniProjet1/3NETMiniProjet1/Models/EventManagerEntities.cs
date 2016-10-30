using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace _3NETMiniProjet1.Models
{
    public class EventManagerEntities : DbContext
    {
        public DbSet<Contribution> Contributions { get; set; }
        public DbSet<ContributionType> ContributionTypes { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventStatus> EventStatuses { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contribution>().ToTable("Contributions");
            modelBuilder.Entity<ContributionType>().ToTable("ContributionTypes");
            modelBuilder.Entity<Event>().ToTable("Events");
            modelBuilder.Entity<EventStatus>().ToTable("EventStatuses");
            modelBuilder.Entity<EventType>().ToTable("EventTypes");
            modelBuilder.Entity<Role>().ToTable("Roles");
            modelBuilder.Entity<User>().ToTable("Users");

            base.OnModelCreating(modelBuilder);
        }
    }
}