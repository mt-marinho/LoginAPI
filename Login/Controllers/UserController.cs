﻿using Microsoft.EntityFrameworkCore;
using Login.Models;
using Microsoft.AspNetCore.Mvc;
using Login.Data;

namespace Login.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UserController(AppDbContext context)
        {
            _context = context;
        }

    }
}
