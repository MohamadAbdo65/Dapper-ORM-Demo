using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORMProject
{
    public static class ConnectionSettings
    {
        private static IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        public static string? ConnectionString = configuration.GetSection("constr").Value;
    }
}
