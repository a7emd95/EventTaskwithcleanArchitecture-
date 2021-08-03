using Application.Models.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validitors
{
    public class EventValiditor : AbstractValidator<EventModel>
    {
        public EventValiditor()
        {
            RuleFor(e => e.Title).NotEmpty();
            RuleFor(e => e.Title).NotNull();
            RuleFor(e => e.Title).MinimumLength(3);
            RuleFor(e => e.Title).MaximumLength(100);

            RuleFor(e => e.StartDate).NotNull();
            RuleFor(e => e.StartDate).NotEmpty();

            RuleFor(e => e.StartDate).NotNull();
            RuleFor(e => e.EndDate).NotEmpty();
            


        }
    }
}
