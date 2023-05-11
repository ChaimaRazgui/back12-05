using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Naxxim.WeeCare.ChildManagement.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naxxim.WeeCare.ChildManagement.Infrastructure.Configuration
{
    public class journalConfiguration :IEntityTypeConfiguration<ChildJournal>
    {
        public void Configure(EntityTypeBuilder<ChildJournal> builder)
        {
            builder
                    .HasOne<Child>(ci => ci.child)
                    .WithMany(c => c.Journals)
                    .HasForeignKey(ci => ci.IdChild)
                    .OnDelete(DeleteBehavior.Cascade);
            builder.HasKey(ci => ci.JournalId);
        }
    }
}
