using Application.Models;
using Application.Models.Requests;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPlayerService
    {
        List<PlayerDto> GetAll();
        PlayerDto? GetById(int id);
        PlayerDto? GetByUsername(string username);
        PlayerDto Create(PlayerCreateRequest request);
        void Update(int id, PlayerUpdateRequest request, int userId);
        void Delete(int id, int userId);
        void PurchasePremium(int userId, PurchasePremiumRequest request);


    }
}