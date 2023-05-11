using Microsoft.EntityFrameworkCore;
using Naxxim.WeeCare.ChildManagement.Application.DTOs;
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
    public class ChildRepository : IChildRepository
    {
        private readonly ChildManagementDBContext _childManagementDBContext;
        public ChildRepository(ChildManagementDBContext childManagementDBContext) 
        {
            _childManagementDBContext= childManagementDBContext;
        }
        public Child GetChildById(int Id)
        {
            return _childManagementDBContext.Children.Where(x => x.ChildId == Id).FirstOrDefault();
        }
        public Child GetChildByUniqueId(string code)
        {
            return _childManagementDBContext.Children.Where(x => x.UniqueCode == code).FirstOrDefault();
        }
        public async Task<Child> CreateChild(Child child)
        {
            _childManagementDBContext.Children.Add(child);
            await _childManagementDBContext.SaveChangesAsync();

            return child;
        }
        public List<Child> GetChildbyParentId (int Parentid)
        {
            return _childManagementDBContext.Children.Where(x => x.ParentId ==Parentid).ToList();
        }
        public List<Child> GetChildren()
        {
            return _childManagementDBContext.Children.Include(c => c.Incidents).ToList();
        }
        public Child UpdateChild(Child child)
        {
            var result = _childManagementDBContext.Update(child);
            _childManagementDBContext.SaveChanges();
            return result.Entity;
        }
        public bool DeleteChild(int Id)
        {
            var filteredData = _childManagementDBContext.Children.Where(x => x.ChildId == Id).FirstOrDefault();
            var result = _childManagementDBContext.Remove(filteredData);
            _childManagementDBContext.SaveChanges();
            return result != null ? true : false;
        }
        public List<string> GetAllChildsId()
        {
           return  _childManagementDBContext.Children.Select(x => x.UniqueCode).ToList(); 
        }
    
    }
}
