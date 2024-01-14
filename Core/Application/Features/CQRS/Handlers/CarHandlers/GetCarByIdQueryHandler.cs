﻿using Application.Features.CQRS.Queries.CarQueries;
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
    public class GetCarByIdQueryHandler
    {
        private readonly IRepository<Car> _repository;

        public GetCarByIdQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<GetCarByIdQueryResult> Handler(GetCarByIdQuery query)
        {
           var value= await _repository.GetByIdAsync(query.Id);
            return new GetCarByIdQueryResult
            {
                Transmission=value.Transmission,
                CarId=value.CarId,
                Seat=value.Seat,
                BigCoverImageUrl=value.BigCoverImageUrl,
                BrandId=value.BrandId,
                CoverImageUrl=value.CoverImageUrl,
                Fuel = value.Fuel,
                Km = value.Km,
                Luggage = value.Luggage,
                Model = value.Model
            };
        }
    }
}
