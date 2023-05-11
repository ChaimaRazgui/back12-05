using Naxxim.WeeCare.ChildManagement.Application.Repositories;
using Naxxim.WeeCare.ChildManagement.Domain.Entites;
using Naxxim.WeeCare.ChildManagement.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naxxim.WeeCare.ChildManagement.Infrastructure.Repositories
{
    public class Journalrepository : IjournalRepository
    {
        private readonly ChildManagementDBContext _childManagementDBContext;
        public Journalrepository(ChildManagementDBContext childManagementDBContext)
        {
            _childManagementDBContext = childManagementDBContext;
        }
        public async Task<ChildJournal> CreateJournal(ChildJournal journal)
        {

            _childManagementDBContext.ChildJournals.Add(journal);
            await _childManagementDBContext.SaveChangesAsync();

            return journal;
        }
        public List<ChildJournal> GetAllJournals()
        {
            return _childManagementDBContext.ChildJournals.ToList();
        }
        public ChildJournal GetJournalById(int Id)
        {
            return _childManagementDBContext.ChildJournals.Where(x => x.JournalId == Id).FirstOrDefault();
        }
        public List<ChildJournal> GetJournalsByChildId(int childId)
        {
            return _childManagementDBContext.ChildJournals
                .Where(x => x.IdChild == childId)
                .ToList();
        }
        public ChildJournal UpdateJournal(ChildJournal journal)
        {
            var result = _childManagementDBContext.Update(journal);
            _childManagementDBContext.SaveChanges();
            return result.Entity;
        }
        public bool DeleteJournal(int Id)
        {
            var filteredData = _childManagementDBContext.ChildJournals.Where(x => x.JournalId == Id).FirstOrDefault();
            var result = _childManagementDBContext.Remove(filteredData);
            _childManagementDBContext.SaveChanges();
            return result != null ? true : false;
        }

      
    }
}
