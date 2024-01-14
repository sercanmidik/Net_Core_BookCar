using Application.Features.CQRS.Commands.BannerCommands;
using Application.Interfaces;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.BannerHandlers
{
    public class CreateBannerCommandHandler
    {
        private readonly IRepository<Banner> _bannerRepository;

        public CreateBannerCommandHandler(IRepository<Banner> bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }

        public async Task Handler(CreateBannerCommand command)
        {
            Banner banner = new Banner()
            {
                VideoUrl = command.VideoUrl,
                Description = command.Description,
                Title = command.Title,
                VideoDescription = command.VideoDescription,
            };
            await _bannerRepository.CreateAsync(banner);
        }
    }
}
