// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Settings.Configuration;

internal class Program
{
    private static void Main(string[] args)
    {

        Console.WriteLine("Hello, World!");

        var config = BuildConfiguration();

        var logger = new LoggerConfiguration()
                        .ReadFrom.Configuration(config)
                        .CreateLogger();

        try
        {


            logger.Information($"Starting sandbox at {DateTimeOffset.Now.ToString()}");

            logger.Warning("Throwing Exception now...");
            throw new ApplicationException("This exception should be caught and logged.");
        }
        catch (Exception ex)
        {
            logger.Error(ex, $"An exception occurred while running the app : {ex.Message}");
        }

    }

    private static IConfiguration BuildConfiguration()
    {

        var envJsonFile = $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development"}.json";
        IConfigurationBuilder builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddJsonFile(envJsonFile, false)
            .AddEnvironmentVariables();


        return builder.Build();


    }
}