using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UPECConnect.Data;
using UPECConnect.Data.Models;

namespace UPECConnect.Controllers
{
    public class AcessosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AcessosController(UserManager<IdentityUser> userManager, ApplicationDbContext context, IConfiguration configuration, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _configuration = configuration;
        }

        public ActionResult _acessosPartialView()
        {
            string conn = _configuration.GetConnectionString("DefaultConnection");
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var empresas = UserEmpresa.GetEmpresas(userId, conn);
            ViewBag.Acessos = UserEmpresa.Listar(empresas, conn);
            return PartialView("_acessosPartialView");
        }

        public async Task<IActionResult> Mudar(int empresaId)
        {
            string returnUrl = Url.Content("~/");
            string conn = _configuration.GetConnectionString("DefaultConnection");
            var user = await _userManager.FindByEmailAsync(_userManager.GetUserName(User));
            var claim = User.Claims.Where(c => c.Type == Claims.Empresa).Select(c => c).SingleOrDefault();
            await _userManager.RemoveClaimAsync(user, claim);
            await _userManager.AddClaimAsync(user, new Claim(Claims.Empresa, empresaId.ToString()));
            await _signInManager.RefreshSignInAsync(user);
            return LocalRedirect(returnUrl);
        }
    }
}
