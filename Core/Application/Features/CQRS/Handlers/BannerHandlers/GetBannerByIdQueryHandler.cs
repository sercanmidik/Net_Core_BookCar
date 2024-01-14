using Application.Features.CQRS.Queries.BannerQueries;
using Application.Features.CQRS.Results.BannerResults;
using Application.Interfaces;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerByIdQueryHandler
    {
        private readonly IRepository<Banner> _bannerRepository;

        public GetBannerByIdQueryHandler(IRepository<Banner> bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }

        public async Task<GetByIdBannerQueryResult> Handler(GetBannerByIdQuery query)
        {
            var value= await _bannerRepository.GetByIdAsync(query.Id);
            return new GetByIdBannerQueryResult
            {
                BannerId = value.BannerId,
                Description = value.Description,
                Title = value.Title,
                VideoDescription = value.VideoDescription,
                VideoUrl = value.VideoUrl,
            };
        }
    }
}
