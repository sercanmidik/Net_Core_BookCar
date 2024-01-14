using Application.Features.CQRS.Results.CarResults;
using Application.Interfaces.CarInterfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    {
        private readonly BookCarContext _context;

        public CarRepository(BookCarContext context)
        {
            _context = context;
        }

        public IEnumerable<GetCarWithBrandQueryResult> GetCarWithBrandName()
        {
            var value= _context.Cars.Include(c => c.Brand).ToList();
            return value.Select(x => new GetCarWithBrandQueryResult
            {
                BigCoverImageUrl = x.BigCoverImageUrl,
                BrandId = x.BrandId,
                BrandName=x.Brand.Name,
                CarId=x.CarId,
                CoverImageUrl=x.CoverImageUrl,
                Fuel=x.Fuel,
                Km=x.Km,
                Luggage=x.Luggage,
                Model=x.Model,
                Seat=x.Seat,
                Transmission = x.Transmission
            }).ToList();
        }
    }
}
