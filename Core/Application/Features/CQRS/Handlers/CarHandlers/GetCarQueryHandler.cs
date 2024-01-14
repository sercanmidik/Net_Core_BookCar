using Application.Features.CQRS.Results.CarResults;
using Application.Interfaces;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarQueryHandler
    {
        private readonly IRepository<Car> _repository;

        public GetCarQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<GetCarQueryResult>> Handler()
        {
            var values= await _repository.GetAllAsync();
            return values.Select(x => new GetCarQueryResult
            {
                BigCoverImageUrl = x.BigCoverImageUrl,
                BrandId = x.BrandId,
                CarId = x.CarId,
                CoverImageUrl = x.CoverImageUrl,
                Fuel=x.Fuel,
                Km=x.Km,
                Luggage=x.Luggage,
                Model = x.Model,
                Seat=x.Seat,
                Transmission = x.Transmission,
            }).ToList();
        }
    }
}
