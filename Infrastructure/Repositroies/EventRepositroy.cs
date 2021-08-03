using Application.Interfaces.Repoistroies;
using Domin.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositroies
{
    public class EventRepositroy : BaseRepositroy<Event>, IEventRepositroy
    {
        public EventRepositroy(DbContext context) : base(context)
        {
        }
    }
}
