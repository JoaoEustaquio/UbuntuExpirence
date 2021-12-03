﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using qodeless.Infra.CrossCutting.Identity.Entities;
using qodeless.Infra.CrossCutting.Identity.Entities.AccountViewModels;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using qodeless.Infra.CrossCutting.Identity.Data;
using qodeless.domain.Entities;

namespace qodeless.services.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ApiController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JWTSetup _jwtSetup;


        public AuthController(
            ApplicationDbContext db,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IOptions<JWTSetup> jwtSetup
            ) : base(db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSetup = jwtSetup.Value;
        }

        /// <summary>
        /// Autentica usuário e gera o token JWT
        /// </summary>
        /// <param name="vm">
        /// LoginViewModel:
        /// Email, Password
        /// </param>
        /// <returns>Token JWT</returns>
        [HttpPost("token")]
        public async Task<IActionResult> SignIn([FromBody] LoginViewModel vm)
        {
            if (!ModelState.IsValid) return ModelStateError();

            var result = await _signInManager.PasswordSignInAsync(vm.Email, vm.Password, false, true);

            if (result.Succeeded)
            {
                var user = GetUser(vm.Email);

                if (user == null)
                {
                    return Response(success: false, errorMessage: "invalid User");
                }

                var token = await GenerateJWTToken(user);
                return Response(
                    new
                    {
                        token = token,
                        user = user
                    }
                );
            }

            return Response(success: false, errorMessage: "invalid user or password");
        }

        private async Task<string> GenerateJWTToken(IUserDataModel user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSetup.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim(ClaimTypes.Role, user.Role),
                }),

                Issuer = _jwtSetup.Emiter,
                Audience = _jwtSetup.ValidOn,
                Expires = DateTime.UtcNow.AddHours(_jwtSetup.Duration),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var claims = GetDefaultClaims(user.RoleId,user);
            if (claims != null)
            {
                foreach (var claim in claims)
                {
                    tokenDescriptor.Subject.AddClaim(new Claim(claim.ClaimType, claim.ClaimValue));
                }
            }
            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }
    }
}
