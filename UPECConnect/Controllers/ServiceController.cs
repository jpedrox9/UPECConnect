using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UPECConnect.Data;
using UPECConnect.Data.Models;

namespace UPECConnect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public ServiceController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpGet]
        public string Get(int id)
        {
            string conn = _configuration.GetConnectionString("DefaultConnection");
            string config = Newtonsoft.Json.JsonConvert.SerializeObject(Config.GetConfig(id, conn));
            return config;
        }

        [HttpPost]
        public IActionResult Post(Logs log)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            _context.Logs.Add(new Logs()
            {
                EmpresaId = log.EmpresaId,
                Sincronizado = log.Sincronizado,
                Codigo_BD = log.Codigo_BD,
                Codigo_Site = log.Codigo_Site,
                Data = log.Data,
                Descricao = log.Descricao,
            });
            _context.SaveChanges();

            return Ok();
        }
    }
}
