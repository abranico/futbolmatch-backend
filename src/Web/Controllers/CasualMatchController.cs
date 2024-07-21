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

        [HttpGet("availables")]
        public IActionResult GetAllAvailables()
        {
            return Ok(_casualMatchService.GetAll().Where(match => match.Open == true));
        }

        [HttpGet("{code}")]
        public IActionResult GetByJoinCode(string code)
        {
            try
            {
                return Ok(_casualMatchService.GetByJoinCode(code));

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
            return CreatedAtAction(nameof(GetByJoinCode), new { code = obj.JoinCode }, obj);
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

        [HttpPost("[action]")]
        public IActionResult Join([FromBody] string code)
        {
            try
            {
                string username = User.Claims.FirstOrDefault(c => c.Type == "username")?.Value;
                _casualMatchService.Join(username, code);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("[action]")]
        public IActionResult Leave([FromBody] CasualMatchLeaveRequest casualMatchLeaveRequest)
        {
            string username = casualMatchLeaveRequest.Username;
            string code = casualMatchLeaveRequest.Code;
            try
            {
                int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
                Player? player = _playerService.GetById(userId);
                _casualMatchService.Leave(player, username, code);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
