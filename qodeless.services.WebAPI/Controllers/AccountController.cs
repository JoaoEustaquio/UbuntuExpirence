using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using qodeless.application;
using qodeless.application.ViewModels;
using qodeless.domain.Enums;
using qodeless.domain.Enums.Model;
using qodeless.Infra.CrossCutting.Identity.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace qodeless.services.WebAPI.Controllers
{
    /// <summary>
    ///  Account
    /// </summary>
    [EnableCors("CorsApi")]
    [Route("api/[controller]")]
    //[Authorize]
    public class AccountController : ApiController
    {
        private readonly IAccountAppService _AccountAppService;

        /// <summary>
        ///  Account
        /// </summary>
        /// <param name="db"></param>
        public AccountController(ApplicationDbContext db, IAccountAppService AccountAppService)
            : base(db)
        {
            _AccountAppService = AccountAppService;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return CustomResponse(await _AccountAppService.Remove(id));
        }
        /// <summary>
        /// Adicionar Account
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AccountViewModel vm)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _AccountAppService.Add(vm));
        }

        /// <summary>
        /// Retorna Account por ID
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<AccountViewModel> GetById(Guid id)
        {
            return await _AccountAppService.GetById(id);
        }

        /// <summary>
        /// Retorna lista de Accounts
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<AccountViewModel>> GetAccounts()
        {
            return await _AccountAppService.GetAll();
        }
    }
}