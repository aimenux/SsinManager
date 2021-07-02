﻿using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using App.Commands;
using Lib.Helpers;
using Lib.Ssins;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace App
{
    public static class Program
    {
        public static Task Main(string[] args)
        {
            return CreateHostBuilder(args).RunCommandLineApplicationAsync<MainCommand>(args);
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((_, config) =>
                {
                    config.AddCommandLine(args);
                    config.AddEnvironmentVariables();
                    config.SetBasePath(GetDirectoryPath());
                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                })
                .ConfigureLogging((hostingContext, loggingBuilder) =>
                {
                    loggingBuilder.AddConsoleLogger();
                    loggingBuilder.AddNonGenericLogger();
                    loggingBuilder.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                })
                .ConfigureServices((hostingContext, services) =>
                {
                    services.AddTransient<MainCommand>();
                    services.AddTransient<ValidateCommand>();
                    services.AddTransient<GenerateCommand>();
                    services.AddTransient<ISsinSelector, SsinSelector>();
                    services.AddTransient<IRandomHelper, RandomHelper>();
                    services.AddTransient<IConsoleHelper, ConsoleHelper>();
                    services.AddTransient<ISsinValidator, BelgianSsinValidator>();
                    services.AddTransient<ISsinGenerator, BelgianSsinGenerator>();
                });

        public static string GetSettingFilePath() => Path.GetFullPath(Path.Combine(GetDirectoryPath(), @"appsettings.json"));

        private static void AddConsoleLogger(this ILoggingBuilder loggingBuilder)
        {
            if (!File.Exists(GetSettingFilePath()))
            {
                loggingBuilder.AddSimpleConsole(options =>
                {
                    options.SingleLine = true;
                    options.IncludeScopes = true;
                    options.UseUtcTimestamp = true;
                    options.TimestampFormat = "[HH:mm:ss:fff] ";
                    options.ColorBehavior = LoggerColorBehavior.Enabled;
                });
            }
        }

        private static void AddNonGenericLogger(this ILoggingBuilder loggingBuilder)
        {
            var categoryName = typeof(Program).Namespace;
            var services = loggingBuilder.Services;
            services.AddSingleton(serviceProvider =>
            {
                var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
                return loggerFactory.CreateLogger(categoryName);
            });
        }

        private static string GetDirectoryPath()
        {
            try
            {
                return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            }
            catch
            {
                return Directory.GetCurrentDirectory();
            }
        }
    }
}
