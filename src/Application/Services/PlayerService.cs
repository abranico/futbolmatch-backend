using Application.Interfaces;
using Application.Models.Requests;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }
        public List<Player> GetAll()
        {
            return _playerRepository.GetAll();
        }

        public Player? GetById(int id)
        {
            var player = _playerRepository.GetById(id) ?? throw new NotFoundException($"Player {id} not found");
            return player;
        }
        public Player? GetByUsername(string username)
        {
            var player = _playerRepository.GetByUsername(username) ?? throw new NotFoundException($"Player {username} not found");
            return player;
        }

        public Player Create(PlayerCreateRequest request)
        {
            Player player = new Player();

            player.Email = request.Email;
            player.Username = request.Username;
            player.Firstname = request.Firstname;
            player.Lastname = request.Lastname;
            player.Password = request.Password;
            player.Country = request.Country;
            player.City = request.City;
            player.DateOfBirth = request.DateOfBirth;
            player.Gender = request.Gender;
            player.Role = request.Role;

            return _playerRepository.Create(player);

        }

        public void Update(int id, PlayerUpdateRequest request, int userId)
        {
            var player = _playerRepository.GetById(id) ?? throw new NotFoundException($"Player {id} not found");
            if(player.Id != userId) throw new InvalidOperationException("Acceso denegado.");

            player.Email = request.Email ?? player.Email;
            player.Username = request.Username ?? player.Username;
            player.Firstname = request.Firstname ?? player.Firstname;
            player.Lastname = request.Lastname ?? player.Lastname;
            player.Password = request.Password ?? player.Password;
            player.Country = request.Country ?? player.Country;
            player.City = request.City ?? player.City;
            player.DateOfBirth = request.DateOfBirth ?? player.DateOfBirth;
            player.Gender = request.Gender ?? player.Gender;
            player.Description = request.Description ?? player.Description;
            player.PreferredFoot = request.PreferredFoot ?? player.PreferredFoot;
            player.Position = request.Position ?? player.Position;

            _playerRepository.Update(player);

        }

        public void Delete(int id, int userId)
        {
            var player = _playerRepository.GetById(id) ?? throw new NotFoundException($"Player {id} not found");
            if (player.Id != userId) throw new InvalidOperationException("Acceso denegado.");
            _playerRepository.Delete(player);
        }

        

    }
}