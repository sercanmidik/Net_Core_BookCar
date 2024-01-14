﻿using Application.Features.CQRS.Queries.CategoryQueries;
using Application.Features.CQRS.Results.CategoryResults;
using Application.Interfaces;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler
    {
        private readonly IRepository<Category> _repository;

        public GetCategoryByIdQueryHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<GetCategoryByIdQueryResult> Handler(GetCategoryByIdQuery query)
        {
            var value= await _repository.GetByIdAsync(query.Id);
            return new GetCategoryByIdQueryResult
            {
                CategoryId = value.CategoryId,
                Name = value.Name,
            };
        }
    }
}