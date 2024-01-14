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
    public class RemoveBannerCommandHandler
    {
        private readonly IRepository<Banner> _bannerRepository;

        public RemoveBannerCommandHandler(IRepository<Banner> bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }

        public async Task Handler(RemoveBannerCommand command)
        {
            var value= await _bannerRepository.GetByIdAsync(command.Id);
            await _bannerRepository.RemoveAsync(value);
        }
    }
}
