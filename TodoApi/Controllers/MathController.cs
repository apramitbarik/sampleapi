using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MathController: ControllerBase
    {
        [HttpGet("{value1}/{value2}")]
        public int Add(int value1, int value2)
        {
            return value1 + value2;
        }

        [HttpGet]
        public string Get()
        {
            return "default";
        }
    }
}
