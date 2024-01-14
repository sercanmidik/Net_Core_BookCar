using Application.Features.CQRS.Commands.ContactCommands;
using Application.Features.CQRS.Handlers.ContactHandlers;
using Application.Features.CQRS.Queries.ContactQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly CreateContactCommandHandler _createContactCommandHandler;
        private readonly UpdateContactCommandHandler _updateContactCommandHandler;
        private readonly RemoveContactCommandHandler _removeContactCommandHandler;
        private readonly GetContactByIdQueryHandler _getContactByIdQueryHandler;
        private readonly GetContactQueryHandler _getContactQueryHandler;

        public ContactsController(CreateContactCommandHandler createContactCommandHandler, UpdateContactCommandHandler updateContactCommandHandler, RemoveContactCommandHandler removeContactCommandHandler, GetContactByIdQueryHandler getContactByIdQueryHandler, GetContactQueryHandler getContactQueryHandler)
        {
            _createContactCommandHandler = createContactCommandHandler;
            _updateContactCommandHandler = updateContactCommandHandler;
            _removeContactCommandHandler = removeContactCommandHandler;
            _getContactByIdQueryHandler = getContactByIdQueryHandler;
            _getContactQueryHandler = getContactQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> ContactList()
        {
            var values = await _getContactQueryHandler.Handler();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(int id)
        {
            var value = await _getContactByIdQueryHandler.Handler(new GetContactByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> ContactCreate(CreateContactCommand command)
        {
            await _createContactCommandHandler.Handler(command);
            return Ok("İletişim Başarlı Şekilde Oluşturuldu");
        }

        [HttpPut]
        public async Task<IActionResult> ContactUpdate(UpdateContactCommand command)
        {
            await _updateContactCommandHandler.Handler(command);
            return Ok("İletişim Başarılı Şekilde Güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> ContactRemove(int id)
        {
            await _removeContactCommandHandler.Handler(new RemoveContactCommand(id));
            return Ok("İletişim Başarılı Şekilde Silindi");
                
        }
    }
}
