using Application.Features.CQRS.Commands.BrandCommands;
using Application.Features.CQRS.Handlers.BrandHandlers;
using Application.Features.CQRS.Queries.BrandQueries;
using Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly CreateBrandCommandHandler _createBrandCommandHandler;
        private readonly UpdateBrandCommandHandler _updateBrandCommandHandler;
        private readonly RemoveBrandCommandHandler _removeBrandCommandHandler;
        private readonly GetBrandByIdQueryHandler _getBrandByIdQueryHandler;
        private readonly GetBrandQueryHandler _getBrandQueryHandler;

        public BrandsController(CreateBrandCommandHandler createBrandCommandHandler, UpdateBrandCommandHandler updateBrandCommandHandler, RemoveBrandCommandHandler removeBrandCommandHandler, GetBrandByIdQueryHandler getBrandByIdQueryHandler, GetBrandQueryHandler getBrandQueryHandler)
        {
            _createBrandCommandHandler = createBrandCommandHandler;
            _updateBrandCommandHandler = updateBrandCommandHandler;
            _removeBrandCommandHandler = removeBrandCommandHandler;
            _getBrandByIdQueryHandler = getBrandByIdQueryHandler;
            _getBrandQueryHandler = getBrandQueryHandler;
        }
        [HttpGet]
        public async Task<IActionResult> BrandGetAll()
        {
            var values = await _getBrandQueryHandler.Handler();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> BrandCreate(CreateBrandCommand command)
        {
            await _createBrandCommandHandler.Handler(command);
            return Ok("Marka Başarılı Şekilde Eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> BrandUpdate(UpdateBrandCommand command)
        {
            await _updateBrandCommandHandler.Handler(command);
            return Ok("Marka Başarılı Şekilde Güncellendi");
        }

        [HttpDelete]
        public async Task<IActionResult> BrandRemove(int id)
        {
            await _removeBrandCommandHandler.Handler(new RemoveBrandCommand(id));
            return Ok("Başarılı Şekilde Silindi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> BrandGetById(int id)
        {
            var value = await  _getBrandByIdQueryHandler.Handler(new GetBrandByIdQuery(id));
            return Ok(value);
        }
    }
}
