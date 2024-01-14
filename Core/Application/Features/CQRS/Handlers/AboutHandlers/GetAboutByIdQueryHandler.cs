using Application.Features.CQRS.Queries.AboutQueries;
using Application.Features.CQRS.Results.AboutResults;
using Application.Interfaces;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.AboutHandlers
{
    public class GetAboutByIdQueryHandler
    {
        private readonly IRepository<About> _aboutRepository;

        public GetAboutByIdQueryHandler(IRepository<About> aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }

        public async Task<GetAboutByIdQueryResult> Handler(GetAboutByIdQuery query)
        {
            var value= await _aboutRepository.GetByIdAsync(query.Id);
            return new GetAboutByIdQueryResult()
            {
                AboutId = value.AboutId,
                Description = value.Description,
                ImageUrl = value.ImageUrl,
                Title = value.Title,
            };
        }
    }
}
