using Application.Models.ViewModels;
using AutoMapper;
using Domin.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.AutoMapper
{
   public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<Event, EventModel>()
                .ForMember(ev => ev.IsConfliected, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
