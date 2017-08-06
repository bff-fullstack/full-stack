using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using REST.models;
using System.Security.Cryptography;
using System.Text;
using System.Security;
using REST.Intefaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace REST.Controllers
{
    [Route("api/[controller]")]
    public class TokensController : Controller
    {
        RESTContext _RESTContext;
        public TokensController(RESTContext dbContext){
            _RESTContext=dbContext;
        }
    [HttpPost]
    public IActionResult Token( [FromBody]IToken model)
    {

        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
    
        var user = _RESTContext.Creds.FirstOrDefault(c => c.Client==model.Client && c.Key==Helper.OneWayHash( model.Key));

        if (user == null)
        {
            return BadRequest();
        }
    
        var token = GetJwtSecurityToken(user);
      
        JwtSecurityTokenHandler handler =new JwtSecurityTokenHandler();
        string tokenString = handler.WriteToken(token);
        return Ok(new
        {
            token = tokenString,
            expiration = token.ValidTo
        });
    }

        private JwtSecurityToken GetJwtSecurityToken(Creds user)
        {
        var userClaims =  GetTokenClaims(user);
    
            return new JwtSecurityToken(
                issuer: "test.com",
            
                audience: "test.com",
                claims: userClaims,
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ASSPJDFNNJF{IUSNF{UINSDF{SFNNF{")), SecurityAlgorithms.HmacSha256)
               
            );
        }
        private static IEnumerable<Claim> GetTokenClaims(Creds user)
        {
            string privileges;

            if (user.Privilege==1)
                privileges="ADMIN";
            else
                privileges="USER";

            return new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.Client),
                new Claim("prv", privileges),
                new Claim("nbf",System.DateTime.UtcNow.ToString())
            };
        }
    }
}