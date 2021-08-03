using Application.Interfaces;
using Application.Interfaces.AppServices;
using Application.Models.ViewModels;
using AutoMapper;
using Domin.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices
{
    public class EventAppService : IEventAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EventAppService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public void Dispose()
        {
            _unitOfWork.Dispose();

        }

        public List<EventModel> GetAllEventSorted()
        {
            var events = _mapper.Map<List<EventModel>>(_unitOfWork.EventRepositroy.GetAllSorted(e => e.StartDate));
            return CheckCoflectAlgrothim(events);
        }

        private bool CheckConflect(EventModel FristEvent, EventModel SecondEvent)
        {
            if (FristEvent.StartDate > SecondEvent.StartDate && FristEvent.StartDate < SecondEvent.EndDate
                || FristEvent.StartDate == SecondEvent.StartDate || FristEvent.EndDate == SecondEvent.EndDate)
            {
                return true;
            }
            return false;
        }

        private List<EventModel> CheckCoflectAlgrothim(List<EventModel> events)
        {
            for (int i = 0; i < events.Count; i++)
                if (events[i].IsConfliected == false)
                {
                    for (int j = i + 1; j < events.Count; j++)
                        if (CheckConflect(events[i], events[j]))
                        {
                            events[j].IsConfliected = true;
                            events[i].IsConfliected = true;
                        }
                }


            return events;
        }
    }
}
