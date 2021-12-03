using jll.portal_api.services.WebAPI.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using qodeless.Infra.CrossCutting.Identity.Data;
using qodeless.Infra.CrossCutting.Identity.Entities;
using qodeless.services.WebApi.Model;
using qodeless.services.WebAPI.Controllers;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace qodeless.services.WebApi.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class RegisterAccountController : ApiController
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private IServiceProvider serviceProvider;

        public RegisterAccountController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager,ApplicationDbContext db) : base(db)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        /// <summary>
        /// Adicionar Role apenas Teste
        /// </summary>
        /// <returns></returns>
        [HttpPost("AddRole")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = Policy.DEVELOPER_CREATE)]
        //[Authorize(Roles = Role.DEVELOPER)]
        public async Task<IActionResult> AddRole([FromBody] RoleViewModel vm)
        {
            //cria role (aspnetroles)
            var result = await _roleManager.CreateAsync(new IdentityRole(vm.Role));

            if (result.Succeeded)
            {
                //procura role por nome
                var role = await _roleManager.FindByNameAsync(vm.Role);
                //vincula claims no role (aspnetrolesclaims)
                if (vm.Claims.Count > 0)
                {
                    foreach (var claim in vm.Claims)
                    {
                        await _roleManager.AddClaimAsync(role, new Claim(claim.ClaimType, claim.ClaimValue));
                    }
                }

                return Response(true);
            }
            return Response(false);
        }
        /// <summary>
        /// Adicionar Usuário
        /// </summary>
        /// <returns></returns>
        [HttpPost("AddUser")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = Policy.REGISTER_USER)]
        //[Authorize(Roles = Role.MANAGER)]
        public async Task<IActionResult> AddUser([FromBody] RegisterViewModel vm)
        {


            var user = new ApplicationUser
            {
                UserName = vm.Email,
                Email = vm.Email,
                Enabled = true,
            };
            //cria usuario no banco (aspnetuser)
            var result = await _userManager.CreateAsync(user, vm.Password);

            if (result.Succeeded)
            {
                // User claim for write customers data

                //relaciona role existente com o usuario criado (aspnetuserroles)
                if (vm.Role.IsValidRole())
                {
                    if (!_roleManager.RoleExistsAsync(vm.Role).Result)
                    {
                        var roleResult = await _roleManager.CreateAsync(new IdentityRole(vm.Role.ToLower()));
                    }
                }
                await _userManager.AddToRoleAsync(user, vm.Role);
                //relaciona claim com usuario (aspnetuserclaims)
                if (vm.Claims != null)
                {
                    if (vm.Claims.Count > 0)
                    {
                        foreach (var claim in vm.Claims)
                        {
                            await _userManager.AddClaimAsync(user, new Claim(claim.ClaimType, claim.ClaimValue));
                        }
                    }
                }

                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                return Response(true);
            }
            return Response(false);
        }
    }
}
