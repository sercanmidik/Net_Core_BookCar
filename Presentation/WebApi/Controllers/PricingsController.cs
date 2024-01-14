using Application.Features.Mediator.Commands.PricingCommands;
using Application.Features.Mediator.Queries.PricingQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PricingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> PricingList()
        {
            var values = await _mediator.Send(new GetPricingQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> PricingGetById(int id)
        {
            var value = await _mediator.Send(new GetPricingByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> PricingCreate(CreatePricingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Başarılı Şekilde Eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> PricingUpdate(UpdatePricingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Başarılı Şekilde Güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> PricingRemove(int id)
        {
            await _mediator.Send(new RemovePricingCommand(id));
            return Ok("Başarılı Şekilde Silindi");
        }
    }
}
