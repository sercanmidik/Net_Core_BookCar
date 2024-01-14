using Application.Features.Mediator.Commands.ServiceCommands;
using Application.Interfaces;
using Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand>
    {
        private readonly IRepository<Service> _repo;

        public UpdateServiceCommandHandler(IRepository<Service> repo)
        {
            _repo = repo;
        }

        public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var value = await _repo.GetByIdAsync(request.ServiceId);
            value.Description= request.Description;
            value.Title= request.Title;
            value.IconUrl = request.IconUrl;
            await _repo.UpdateAsync(value);
        }
    }
}
