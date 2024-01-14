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
    public class UpdateAboutCommandHandler
    {
        private readonly IRepository<About> _aboutRepository;

        public UpdateAboutCommandHandler(IRepository<About> aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }

        public async Task Handler(UpdateAboutCommand command)
        {
            About about = new About()
            {
                Title = command.Title,
                Description = command.Description,
                AboutId = command.AboutId,
                ImageUrl = command.ImageUrl,
            };
            await _aboutRepository.UpdateAsync(about);

        }
    }
}
