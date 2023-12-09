// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;


internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");




    }

    private IConfiguration BuildConfiguration()
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