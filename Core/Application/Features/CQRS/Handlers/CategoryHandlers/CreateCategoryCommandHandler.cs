using Application.Features.CQRS.Commands.CarCommands;
using Application.Features.CQRS.Commands.CategoryCommands;
using Application.Interfaces;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class CreateCategoryCommandHandler
    {
        private readonly IRepository<Category> _repository;

        public CreateCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task Handler(CreateCategoryCommand command)
        {
            await _repository.CreateAsync(new Category { Name = command.Name });
        }
    }
}
