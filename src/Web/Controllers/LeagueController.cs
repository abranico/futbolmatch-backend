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
    public class LeagueController : ControllerBase
    {
        private readonly ILeagueService _leagueService;
        private readonly IPlayerService _playerService;
        public LeagueController(ILeagueService leagueService, IPlayerService playerService)
        {
            _leagueService = leagueService;
            _playerService = playerService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_leagueService.GetAll());
        }

        [HttpGet("id/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_leagueService.GetById(id));

            }
            catch (NotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("code/{code}")]
        public IActionResult GetByJoinCode(string code)
        {
            try
            {
                return Ok(_leagueService.GetByJoinCode(code));

            }
            catch (NotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] LeagueCreateRequest request)
        {
            try
            {
                int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
                Player? player = _playerService.GetById(userId);
                var obj = _leagueService.Create(request, player);
                return CreatedAtAction(nameof(GetById), new { id = obj.Id }, obj);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] LeagueUpdateRequest request)
        {
            try
            {
                int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
                _leagueService.Update(id, request, userId);
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
                int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
                _leagueService.Delete(id, userId);
                return NoContent();

            }
            catch (NotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("[action]/{id}")]
        public IActionResult Join([FromRoute] int id, [FromBody] string code)
        {
            try
            {
                int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
                _leagueService.Join(id, code, userId);
                return NoContent();

            }
            catch (NotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
