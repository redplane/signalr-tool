using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using Serilog;
using Serilog.Events;

var hubUrl = string.Empty;


Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Debug)
    .WriteTo.File(Directory.GetCurrentDirectory(), LogEventLevel.Debug)
    .CreateLogger();

// Hub name populate.
while (true)
{
    Console.Write("Hub url: ");
    hubUrl = Console.ReadLine();

    if (string.IsNullOrEmpty(hubUrl))
    {
        Console.WriteLine("Invalid hub url. Please try again");
        continue;
    }

    break;
}

