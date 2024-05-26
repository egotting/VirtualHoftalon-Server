﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VirtualHoftalon_Server.Models.Dto.Administrator;
using VirtualHoftalon_Server.Services.Interfaces;

namespace VirtualHoftalon_Server.Controller;

public class AdministratorController : Microsoft.AspNetCore.Mvc.Controller
{

    private readonly IAdministratorService _service;

    public AdministratorController(IAdministratorService service)
    {
        _service = service;
    }

    [HttpGet]
    [Authorize(Roles = ("ADMIN"))]
    [Route("/admins")]
    public IActionResult GetAll()
    {
        return Ok(_service.GetAll());
    }
    
    
    // Proteger para apenas IPs especifos utilizar esse endpoint
    [HttpPost]
    [Route("/admins")]
    public IActionResult Create([FromBody] AdministratorRequestDTO dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(_service.Save(dto));
    }
}