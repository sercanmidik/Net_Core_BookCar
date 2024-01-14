using Application.Features.Mediator.Commands.PricingCommands;
using Application.Interfaces;
using Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Handlers.PricingHandlers
{
    public class RemovePricingCommandHandler : IRequestHandler<RemovePricingCommand>
    {
        private readonly IRepository<Pricing> _repo;

        public RemovePricingCommandHandler(IRepository<Pricing> repo)
        {
            _repo = repo;
        }

        public async Task Handle(RemovePricingCommand request, CancellationToken cancellationToken)
        {
          var value= await _repo.GetByIdAsync(request.Id);
            await _repo.RemoveAsync(value);
        }
    }
}
