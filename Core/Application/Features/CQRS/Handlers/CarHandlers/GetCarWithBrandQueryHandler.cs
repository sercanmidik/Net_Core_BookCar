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
    public class GetCarWithBrandQueryHandler
    {
        private readonly IRepository<Car> _carRepository;

        public GetCarWithBrandQueryHandler(IRepository<Car> carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<IEnumerable<GetCarWithBrandQueryResult>> Handler()
        {
            var values = await _carRepository.GetAllWhereWithInculudeAsync(null, new string[] { "Brand"});
            if (values!=null)
            {
                return values.Select(x => new GetCarWithBrandQueryResult
                {
                    BigCoverImageUrl = x.BigCoverImageUrl,
                    BrandId = x.BrandId,
                    BrandName = x.Brand.Name,
                    CarId = x.CarId,
                    CoverImageUrl = x.CoverImageUrl,
                    Fuel = x.Fuel,
                    Km = x.Km,
                    Luggage = x.Luggage,
                    Model = x.Model,
                    Seat = x.Seat,
                    Transmission = x.Transmission
                }).ToList();
            }
           return new List<GetCarWithBrandQueryResult>();
        }
    }
}
