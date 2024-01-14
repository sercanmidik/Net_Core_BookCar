using Application.Features.CQRS.Commands.CarCommands;
using Application.Features.CQRS.Handlers.CarHandlers;
using Application.Features.CQRS.Queries.CarQueries;
using Application.Interfaces.CarInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CreateCarCommandHandler _createCarCommandHandler;
        private readonly UpdateCarCommandHandler _updateCarCommandHandler;
        private readonly RemoveCarCommandHandler _removeCarCommandHandler;
        private readonly GetCarByIdQueryHandler _getCarByIdQueryHandler;
        private readonly GetCarQueryHandler _getCarQueryHandler;
        private readonly GetCarWithBrandQueryHandler _getCarWithBrandQueryHandler;
        private readonly ICarRepository _carRepository;

        public CarsController(CreateCarCommandHandler createCarCommandHandler, UpdateCarCommandHandler updateCarCommandHandler, RemoveCarCommandHandler removeCarCommandHandler, GetCarByIdQueryHandler getCarByIdQueryHandler, GetCarQueryHandler getCarQueryHandler, GetCarWithBrandQueryHandler getCarWithBrandQueryHandler, ICarRepository carRepository)
        {
            _createCarCommandHandler = createCarCommandHandler;
            _updateCarCommandHandler = updateCarCommandHandler;
            _removeCarCommandHandler = removeCarCommandHandler;
            _getCarByIdQueryHandler = getCarByIdQueryHandler;
            _getCarQueryHandler = getCarQueryHandler;
            _getCarWithBrandQueryHandler = getCarWithBrandQueryHandler;
            _carRepository = carRepository;
        }


        [HttpGet]
        public async Task<IActionResult> CarList()
        {
            var values = await _getCarQueryHandler.Handler();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CarCreate(CreateCarCommand command)
        {
            await _createCarCommandHandler.Handler(command);
            return Ok("Araç Başarılı Şekilde Eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> CarUpdate(UpdateCarCommand command)
        {
            await _updateCarCommandHandler.Handler(command);
            return Ok("Araç Başarılı Şekilde Güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> CarRemove(int id)
        {
            await _removeCarCommandHandler.Handler(new RemoveCarCommand(id));
            return Ok("Araç Başarılı Şekilde Silindi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> CarGetById(int id)
        {
            var value= await _getCarByIdQueryHandler.Handler(new GetCarByIdQuery(id));
            return Ok(value);
        }
        [HttpGet("GetCarWithBrandName")]
        public async Task<IActionResult> GetCarWithBrandName()
        {
            var values = await _getCarWithBrandQueryHandler.Handler();
            return Ok(values);
        }
        [HttpGet("GetCarWithBrandNameTwo")]
        public IActionResult GetCarWithBrandNameTwo()
        {
            var value = _carRepository.GetCarWithBrandName();
            return Ok(value);
        }
    }
}
