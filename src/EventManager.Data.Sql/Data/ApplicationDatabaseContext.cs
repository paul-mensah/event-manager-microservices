﻿using EventManager.Core.Domain.EventInvitations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EventManager.Data.Sql.Data;

public class ApplicationDatabaseContext : DbContext
{
    public ApplicationDatabaseContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<EventInvitation> EventInvitations { get; set; }
}

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDatabaseContext>
{
    public ApplicationDatabaseContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, true)
            .Build();

        string connectionStrings = configuration.GetConnectionString("DbConnection");

        DbContextOptionsBuilder dbBuilder = new DbContextOptionsBuilder()
            .UseMySQL(connectionStrings);

        return new ApplicationDatabaseContext(dbBuilder.Options);
    }
}