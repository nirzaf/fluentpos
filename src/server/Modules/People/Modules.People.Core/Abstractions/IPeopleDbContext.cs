﻿using FluentPOS.Modules.People.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FluentPOS.Modules.People.Core.Abstractions
{
    public interface IPeopleDbContext
    {
        public DbSet<Customer> Customers { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}