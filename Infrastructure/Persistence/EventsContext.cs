using Domin.Entites;
using Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.Persistence
{
    public class EventsContext : DbContext
    {
        public EventsContext(DbContextOptions options ) : base(options)
        {
        }

        public EventsContext()
        {
        }

        public virtual DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region apply for one type
            //modelBuilder.ApplyConfiguration(new EventConfiguration()); //only Event
            #endregion

            //all configuration 
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);

        }
    }
}
