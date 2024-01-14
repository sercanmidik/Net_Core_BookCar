using Application.Features.CQRS.Queries.AboutQueries;
using Application.Features.Mediator.Commands.ServiceCommands;
using Application.Features.Mediator.Queries.ServiceQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServicesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ServiceList()
        {
            var values = await _mediator.Send(new GetServiceQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ServiceGetById(int id)
        {
            var value = await _mediator.Send(new GetServiceByIdQuery(id));
            return Ok(value);
        }

        [HttpDelete]
        public async Task<IActionResult> ServiceRemove(int id)
        {
             await _mediator.Send(new RemoveServiceCommand(id));
            return Ok("Servis Silindi");
        }
        [HttpPost]
        public async Task<IActionResult> ServiceCreate(CreateServiceCommand command)
        {
            await _mediator.Send(command);
            return Ok("Servis Başarılı Şekilde Eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> ServiceUpdate(UpdateServiceCommand command)
        {
            await _mediator.Send(command);
            return Ok("Servis Başarılı Şekilde Güncellendi");
        }
    }
}
