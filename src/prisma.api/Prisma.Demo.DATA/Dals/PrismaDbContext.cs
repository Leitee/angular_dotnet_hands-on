using Leonardo.Moreno.CORE.Base;
using Leonardo.Moreno.CORE.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Prisma.Demo.MODEL.Entity;
using System;

namespace Prisma.Demo.DATA.Dals
{
    public class PrismaDbContext : ApplicationDbContext
    {
        protected readonly AppSettings _appSettings;//TODO: to see...

        public PrismaDbContext(IConfiguration config, DbContextOptions options, bool isTestInstance = false) : base(options)
        {
            if (!isTestInstance)
                _appSettings = AppSettings.GetSettings(config ?? throw new ArgumentNullException(nameof(config)));
        }

        public DbSet<Competidor> Competidores { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<ZonaDePrecio> ZonasDePrecio { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //If you want to apply and avoid to include each entity manually
            //optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
            optionsBuilder.EnableDetailedErrors(!_appSettings.IsProdMode);
            optionsBuilder.EnableSensitiveDataLogging(!_appSettings.IsProdMode);
            optionsBuilder.UseSqlServer(_appSettings.ConnectionString, options =>
            {
                options.MigrationsHistoryTable("Migrations", "EFConfig");
            });
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Marca>().HasData(
               new Marca { Id = 1, Codigo = "marca_codigo1", Nombre = "marca_nombre1" },
               new Marca { Id = 2, Codigo = "marca_codigo2", Nombre = "marca_nombre2" },
               new Marca { Id = 3, Codigo = "marca_codigo3", Nombre = "marca_nombre3" }
               );

            builder.Entity<ZonaDePrecio>().HasData(
               new ZonaDePrecio { Id = 1, Codigo = "zona_codigo1", Nombre = "zona_nombre1" },
               new ZonaDePrecio { Id = 2, Codigo = "zona_codigo2", Nombre = "zona_nombre2" },
               new ZonaDePrecio { Id = 3, Codigo = "zona_codigo3", Nombre = "zona_nombre3" }
               );

            builder.Entity<Competidor>().HasData(
                new Competidor { Id = 1, Codigo = "codigo1", Nombre = "nombre1", Calle = "calle1", MarcaId = 1, ZonaDePrecioId = 1 },
                new Competidor { Id = 2, Codigo = "codigo2", Nombre = "nombre2", Calle = "calle2", MarcaId = 2, ZonaDePrecioId = 2 },
                new Competidor { Id = 3, Codigo = "codigo3", Nombre = "nombre3", Calle = "calle3", MarcaId = 3, ZonaDePrecioId = 3 }
                );
        }
    }
}