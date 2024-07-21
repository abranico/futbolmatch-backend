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
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;
        private readonly IPlayerService _playerService;

        public TeamController(ITeamService teamService, IPlayerService playerService)
        {
            _teamService = teamService;
            _playerService = playerService;

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_teamService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_teamService.GetById(id));

            }
            catch (NotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] TeamCreateRequest request)
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
            Player? player = _playerService.GetById(userId);
            var obj = _teamService.Create(request, player);
            return CreatedAtAction(nameof(GetById), new { id = obj.Id }, obj);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] TeamUpdateRequest request)
        {
            try
            {
                _teamService.Update(id, request);
                return NoContent();

            }
            catch (NotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                _teamService.Delete(id);
                return NoContent();

            }
            catch (NotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("[action]/{id}")]
        public IActionResult JoinLeague([FromRoute] int id, [FromBody] string code)
        {
            try
            {
                _teamService.JoinLeague(id, code);
                return NoContent();

            }
            catch (NotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
