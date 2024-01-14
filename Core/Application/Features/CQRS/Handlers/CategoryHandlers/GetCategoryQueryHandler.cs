﻿using Application.Features.CQRS.Results.CategoryResults;
using Application.Interfaces;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryQueryHandler
    {
        private readonly IRepository<Category> _repository;

        public GetCategoryQueryHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<GetCategoryQueryResult>> Handler()
        {
            var value= await _repository.GetAllAsync();
            return value.Select(x => new GetCategoryQueryResult()
            {
                CategoryId = x.CategoryId,
                Name = x.Name,
            }).ToList();
        }
    }
}
