using Application.Interfaces;
using Application.Models.Requests;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;


namespace Infrastructure.Services
{
    public class AuthenticationService : IAuthenticationService
    {

        private readonly IPlayerRepository _playerRepository;
        private readonly AutenticacionServiceOptions _options;

        public AuthenticationService(IPlayerRepository playerRepository, IOptions<AutenticacionServiceOptions> options)
        {
            _playerRepository = playerRepository;
            _options = options.Value;
        }

        public string Autenticar(AuthenticationRequest authenticationRequest)
        {
            
            var user = ValidateUser(authenticationRequest); 

            if (user == null)
            {
                throw new NotAllowedException("User authentication failed");
            }


            
            var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_options.SecretForKey)); 

            var credentials = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

            
            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("sub", user.Id.ToString()));  
            claimsForToken.Add(new Claim("given_name", user.Firstname)); 
            claimsForToken.Add(new Claim("family_name", user.Lastname)); 
            claimsForToken.Add(new Claim("role", user.Role.ToString())); 

            var jwtSecurityToken = new JwtSecurityToken( 
              _options.Issuer,
              _options.Audience,
              claimsForToken,
              DateTime.UtcNow,
              DateTime.UtcNow.AddHours(1),
              credentials);

            var tokenToReturn = new JwtSecurityTokenHandler() 
                .WriteToken(jwtSecurityToken);

            return tokenToReturn.ToString();
        }

        private Player? ValidateUser(AuthenticationRequest authenticationRequest)
        {
            if (string.IsNullOrEmpty(authenticationRequest.Email) || string.IsNullOrEmpty(authenticationRequest.Password))
                return null;

            var user = _playerRepository.GetByEmail(authenticationRequest.Email);

            if (user == null) return null;

            
            if (user.Password == authenticationRequest.Password) return user;
            

            return null;

        }

        public class AutenticacionServiceOptions
        {
            public const string AutenticacionService = "AutenticacionService";

            public string Issuer { get; set; }
            public string Audience { get; set; }
            public string SecretForKey { get; set; }
        }
    }
}
