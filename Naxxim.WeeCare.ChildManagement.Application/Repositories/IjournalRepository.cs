using Naxxim.WeeCare.ChildManagement.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naxxim.WeeCare.ChildManagement.Application.Repositories
{
    public interface IjournalRepository
    {
        Task<ChildJournal> CreateJournal(ChildJournal journal);
        List<ChildJournal> GetAllJournals();
        ChildJournal GetJournalById(int Id);
        List<ChildJournal> GetJournalsByChildId(int childId);
        ChildJournal UpdateJournal(ChildJournal journal);
        bool DeleteJournal(int Id);
    }
}
