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
    public class UpdateBannerCommandHandler
    {
        private readonly IRepository<Banner> _bannerRepository;

        public UpdateBannerCommandHandler(IRepository<Banner> bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }

        public async Task Handler(UpdateBannerCommand command)
        {
            Banner banner = new Banner()
            {
                BannerId = command.BannerId,
                Description = command.Description,
                Title = command.Title,
                VideoDescription = command.Description,
                VideoUrl = command.VideoUrl,
            };
            await _bannerRepository.UpdateAsync(banner);
        }
    }
}
