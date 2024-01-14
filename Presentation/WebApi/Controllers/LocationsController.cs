using Application.Features.Mediator.Commands.LocationCommands;
using Application.Features.Mediator.Queries.LocationQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LocationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> LocationList()
        {
            var values = await _mediator.Send(new GetLocationQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> LocationGetById(int id)
        {
            var value = await _mediator.Send(new GetLocationByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> LocationCreate(CreateLocationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Lokasyon Başarlı Şekilde Eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> LocationUpdate(UpdateLocationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Locasyon Başarılı Şekilde Güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> LocationRemove(int id)
        {
            await _mediator.Send(new RemoveLocationCommand(id));
            return Ok("Locasyon Başarılı Şekilde Silindi");
        }
    }
}
