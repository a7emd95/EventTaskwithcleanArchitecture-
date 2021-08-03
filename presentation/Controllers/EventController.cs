using Application.Interfaces.AppServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.Models;

namespace UI.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventAppService eventAppService;

        public EventController(IEventAppService eventAppService)
        {
            this.eventAppService = eventAppService;
        }
        public IActionResult Index()
        {
            var eventsModels = eventAppService.GetAllEventSorted();
            var eventsViewModels = new List<EventViewModel>();

            //prepare viewModel for view 
            foreach (var item in eventsModels)
            {
                var viewModel = new EventViewModel()
                {
                    Title = item.Title,
                    EndDate = item.EndDate,
                    StartDate = item.StartDate,
                    IsConfliected = item.IsConfliected
                };
                eventsViewModels.Add(viewModel);

            }

            return View(eventsViewModels);
        }
    }
}
