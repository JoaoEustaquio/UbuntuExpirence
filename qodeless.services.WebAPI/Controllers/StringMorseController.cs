using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using qodeless.application;
using qodeless.application.ViewModels;
using qodeless.domain.Enums;
using qodeless.domain.Enums.Model;
using qodeless.Infra.CrossCutting.Identity.Data;
using qodeless.services.WebApi.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace qodeless.services.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StringMorseController 
    {
        [HttpPost("StringMorseController")]
        public string ReceiveMessage(MessageViewModel vm)
        {
            var message = vm.Name;

            return message;
        }
    }    
}