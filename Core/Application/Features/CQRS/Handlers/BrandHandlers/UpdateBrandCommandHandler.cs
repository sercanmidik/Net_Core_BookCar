﻿using Application.Features.CQRS.Commands.BrandCommands;
using Application.Interfaces;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.BrandHandlers
{
    public class UpdateBrandCommandHandler
    {
        private readonly IRepository<Brand> _repository;

        public UpdateBrandCommandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task Handler(UpdateBrandCommand command)
        {
            var value= await _repository.GetByIdAsync(command.BrandId);
            value.Name = command.Name;
            await _repository.UpdateAsync(value);
        }
    }
}
