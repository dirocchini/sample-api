using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Shared.Support.ClassExtensions
{
    public static class ConfigurationsExtensions
    {
        public static IConfigurationBuilder ConfigureDefaultJson()
        {
            return new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        }
    }
}
