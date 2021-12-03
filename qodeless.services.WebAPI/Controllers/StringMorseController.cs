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
    [HttpGet]
    public IActionResult Message()
    {

    }

    [HttpPost]
    public IActionResult Morse()
    {
        var Morse = 
    }
}