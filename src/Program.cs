using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Steeltoe.Common;
using Steeltoe.Extensions.Configuration.Kubernetes;
using Steeltoe.Extensions.Logging;
using k8s;
using k8sConfigs.Util;

namespace k8sConfigs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureHostConfiguration(configbuilder=> {
                    configbuilder.AddJsonFile("appsettings.json");
                    configbuilder.AddEnvironmentVariables();

                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
           
                .ConfigureAppConfiguration((context, builder) =>
                {

                    builder.AddKubernetes(k8sConfig => {
                        k8sConfig = ConfigUtils.GetKubernetesClientConfiguration(
                            context.Configuration["AppRunIn"].ToLower());
                       
                    });                   
                })
                .ConfigureLogging((builderContext, loggingBuilder) =>
                {
                    loggingBuilder.AddDynamicConsole();
                })
                .AddKubernetesConfiguration();
    }
}