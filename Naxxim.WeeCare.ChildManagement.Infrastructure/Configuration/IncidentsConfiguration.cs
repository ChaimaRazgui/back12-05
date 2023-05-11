using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Naxxim.WeeCare.ChildManagement.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Naxxim.WeeCare.ChildManagement.Infrastructure.Configuration
{
    public class IncidentsConfiguration : IEntityTypeConfiguration<ChildIncidentDetails>
    {
        public void Configure(EntityTypeBuilder<ChildIncidentDetails> builder)
        {
            builder
                    .HasOne<Child>(ci => ci.child)
                    .WithMany(c => c.Incidents)
                    .HasForeignKey(ci => ci.IdChild)
                    .OnDelete(DeleteBehavior.Cascade);
            builder.HasKey(ci => ci.HealthId);
        }
    }
}
