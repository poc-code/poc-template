using Microsoft.IdentityModel.Tokens;
using Poc_Template_Api.Services.Interface;
using Poc_Template_Domain.Entities;
using Poc_Template_Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Poc_Template_Api.Services
{
    public class AcessoService : IAcessoService
    {
        private IAcessoRepository _repository;

        public AcessoService(IAcessoRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> BuscarAutorizacao(string nomeusuario, string senha)
        {
            var data = new Acesso { Username = nomeusuario, Password = senha };
            var result = await _repository.Autorizar(data);

            if (result is null)
                return string.Empty;

            if(result.Id > 0)
            {
                string adminJwtToken = GerarTokenJWT(new List<Claim> {
                     new Claim("enterprise", Guid.Empty.ToString()),
                     new Claim("scope", "api.full_access"),
                     new Claim(ClaimTypes.Email, result.Usuario.Email),
                     new Claim(ClaimTypes.Name, result.Usuario.Nome),
                     new Claim(ClaimTypes.Role, result.Perfil.Nome)
                });

                return adminJwtToken;
            }

            return string.Empty;
        }

        private static string GerarTokenJWT(IEnumerable<Claim> claims)
        {
            var issuer = "https://uira.com.br/sso";
            var audience = "api-rest";
            var key = Encoding.UTF8.GetBytes("only_test#Desta maneira, o desenvolvimento contínuo de distintas formas de atuação promove a alavancagem das condições inegavelmente apropriadas.#only_test");

            var expiry = DateTime.Now.AddMinutes(300);
            var securityKey = new SymmetricSecurityKey(key);
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer: issuer, 
                audience: audience,
                expires: expiry, 
                signingCredentials: credentials, 
                claims: claims);
            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }
    }
}
