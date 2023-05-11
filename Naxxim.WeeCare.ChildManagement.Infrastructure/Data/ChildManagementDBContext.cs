using Microsoft.EntityFrameworkCore;
using Naxxim.WeeCare.ChildManagement.Domain.Entites;
using Naxxim.WeeCare.ChildManagement.Infrastructure.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naxxim.WeeCare.ChildManagement.Infrastructure.Data
{
    public class ChildManagementDBContext : DbContext
    {
        public ChildManagementDBContext(DbContextOptions<ChildManagementDBContext> options)
            : base(options)
        {
        }




        public DbSet<Child> Children { get; set; }
        public DbSet<ChildJournal> ChildJournals { get; set; }
        public DbSet<ChildIncidentDetails> ChildIncidentDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new IncidentsConfiguration());
            modelBuilder.ApplyConfiguration(new journalConfiguration());

        }

    }
}
