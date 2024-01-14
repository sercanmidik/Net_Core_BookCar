using Application.Features.Mediator.Queries.FeatureQueries;
using Application.Features.Mediator.Queries.FooterAddressQueries;
using Application.Features.Mediator.Results.FooterAddressResults;
using Application.Interfaces;
using Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class GetFooterAddressQueryHandler : IRequestHandler<GetFooterAddressQuery, IEnumerable<GetFooterAddressQueryResult>>
    {
        private readonly IRepository<FooterAddress> _repostitory;

        public GetFooterAddressQueryHandler(IRepository<FooterAddress> repostitory)
        {
            _repostitory = repostitory;
        }

        public async Task<IEnumerable<GetFooterAddressQueryResult>> Handle(GetFooterAddressQuery request, CancellationToken cancellationToken)
        {
            var values = await _repostitory.GetAllAsync();
            return values.Select(x => new GetFooterAddressQueryResult
            {
                Address = x.Address,
                Description = x.Description,
                Email = x.Email,
                FooterAddressId = x.FooterAddressId,
                Phone = x.Phone
            }).ToList();
        }
    }
}
