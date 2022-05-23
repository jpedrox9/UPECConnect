using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UPECConnect.Data.Models;
using UPECConnect.Data;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Data.Entity.Infrastructure;
using System.Net.Http;
using System.Text.Json;
using Microsoft.Net.Http.Headers;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.Web;

namespace UPECConnect.Controllers
{
    public class ConfigController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;

        public ConfigController(UserManager<IdentityUser> userManager, ApplicationDbContext context, IConfiguration configuration, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            string conn = _configuration.GetConnectionString("DefaultConnection");
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var empresas = UserEmpresa.GetEmpresas(userId, conn);
            ViewBag.empresas = UserEmpresa.Listar(empresas, conn);
            ViewBag.conn = conn;
            return View();
        }

        // GET: Config/Create/id
        public async Task<IActionResult> Create(int? id)
        {
            var config = await _context.Config.FindAsync(id);
            if(id == null || config != null)
            {
                return NotFound();
            }
            config = new Config() { Empresa = (int)id };
            return View(config);
        }

        // POST: Config/Create/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, [Bind("TempoArranque,Images_Path,Logs_Path,URL,Token,Servidor,BaseDados,Utilizador,WebService,TipoDoc,Serie,Setor")] Config dados, string Pass1, string Pass2)
        {
            if (ModelState.IsValid && Pass1 == Pass2)
            {
                dados.Empresa = id;
                dados.Password = Pass1;
                _context.Add(dados);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dados);
        }

        // GET: Config/Edit/id
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var config = await _context.Config.FindAsync(id);
            if (config == null)
            {
                return NotFound();
            }

            return View(config);
        }

        // POST: Config/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TempoArranque,Images_Path,Logs_Path,URL,Token,Servidor,BaseDados,Utilizador,WebService,TipoDoc,Serie,Setor")] Config dados)
        {
            if (ModelState.IsValid)
            {
                dados.Empresa = id;
                dados.Password = _context.Config.Where(x => x.Empresa == id).Select(x => x.Password).FirstOrDefault();
                _context.Update(dados);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dados);
        }

        // GET: Config/Password/id
        public ActionResult Password(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewBag.sucesso = 0;
            return View();
        }

        // POST: Config/Password/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Password(int id, string oldPass, string newPass1, string newPass2)
        {
            var dados = _context.Config.Where(x => x.Empresa == id).SingleOrDefault();

            if (dados == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid && oldPass == dados.Password && newPass1 == newPass2 && newPass1 != oldPass)
            {
                dados.Password = newPass1;
                _context.Update(dados);
                await _context.SaveChangesAsync();
                ViewBag.sucesso = 1;
                return View();
            }
            ViewBag.sucesso = 2;
            return View();
        }

        public FileResult Download(int id)
        {
            byte[] config = new UTF8Encoding(true).GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(Config.Converter(GetConfig(id)), Newtonsoft.Json.Formatting.Indented));
            return File(config, "text/plain" ,"config.json");
        }

        [HttpPost]
        public async Task<IActionResult> Upload(int id, IFormFile config)
        {
            if (config == null || config.Length == 0)
            {
                return Content("File not selected");
            }

            var json = await ReadFormFileAsync(config);
            var sConfig = Config.Converter(Newtonsoft.Json.JsonConvert.DeserializeObject<UPECConnectService.ConfigApp>(json));
            sConfig.Empresa = id;
            if((await _context.Config.FindAsync(id)) != null) return View("Edit", sConfig);
            return View("Create", sConfig);
        }

        public FileResult Template(int id)
        {
            byte[] config = new UTF8Encoding(true).GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(Config.Converter(new Config { Empresa = id })));
            return File(config, "text/plain", "config.json");
        }

        public Config GetConfig(int empresa)
        {
            return _context.Config.Where(x => x.Empresa == empresa).SingleOrDefault();
        }

        private bool EmpresaExists(int id)
        {
            return _context.Config.Any(e => e.Empresa == id);
        }
        public static async Task<string> ReadFormFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return await Task.FromResult((string)null);
            }

            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                return await reader.ReadToEndAsync();
            }
        }
    }
}
