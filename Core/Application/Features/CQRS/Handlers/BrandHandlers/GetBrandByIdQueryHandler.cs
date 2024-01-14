using Application.Features.CQRS.Queries.BrandQueries;
using Application.Features.CQRS.Results.BrandResults;
using Application.Interfaces;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.BrandHandlers
{
    public class GetBrandByIdQueryHandler
    {
        private readonly IRepository<Brand> _brandRepository;

        public GetBrandByIdQueryHandler(IRepository<Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<GetByIdBrandQueryResult> Handler(GetBrandByIdQuery query)
        {
            var value = await _brandRepository.GetByIdAsync(query.Id);
            return new GetByIdBrandQueryResult()
            {
                BrandId = value.BrandId,
                Name=value.Name,
            };
        }
    }
}
