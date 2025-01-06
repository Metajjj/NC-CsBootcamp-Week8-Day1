﻿using Microsoft.AspNetCore.Mvc;
using MiddlewareMVC.Services;

namespace MiddlewareMVC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdventurerController : ControllerBase
    {
        private AdventurerService _service;

        public AdventurerController(AdventurerService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult GetAllAdventurers()
        {
            return Ok(_service.GetAllAdventurers());
        }
    }
}