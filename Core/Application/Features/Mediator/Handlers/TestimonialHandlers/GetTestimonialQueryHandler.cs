using Application.Features.Mediator.Queries.TestimonialQueries;
using Application.Features.Mediator.Results.TestimonialResults;
using Application.Interfaces;
using Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class GetTestimonialQueryHandler : IRequestHandler<GetTestimonialQuey, IEnumerable<GetTestimonialQueryResult>>
    {
        private readonly IRepository<Testimonial> _repo;

        public GetTestimonialQueryHandler(IRepository<Testimonial> repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<GetTestimonialQueryResult>> Handle(GetTestimonialQuey request, CancellationToken cancellationToken)
        {
            var values = await _repo.GetAllAsync();
            return values.Select(x => new GetTestimonialQueryResult
            {
                Comment = x.Comment,
                ImageUrl = x.ImageUrl,
                Name = x.Name,
                Title = x.Title,
                TestimonialId = x.TestimonialId,
            }).ToList();
        }
    }
}
