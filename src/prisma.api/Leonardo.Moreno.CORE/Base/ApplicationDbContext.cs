﻿using Microsoft.EntityFrameworkCore;
using System;

namespace Leonardo.Moreno.CORE.Base
{
    public abstract class ApplicationDbContext : DbContext, IDisposable
    {
        protected const string SCHEMA_NAME = "Auth";

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            //Rename Identity tables
            //builder.Entity<ApplicationUser>().ToTable("Users", SCHEMA_NAME);
            //builder.Entity<ApplicationRole>().ToTable("Roles", SCHEMA_NAME);
            //builder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaims", SCHEMA_NAME);
            //builder.Entity<IdentityUserClaim<int>>().ToTable("UserClaims", SCHEMA_NAME);
            //builder.Entity<IdentityUserRole<int>>().ToTable("UserRoles", SCHEMA_NAME).HasKey(key => new { key.UserId, key.RoleId });
            //builder.Entity<IdentityUserLogin<int>>().ToTable("UserLogins", SCHEMA_NAME).HasKey(key => new { key.ProviderKey, key.LoginProvider });
            //builder.Entity<IdentityUserToken<int>>().ToTable("UserTokens", SCHEMA_NAME).HasKey(key => new { key.UserId, key.LoginProvider, key.Name });
        }
    }
}
