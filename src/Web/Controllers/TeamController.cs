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
            try
            {
                int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
                var obj = _teamService.Create(request, userId);
                return CreatedAtAction(nameof(GetById), new { id = obj.Id }, obj);
            }
            catch (NotAllowedException ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] TeamUpdateRequest request)
        {
            try
            {
                int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
                _teamService.Update(id, request, userId);
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
                _teamService.Delete(id, userId);
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("[action]")]
        public IActionResult Join([FromBody] string code)
        {
            try
            {
                int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
                _teamService.Join(userId, code);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("[action]")]
        public IActionResult Leave([FromBody] TeamLeaveRequest teamLeaveRequest)
        {
            string username = teamLeaveRequest.Username;
            string code = teamLeaveRequest.Code;
            try
            {
                int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
                
                _teamService.Leave(userId, username, code);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
