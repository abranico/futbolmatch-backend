using Application.Interfaces;
using Application.Models.Requests;
using Application.Services;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CasualMatchController : ControllerBase
    {
        private readonly ICasualMatchService _casualMatchService;
        private readonly IPlayerService _playerService;
        public CasualMatchController(ICasualMatchService casualMatchService, IPlayerService playerService)
        {
            _casualMatchService = casualMatchService;
            _playerService = playerService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_casualMatchService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_casualMatchService.GetById(id));

            }
            catch (NotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] CasualMatchCreateRequest request)
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
            Player? player = _playerService.GetById(userId);
            var obj = _casualMatchService.Create(request, player);
            return CreatedAtAction(nameof(GetById), new { id = obj.Id }, obj);
        }

        
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                _casualMatchService.Delete(id);
                return NoContent();

            }
            catch (NotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
