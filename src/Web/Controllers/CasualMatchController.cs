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

        [HttpGet("id/{id}")]
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

        [HttpGet("code/{code}")]
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
            var obj = _casualMatchService.Create(request, userId);
            return CreatedAtAction(nameof(GetById), new { id = obj.Id }, obj);
        }

        
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
                _casualMatchService.Delete(id, userId);
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] CasualMatchUpdateRequest request)
        {
            try
            {
                int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
                _casualMatchService.Update(id, userId, request);
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
                _casualMatchService.Join(userId, code);
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
                _casualMatchService.Leave(userId, username, code);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
