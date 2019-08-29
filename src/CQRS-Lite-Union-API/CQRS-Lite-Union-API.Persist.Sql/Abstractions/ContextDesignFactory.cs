using CQRS_Lite_Union_API.Common.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CQRS_Lite_Union_API.Persist.Sql.Abstractions
{
    public abstract class ContextDesignFactory<T> : IDesignTimeDbContextFactory<T> where T : DbContext
    {
        private const string AspNetCoreEnvironment = "ASPNETCORE_ENVIRONMENT";

        public T CreateDbContext(string[] args)
        {
            var basePath = Directory.GetCurrentDirectory() + string.Format("{0}..{0}CQRS-Lite-Union-API.WebApi", Path.DirectorySeparatorChar);
            return Create(basePath, Environment.GetEnvironmentVariable(AspNetCoreEnvironment));
        }

        protected abstract T CreateNewInstance(IOptions<ConnectionStrings> options);

        private T Create(string basePath, string environmentName)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environmentName}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var connectionString = configuration.GetValue<string>("ConnectionStrings:CQRSLiteUnionDb");
            var section = new ConnectionStrings() { CQRSLiteUnionDb = connectionString };

            return Create(section);
        }

        private T Create(ConnectionStrings section)
        {
            if (string.IsNullOrEmpty(section.CQRSLiteUnionDb)) throw new ArgumentException($"Connection string '{section.CQRSLiteUnionDb}' is null or empty.", nameof(section.CQRSLiteUnionDb));

            var options = Options.Create(section);
            return CreateNewInstance(options);
        }
    }
}
