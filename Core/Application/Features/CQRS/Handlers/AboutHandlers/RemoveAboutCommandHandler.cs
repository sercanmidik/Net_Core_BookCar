using Application.Features.CQRS.Commands.AboutCommands;
using Application.Interfaces;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.AboutHandlers
{
    public class RemoveAboutCommandHandler
    {
        private readonly IRepository<About> _aboutRepository;

        public RemoveAboutCommandHandler(IRepository<About> aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }

        public async Task Handler(RemoveAboutCommand command)
        {
            var value= await _aboutRepository.GetByIdAsync(command.Id);
            await _aboutRepository.RemoveAsync(value);
        }
    }
}
