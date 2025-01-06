using Microsoft.AspNetCore.Mvc;
using MiddlewareMVC.Services;

namespace MiddlewareMVC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdventurerController : ControllerBase
    {
        private IAdventurerService _service;

        public AdventurerController(IAdventurerService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult GetAllAdventurers()
        {
            return Ok(_service.GetAllAdventurers());
        }


        [HttpPost]
        public ActionResult AddAdventurer(Adventurer a)
        {

            a.Level = 1; //a.Level < 1 ? 1 : a.Level;

            var adventurer = new Adventurer(a.Name, a.FightingClass);

            return _service.AddAdventurer(adventurer) ? Ok(adventurer) : BadRequest("Could not be added!");
        }

        [HttpPatch("{id}")]
        public ActionResult PatchAdventurer(int id, Adventurer a)
        {
            if (_service.PatchAdventurer(id, a))
            {
                return Ok(a);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
