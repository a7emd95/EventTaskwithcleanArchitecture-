using Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.AppServices
{
    public interface IEventAppService : IDisposable
    {
        List<EventModel> GetAllEventSorted();

    }
}
