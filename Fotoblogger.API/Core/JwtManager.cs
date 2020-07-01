using Fotoblogger.EfDataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Fotoblogger.API.Core
{
    public class JwtManager
    {
        private readonly FotobloggerContext _context;
        private readonly string _issuer;
        private readonly string _secretKey;

        public JwtManager(FotobloggerContext context, string issuer, string secretKey)
        {
            _context = context;
            _issuer = issuer;
            _secretKey = secretKey;
        }

        public string MakeToken(string username, string password)
        {
            var user = _context.Users.Include(u => u.Role).ThenInclude(r => r.RoleUseCases).ThenInclude(ruc => ruc.UseCase)
                .Include(u => u.UseCases).ThenInclude(ruc => ruc.UseCase)
                .FirstOrDefault(u => !u.IsDeleted && u.IsActive && u.Username == username && u.Password == password);

            if (user == null)
                return null;

            var actor = new JwtActor
            {
                Id = user.Id,
                Identity = user.Username,
                RoleType = user.Role.RoleType,
                AllowedUseCases = user.getAllowedUseCasesIds()
            };

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString(), ClaimValueTypes.String, _issuer),
                new Claim(JwtRegisteredClaimNames.Iss, _issuer, ClaimValueTypes.String, _issuer),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.String, _issuer),
                new Claim("UserId", actor.Id.ToString(), ClaimValueTypes.String, _issuer),
                new Claim("ActorData", JsonConvert.SerializeObject(actor), ClaimValueTypes.String, _issuer)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var now = DateTime.Now;
            var token = new JwtSecurityToken(
                    issuer: _issuer,
                    audience: "Any",
                    claims: claims,
                    notBefore: now,
                    expires: now.AddMinutes(30),
                    signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
