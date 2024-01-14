using Application.Features.Mediator.Commands.FooterAddresCommands;
using Application.Features.Mediator.Queries.FooterAddressQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterAddressesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FooterAddressesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> FooterAddresList()
        {
            var values = await _mediator.Send(new GetFooterAddressQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> FooterAddressGetById(int id)
        {
            var value= await _mediator.Send(new GetFooterAddressByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> FooterAddressCreate(CreateFooterAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Footer Addres Eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> FooterAddressUpdate(UpdateFooterAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Footer Address Güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> FooterAddressRemove(int id)
        {
            await _mediator.Send(new RemoveFooterAddressCommand(id));
            return Ok("Footer Address Silindi");
        }
    }
}
