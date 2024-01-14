using Application.Features.Mediator.Queries.LocationQueries;
using Application.Features.Mediator.Results.LocationResults;
using Application.Interfaces;
using Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Handlers.LocationHandlers
{
    public class GetLocationQueryHandler : IRequestHandler<GetLocationQuery, IEnumerable<GetLocationQueryResult>>
    {
        private readonly IRepository<Location> _locationRepository;

        public GetLocationQueryHandler(IRepository<Location> locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<IEnumerable<GetLocationQueryResult>> Handle(GetLocationQuery request, CancellationToken cancellationToken)
        {
            var values = await _locationRepository.GetAllAsync();
            return values.Select(x=>new GetLocationQueryResult
            {
                LocationId = x.LocationId,
                Name=x.Name,
            }).ToList();
        }
    }
}
