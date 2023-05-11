using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naxxim.WeeCare.ChildManagement.Application.Repositories
{
    public interface IRMQParentVerification
    {
        public void SendMessage<T>(T message);
    }
}
