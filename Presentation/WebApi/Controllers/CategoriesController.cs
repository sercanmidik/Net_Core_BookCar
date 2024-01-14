using Application.Features.CQRS.Commands.CategoryCommands;
using Application.Features.CQRS.Handlers.CategoryHandlers;
using Application.Features.CQRS.Queries.CategoryQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CreateCategoryCommandHandler _categoryCommandHandler;
        private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;
        private readonly RemoveCategoryCommandHandler _removeCategoryCommandHandler;
        private readonly GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler;
        private readonly GetCategoryQueryHandler _getCategoryQueryHandler;

        public CategoriesController(CreateCategoryCommandHandler categoryCommandHandler, UpdateCategoryCommandHandler updateCategoryCommandHandler, RemoveCategoryCommandHandler removeCategoryCommandHandler, GetCategoryByIdQueryHandler getCategoryByIdQueryHandler, GetCategoryQueryHandler getCategoryQueryHandler)
        {
            _categoryCommandHandler = categoryCommandHandler;
            _updateCategoryCommandHandler = updateCategoryCommandHandler;
            _removeCategoryCommandHandler = removeCategoryCommandHandler;
            _getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
            _getCategoryQueryHandler = getCategoryQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var values = await _getCategoryQueryHandler.Handler();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> CategoryGetById(int id)
        {
            var value = await _getCategoryByIdQueryHandler.Handler(new GetCategoryByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CategoryCreate(CreateCategoryCommand command)
        {
            await _categoryCommandHandler.Handler(command);
            return Ok("Yeni Kategori Eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> CategoryUpdate(UpdateCategoryCommand command)
        {
            var value = await _getCategoryByIdQueryHandler.Handler(new GetCategoryByIdQuery(command.CategoryId));
            value.Name= command.Name;
            await _updateCategoryCommandHandler.Handler(command);
            return Ok("Kategori Güncellendi");
        }

        [HttpDelete]
        public async Task<IActionResult> CategoryRemove(int id)
        {
            await _removeCategoryCommandHandler.Handler(new RemoveCategoryCommand(id));
            return Ok("Kategori Silindi");
        }
    }
}
