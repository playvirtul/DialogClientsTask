using DialogClients.Domain;
using Microsoft.AspNetCore.Mvc;

namespace DialogClients.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DialogsController : ControllerBase
    {
        private readonly IDialogsService _dialogsService;

        public DialogsController(IDialogsService dialogsService)
        {
            _dialogsService = dialogsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Guid[] clientsId)
        {
            var guid = await _dialogsService.FindDialog(clientsId);

            return Ok(guid);
        }
    }
}
