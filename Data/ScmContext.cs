using IdentityServer4.EntityFramework.Options;
using Scm.Domain;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using CargaDescarga;

namespace Scm.Data
{
    public class ScmContext : IdentityDbContext<AppUser,AppRole,string>
    {
        public DbSet<Empleado> Empleados {get;set;}
        public DbSet<RegistroVale> RegistroVales {get;set;}
        public DbSet<Vale> Vale {get;set;}
        public DbSet<Retenciones> Retenciones { get; set;}
        public ScmContext(DbContextOptions<ScmContext> options) : base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //put mappings database here
            builder.Entity<Empleado>(x=>{
                x.HasKey(x=>x.IdEmpleado);
                x.Property(x=>x.IdEmpleado).ValueGeneratedOnAdd();
                x.Property(x=>x.Nombre).HasMaxLength(200).IsRequired();
            });
            builder.Entity<RegistroVale>(x=>{
                x.HasKey(x=>x.IdRegistroVale);
                x.Property(x=>x.IdRegistroVale).ValueGeneratedOnAdd();
                x.HasOne(x=>x.Empleado).WithMany().HasForeignKey(x=>x.idEmpleado);
                x.HasOne(x=>x.Usuario).WithMany().HasForeignKey(x=>x.UsuarioId);
                x.HasMany(x=>x.Vales);
                
            });
            builder.Entity<Vale>(x=>{
                x.HasKey(x=>x.FolioVale);
                x.Property(x=>x.FolioVale).ValueGeneratedOnAdd();
                x.Property(x=>x.FechaExpedicionVale).IsRequired();
                
            });
            builder.Entity<Retenciones>(x=>{
                x.HasKey(x=>x.Key);
                
            });
            base.OnModelCreating(builder);
        }
    }
}