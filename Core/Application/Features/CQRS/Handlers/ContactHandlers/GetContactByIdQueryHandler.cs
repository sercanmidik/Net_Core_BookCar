using Application.Features.CQRS.Queries.ContactQueries;
using Application.Features.CQRS.Results.AboutResults;
using Application.Features.CQRS.Results.ContactResults;
using Application.Interfaces;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactByIdQueryHandler
    {
        private readonly IRepository<Contact> _contactRepository;

        public GetContactByIdQueryHandler(IRepository<Contact> contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<GetContactByIdQueryResult> Handler(GetContactByIdQuery query)
        {
            var value= await _contactRepository.GetByIdAsync(query.Id);
            return new GetContactByIdQueryResult
            {
                ContactId = value.ContactId,
                Email = value.Email,
                Message = value.Message,
                Name = value.Name,
                SendDate = value.SendDate,
                Subject = value.Subject,
            };
        }
    }
}
