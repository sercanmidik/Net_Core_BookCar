using Application.Features.Mediator.Commands.FeatureCommands;
using Application.Features.Mediator.Queries.FeatureQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FeaturesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> FeatureList()
        {
            var values = await _mediator.Send(new GetFeatureQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FetaureGetById(int id)
        {
            var value= await _mediator.Send(new GetFeatureByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> FeatureCrete(CreateFeatureCommand command)
        {
            await _mediator.Send(command);
            return Ok("Başarılı Şekilde Eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> FeatureUpdate(UpdateFeatureCommand command)
        {
            await _mediator.Send(command);
            return Ok("Başarılı Şekilde Güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> FeatureRemove(int id)
        {
            await _mediator.Send(new RemoveFeatureCommand(id));
            return Ok("Başarılı Bir ŞEkilde Silindi");
        }
    }
}
