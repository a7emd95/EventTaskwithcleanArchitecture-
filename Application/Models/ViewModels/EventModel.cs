using System;

// TODO: create DTOs and map DTO to view model (where mapping should occurs?) : answer : that one function of controller is preaper data
// for view
// TODO: check where view models shold stay ? Done : in Web Project (UI)  & DTOs in Web project (Web Api) 
namespace Application.Models.ViewModels
{
    public class EventModel
    {
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsConfliected { get; set; } = false ;
    }
}
