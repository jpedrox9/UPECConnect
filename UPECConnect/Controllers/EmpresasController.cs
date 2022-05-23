using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using UPECConnect.Data;
using UPECConnect.Data.Models;

namespace UPECConnect.Controllers
{
    public class EmpresasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;

        public EmpresasController(UserManager<IdentityUser> userManager, ApplicationDbContext context, IConfiguration configuration, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _configuration = configuration;
        }

        // GET: Empresas
        public ActionResult Index()
        {
            string conn = _configuration.GetConnectionString("DefaultConnection");
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var empresas = UserEmpresa.GetEmpresas(userId, conn);
            ViewBag.Acessos = UserEmpresa.Listar(empresas, conn);
            return View();
        }

        // GET: Empresas/Details/id
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await _context.Empresas.FindAsync(id);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var acesso = await _context.UsersEmpresas.Where(x => x.EmpresaId == id && x.UserId == userId).FirstOrDefaultAsync();
            if (empresa == null || acesso == null)
            {
                return NotFound();
            }

            return View(empresa);
        }

        // GET: Empresas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Empresas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Sigla,Nome,Password")] Empresa empresa, string ConfirmPassword)
        {
            if (ModelState.IsValid && empresa.Password == ConfirmPassword)
            {
                empresa.Password = GetHash(empresa.Password);
                _context.Add(empresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empresa);
        }

        // GET: Empresas/Edit/id
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var empresa = await _context.Empresas.FindAsync(id);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var acesso = await _context.UsersEmpresas.Where(x => x.EmpresaId == id && x.UserId == userId).FirstOrDefaultAsync();
            if (empresa == null || acesso == null)
            {
                return NotFound();
            }
            return View(empresa);
        }

        // POST: Empresas/Edit/id
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Sigla,Nome,Password")] Empresa empresa)
        {
            if (id != empresa.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empresa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpresaExists(empresa.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(empresa);
        }

        // GET: Empresas/Password/id
        public IActionResult Password(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewBag.sucesso = 0;
            return View();
        }

        // POST: Empresas/Password/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Password(int id, string oldPass, string newPass1, string newPass2)
        {
            var empresa = await _context.Empresas.FindAsync(id);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var acesso = await _context.UsersEmpresas.Where(x => x.EmpresaId == id && x.UserId == userId).FirstOrDefaultAsync();
            if (empresa == null || acesso == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid && GetHash(oldPass) == empresa.Password && newPass1 == newPass2 && newPass1 != oldPass)
            {
                empresa.Password = GetHash(newPass1);
                _context.Update(empresa);
                await _context.SaveChangesAsync();
                ViewBag.sucesso = 1;
                return View();
            }
            ViewBag.sucesso = 2;
            return View();
        }

        // GET: Empresas/Delete/id
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await _context.Empresas.FindAsync(id);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var acesso = await _context.UsersEmpresas.Where(x => x.EmpresaId == id && x.UserId == userId).FirstOrDefaultAsync();
            if (empresa == null || acesso == null)
            {
                return NotFound();
            }

            return View(empresa);
        }

        // POST: Empresas/Delete/id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empresa = await _context.Empresas.FindAsync(id);
            _context.Empresas.Remove(empresa);
            var ligacao = _context.UsersEmpresas.Where(x => x.EmpresaId == id).Select(x => x).SingleOrDefault();
            if(ligacao != null) _context.UsersEmpresas.Remove(ligacao);
            var config = await _context.Config.FindAsync(id);
            if(config != null) _context.Config.Remove(config);
            var claim = _context.UserClaims.Where(x => x.ClaimValue == id.ToString()).Select(x => x).SingleOrDefault();
            if (claim != null)
            {
                string conn = _configuration.GetConnectionString("DefaultConnection");
                var user = await _userManager.FindByEmailAsync(_userManager.GetUserName(User));
                var claims = User.Claims.Where(c => c.Type == Claims.Empresa).Select(c => c).SingleOrDefault();
                var empresaId = UserEmpresa.GetEmpresas(user.Id, conn).FirstOrDefault().ToString();
                await _userManager.RemoveClaimAsync(user, claims);
                await _userManager.AddClaimAsync(user, new Claim(Claims.Empresa, empresaId.ToString()));
                await _signInManager.RefreshSignInAsync(user);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpresaExists(int id)
        {
            return _context.Empresas.Any(e => e.Id == id);
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
