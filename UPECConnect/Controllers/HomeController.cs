using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Web;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using UPECConnect.Data.Models;
using Microsoft.AspNetCore.Identity;
using UPECConnect.Data;
using UPECConnect.Models;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.IO;

namespace UPECConnect.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<IdentityUser> _userManager;

        private readonly IConfiguration _configuration;

        private readonly SignInManager<IdentityUser> _signInManager;

        public HomeController(UserManager<IdentityUser> userManager, ApplicationDbContext context, IConfiguration configuration, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _context = context;
            _configuration = configuration;
            _signInManager = signInManager;
        }
        public async Task<IActionResult> Index()
        {
            if (!_signInManager.IsSignedIn(User))
            {
                return LocalRedirect(Url.Content("~/Identity/Account/Login"));
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);
            var claimValue = User.Claims.Where(c => c.Type == Claims.Empresa).Select(c => c.Value).SingleOrDefault();
            string conn = _configuration.GetConnectionString("DefaultConnection");
            if (claimValue  == "0")
            {
                var empresaId = UserEmpresa.GetEmpresas(user.Id, conn).FirstOrDefault().ToString();
                if(empresaId != null && empresaId != "0")
                {
                    var claim = User.Claims.Where(c => c.Type == Claims.Empresa).Select(c => c).SingleOrDefault();
                    await _userManager.RemoveClaimAsync(user, claim);
                    await _userManager.AddClaimAsync(user, new Claim(Claims.Empresa, empresaId));
                    await _signInManager.RefreshSignInAsync(user);
                    return RedirectToAction(nameof(Index));
                }
            }
            if (claimValue != "0" && claimValue != null && UserEmpresa.GetEmpresas(userId, conn).Contains(int.Parse(claimValue))) ViewBag.empresa = Empresa.GetEmpresaById(int.Parse(claimValue), conn);

            if(UserEmpresa.GetEmpresas(userId, conn).Count() > 1) ViewBag.link = true;
            else ViewBag.link = false;

            ViewBag.Logs = _context.Logs.Where(x => x.EmpresaId == int.Parse(claimValue)).ToList();

            ViewBag.ArtGraf = GetGrafico("Artigo", int.Parse(claimValue));

            ViewBag.CliGraf = GetGrafico("Cliente", int.Parse(claimValue));

            ViewBag.EncGraf = GetGrafico("Encomenda", int.Parse(claimValue));

            return View();
        }

        public class Grafico
        {
            public string Data { get; set; }
            public int Quantidade { get; set; }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public List<Grafico> GetGrafico(string sincronizado, int empresa)
        {
            List<Grafico> Dados = new List<Grafico>();
            for (int i = 9; i >= 0; i--)
            {
                DateTime data = DateTime.Today.AddDays(-i);
                var temp = new Grafico()
                {
                    Data = data.ToShortDateString(),
                    Quantidade = _context.Logs.Where(c => c.Data.Date == data.Date && c.Sincronizado == sincronizado && c.EmpresaId == empresa && !c.Descricao.StartsWith("Erro!")).ToList().Count()
                };
                Dados.Add(temp);
            }
            return Dados;
        }
    }
}