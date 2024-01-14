using Application.Features.CQRS.Commands.ContactCommands;
using Application.Interfaces;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.ContactHandlers
{
    public class UpdateContactCommandHandler
    {
        private readonly IRepository<Contact> _contactRepository;

        public UpdateContactCommandHandler(IRepository<Contact> contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task Handler(UpdateContactCommand command)
        {
            var value= await _contactRepository.GetByIdAsync(command.ContactId);
            value.SendDate = command.SendDate;
            value.Subject = command.Subject;
            value.Email = command.Email;
            value.Message = command.Message;
            value.Name  = command.Name;
            value.ContactId = command.ContactId;
            await _contactRepository.UpdateAsync(value);
        }
    }
}
