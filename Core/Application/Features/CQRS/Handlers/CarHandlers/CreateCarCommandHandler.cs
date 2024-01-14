using Application.Features.CQRS.Commands.CarCommands;
using Application.Interfaces;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class CreateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public CreateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handler(CreateCarCommand command)
        {
            await _repository.CreateAsync(new Car()
            {
                BigCoverImageUrl = command.BigCoverImageUrl,
                BrandId = command.BrandId,
                CoverImageUrl = command.CoverImageUrl,
                Fuel= command.Fuel,
                Km= command.Km,
                Luggage= command.Luggage,
                Model= command.Model,
                Seat= command.Seat,
                Transmission= command.Transmission,
            });
        }
    }
}
