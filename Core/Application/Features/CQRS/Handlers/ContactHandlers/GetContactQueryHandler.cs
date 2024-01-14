﻿using Application.Features.CQRS.Results.ContactResults;
using Application.Interfaces;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactQueryHandler
    {
        private readonly IRepository<Contact> _repository;

        public GetContactQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<GetContactQueryResult>> Handler()
        {
            var values= await _repository.GetAllAsync();
            return values.Select(x => new GetContactQueryResult
            {
                ContactId = x.ContactId,
                Email=x.Email,
                Message=x.Message,
                Name=x.Name,
                SendDate=x.SendDate,
                Subject=x.Subject,
            }).ToList();
        }
    }
}
