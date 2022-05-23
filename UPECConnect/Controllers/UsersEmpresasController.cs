using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UPECConnect.Data;
using UPECConnect.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace UPECConnect.Controllers
{
    public class UsersEmpresasController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<IdentityUser> _userManager;

        private readonly IConfiguration _configuration;

        private readonly SignInManager<IdentityUser> _signInManager;

        public UsersEmpresasController(UserManager<IdentityUser> userManager, ApplicationDbContext context, IConfiguration configuration, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _context = context;
            _configuration = configuration;
            _signInManager = signInManager;
        }

        // GET: UsersEmpresas
        public ActionResult Index()
        {
            string conn = _configuration.GetConnectionString("DefaultConnection");
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var empresas = UserEmpresa.GetEmpresas(userId, conn);
            ViewBag.Acessos = UserEmpresa.Listar(empresas, conn);
            return View();
        }

        // GET: UsersEmpresas/Search
        public async Task<IActionResult> Search()
        {
            string conn = _configuration.GetConnectionString("DefaultConnection");
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewData["empresas"] = UserEmpresa.GetEmpresas(userId, conn);
            return View(await _context.Empresas.ToListAsync());
        }

        // POST: UsersEmpresas/Search
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Search(string? pesquisa)
        {
            string conn = _configuration.GetConnectionString("DefaultConnection");
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewData["empresas"] = UserEmpresa.GetEmpresas(userId, conn);
            if (pesquisa != null) return View(await _context.Empresas.Where(x => x.Nome != null && (x.Nome.ToLower().Contains(pesquisa.ToLower()) || x.Sigla.ToLower().Contains(pesquisa.ToLower()))).ToListAsync());
            return View(await _context.Empresas.ToListAsync());
        }

        // GET: UsersEmpresas/Create/id
        public async Task<IActionResult> Create(int? id)
        {
            if (id == null) return NotFound();

            return View(await _context.Empresas.FindAsync(id));
        }

        // POST: UsersEmpresas/Create/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, string Password)
        {
            var empresa = await _context.Empresas.FindAsync(id);
            string conn = _configuration.GetConnectionString("DefaultConnection");
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId != null && empresa.Password == GetHash(Password))
            {
                UserEmpresa.Save(id, userId, conn);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.erro = 1;
            return View();
        }

        // GET: UsersEmpresas/Delete/id
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            string conn = _configuration.GetConnectionString("DefaultConnection");
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var ligacao = await _context.UsersEmpresas.FirstOrDefaultAsync(x => x.EmpresaId == id && x.UserId == userId);
            if (ligacao == null)
            {
                return NotFound();
            }

            return View(await _context.Empresas.FindAsync(id));
        }

        // POST: UsersEmpresas/Delete/id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            string conn = _configuration.GetConnectionString("DefaultConnection");
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId != null)
            {
                UserEmpresa.Delete(id, userId, conn);
                var user = await _userManager.FindByIdAsync(userId);
                var claim = User.Claims.Where(c => c.Type == Claims.Empresa).Select(c => c).SingleOrDefault();
                await _userManager.RemoveClaimAsync(user, claim);
                await _userManager.AddClaimAsync(user, new Claim(Claims.Empresa, "0"));
                await _signInManager.RefreshSignInAsync(user);
            }
            return RedirectToAction(nameof(Index));
        }

        private static string GetHash(string input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] data = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                var sBuilder = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                return sBuilder.ToString();
            }
        }
    }
}
