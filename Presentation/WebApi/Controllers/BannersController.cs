using Application.Features.CQRS.Commands.BannerCommands;
using Application.Features.CQRS.Handlers.BannerHandlers;
using Application.Features.CQRS.Queries.BannerQueries;
using Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController : ControllerBase
    {
        private readonly CreateBannerCommandHandler _createBannerHandler;
        private readonly GetBannerByIdQueryHandler _getBannerByIdQueryHandler;
        private readonly GetBannerQueryHandler _getBannerQueryHandler;
        private readonly RemoveBannerCommandHandler _removeBannerHandler;
        private readonly UpdateBannerCommandHandler _updateBannerHandler;

        public BannersController(CreateBannerCommandHandler createBannerHandler, GetBannerByIdQueryHandler getBannerByIdQueryHandler, GetBannerQueryHandler getBannerQueryHandler, RemoveBannerCommandHandler removeBannerHandler, UpdateBannerCommandHandler updateBannerHandler)
        {
            _createBannerHandler = createBannerHandler;
            _getBannerByIdQueryHandler = getBannerByIdQueryHandler;
            _getBannerQueryHandler = getBannerQueryHandler;
            _removeBannerHandler = removeBannerHandler;
            _updateBannerHandler = updateBannerHandler;
        }

        [HttpGet]
        public async Task<IActionResult> BannerList()
        {
            var values = await _getBannerQueryHandler.Handler();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BannerGetById(int id)
        {
            var value =await _getBannerByIdQueryHandler.Handler(new GetBannerByIdQuery(id));
            return Ok(value);
        }

        [HttpPut]
        public async Task<IActionResult> BannerUpdate(UpdateBannerCommand command)
        {
            await _updateBannerHandler.Handler(command);
            return Ok("Banner Güncellendi");
        }
        [HttpPost]
        public async Task<IActionResult> BannerCreate(CreateBannerCommand command)
        {

            await _createBannerHandler.Handler(command);
            return Ok("Banner Başarılı Şekilde Eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> BannerRemove(int id)
        {
            await _removeBannerHandler.Handler(new RemoveBannerCommand(id));
            return Ok("Banner Başarlı Şekilde Silindi");
        }
    }
}
