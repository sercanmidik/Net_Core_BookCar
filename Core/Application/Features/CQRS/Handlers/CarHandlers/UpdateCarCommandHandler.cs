﻿using Application.Features.CQRS.Commands.CarCommands;
using Application.Interfaces;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handler(UpdateCarCommand command)
        {
            var value= await _repository.GetByIdAsync(command.CarId);
            value.Fuel = command.Fuel;
            value.Transmission = command.Transmission;
            value.CarId = command.CarId;
            value.BigCoverImageUrl = command.BigCoverImageUrl;
            value.BrandId = command.BrandId;
            value.CoverImageUrl = command.CoverImageUrl;
            value.Fuel=command.Fuel;
            value.Km=command.Km;
            value.Luggage=command.Luggage;
            value.Model=command.Model;
            value.Seat=command.Seat;
            await _repository.UpdateAsync(value);
        }
    }
}
