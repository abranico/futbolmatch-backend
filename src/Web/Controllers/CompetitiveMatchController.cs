using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
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
    public class CompetitiveMatchController : ControllerBase
    {
        private readonly ICompetitiveMatchService _competitiveMatchService;
        private readonly IPlayerService _playerService;
        public CompetitiveMatchController(ICompetitiveMatchService competitiveMatchService, IPlayerService playerService)
        {
            _competitiveMatchService = competitiveMatchService;
            _playerService = playerService;
        }
        

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_competitiveMatchService.GetAll());
        }

        [HttpGet("id/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_competitiveMatchService.GetById(id));

            }
            catch (NotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] CompetitiveMatchCreateRequest request)
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
            var obj = _competitiveMatchService.Create(request);
            return CreatedAtAction(nameof(GetById), new { id = obj.Id }, obj);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
                _competitiveMatchService.DeleteMatch(id, userId);
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMatchResult([FromRoute] int id, [FromBody] string result)
        {
            try
            {
                int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
                _competitiveMatchService.UpdateMatchResult(id, result, userId);
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

       
    }
}
