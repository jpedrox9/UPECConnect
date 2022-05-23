using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UPECConnect.Data.Models;

namespace UPECConnect.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Empresa> Empresas { get; set; }

        public DbSet<UserEmpresa> UsersEmpresas { get; set; }

        public DbSet<Logs> Logs { get; set; }

        public DbSet<Config> Config { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
