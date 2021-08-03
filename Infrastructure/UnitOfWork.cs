using Application.Interfaces;
using Application.Interfaces.Repoistroies;
using Infrastructure.Persistence;
using Infrastructure.Repositroies;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EventsContext dBContext;
        public UnitOfWork(EventsContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public void Dispose()
        {
            dBContext.Dispose();
        }

        public int SaveChanges()
        {
            return dBContext.SaveChanges();
        }

        private EventRepositroy eventRepo;
        public IEventRepositroy EventRepositroy
        {
            get
            {
                if (eventRepo == null)
                {
                    eventRepo = new EventRepositroy(dBContext);
                }

                return eventRepo;
            }
        }
    }
}
