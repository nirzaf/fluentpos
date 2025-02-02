﻿using FluentPOS.Modules.Identity.Core.Entities;
using FluentPOS.Modules.Identity.Infrastructure.Extensions;
using FluentPOS.Shared.Core.Domain;
using FluentPOS.Shared.Core.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using FluentPOS.Shared.Core.Interfaces;

namespace FluentPOS.Modules.Identity.Infrastructure.Persistence
{
    public class IdentityDbContext : IdentityDbContext<FluentUser, FluentRole, string, IdentityUserClaim<string>, IdentityUserRole<string>, IdentityUserLogin<string>, FluentRoleClaim, IdentityUserToken<string>>,
        IExtendedAttributeDbContext<string, FluentUser, UserExtendedAttribute>,
        IExtendedAttributeDbContext<string, FluentRole, RoleExtendedAttribute>
    {
        private readonly PersistenceSettings _persistenceOptions;

        protected string Schema => "Identity";

        public IdentityDbContext(DbContextOptions<IdentityDbContext> options, IOptions<PersistenceSettings> persistenceOptions) : base(options)
        {
            _persistenceOptions = persistenceOptions.Value;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(Schema);
            modelBuilder.Ignore<Event>();
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            modelBuilder.ApplyIdentityConfiguration(_persistenceOptions);
        }

        DbSet<FluentUser> IExtendedAttributeDbContext<string, FluentUser, UserExtendedAttribute>.GetEntities() => Users;
        DbSet<UserExtendedAttribute> IExtendedAttributeDbContext<string, FluentUser, UserExtendedAttribute>.ExtendedAttributes { get; set; }
        DbSet<FluentRole> IExtendedAttributeDbContext<string, FluentRole, RoleExtendedAttribute>.GetEntities() => Roles;
        DbSet<RoleExtendedAttribute> IExtendedAttributeDbContext<string, FluentRole, RoleExtendedAttribute>.ExtendedAttributes { get; set; }
    }
}