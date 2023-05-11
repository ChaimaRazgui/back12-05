using Naxxim.WeeCare.ChildManagement.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naxxim.WeeCare.ChildManagement.Application.Repositories
{
    public interface IChildRepository
    {
        bool DeleteChild(int Id);
        Child GetChildById(int Id);
        Task<Child> CreateChild(Child child);
        List<Child> GetChildbyParentId(int ParentId);
        List<Child> GetChildren();
        Child UpdateChild(Child child);
        List<string> GetAllChildsId();
        Child GetChildByUniqueId(string code);
    }
}
