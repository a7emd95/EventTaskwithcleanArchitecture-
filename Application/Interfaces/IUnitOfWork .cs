using Application.Interfaces.Repoistroies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
        IEventRepositroy EventRepositroy { get; }
    }

    
}
