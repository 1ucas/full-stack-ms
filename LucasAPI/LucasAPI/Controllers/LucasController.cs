using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LucasAPI.Domain;
using LucasAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LucasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LucasController : ControllerBase
    {
        // POST api/values
        [HttpPost]
        public void Post([FromBody] Lucas lucas)
        {
            new LucasService().Criar(lucas);
        }
    }
}
