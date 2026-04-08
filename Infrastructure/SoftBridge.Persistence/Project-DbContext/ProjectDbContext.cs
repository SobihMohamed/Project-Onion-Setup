using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SoftBridge.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Persistence.Project_DbContext
{
    public class ProjectDbContext(DbContextOptions<ProjectDbContext> options)
            : IdentityDbContext<ApplicationUser>(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Apply all configurations from the assembly containing ApplicationUserConfig
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProjectDbContext).Assembly);

            // Additional model configurations can be added here if needed
        }
    }
}
