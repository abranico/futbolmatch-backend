using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Exceptions;
using Application.Models.Requests;
using Application.Interfaces;
using Application.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAll()
        {
            return Ok(_playerService.GetAll());
        }

        [HttpGet("id/{id}")]
        [AllowAnonymous]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_playerService.GetById(id));

            } catch (NotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("username/{username}")]
        [AllowAnonymous]
        public IActionResult GetByUsername(string username)
        {
            try
            {
                return Ok(_playerService.GetByUsername(username));

            }
            catch (NotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [AllowAnonymous]
        public IActionResult Create([FromBody] PlayerCreateRequest request)
        {
            var obj = _playerService.Create(request);
            return CreatedAtAction(nameof(GetById), new { id = obj.Id }, obj);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] PlayerUpdateRequest request)
        {
            try
            {
                int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
                _playerService.Update(id, request, userId);
                return NoContent();

            } catch (Exception ex)
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
                _playerService.Delete(id, userId);
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("[action]")]
        public IActionResult PurchasePremium([FromBody] PurchasePremiumRequest request)
        {
            try
            {
                int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
                _playerService.PurchasePremium(userId, request);
                return NoContent();
            }
            catch (NotAllowedException ex) 
            {
                return BadRequest(ex.Message);
            }
            
        }

        
    }
}
