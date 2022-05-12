// using Microsoft.AspNetCore.SignalR.Client;
// using Newtonsoft.Json;
// using Serilog;
// using Serilog.Events;
//
// var hubUrl = string.Empty;
//
//
// Log.Logger = new LoggerConfiguration()
//         .MinimumLevel.Debug()
//         .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Debug)
//         .WriteTo.File(Directory.GetCurrentDirectory(), LogEventLevel.Debug)
//     .CreateLogger();
//
// // Hub name populate.
// while (true)
// {
//     Console.Write("Hub url: ");
//     hubUrl = Console.ReadLine();
//
//     if (string.IsNullOrEmpty(hubUrl))
//     {
//         Console.WriteLine("Invalid hub url. Please try again");
//         continue;
//     }
//
//     break;
// }
//
// var methodNames = new HashSet<string>();
// while (true)
// {
//     Console.Write("Method name (QUIT for stop inputting): ");
//     var methodName = Console.ReadLine();
//     if (string.IsNullOrEmpty(methodName))
//     {
//         Console.WriteLine("Method name cannot be empty");
//         continue;
//     }
//
//     if ("QUIT".Equals(methodName, StringComparison.InvariantCultureIgnoreCase))
//     {
//         break;
//     }
//
//     methodNames.Add(methodName);
// }
//
// var hubConnection = new HubConnectionBuilder()
//     .WithUrl(hubUrl)
//     .WithAutomaticReconnect()
//     .Build();
//
// if (!methodNames.Any())
// {
//     Console.WriteLine("No method name is defined. Application will be stopped.");
//     return;
// }
//
// foreach (var methodName in methodNames)
// {
//     hubConnection.On<object>(methodName, (message) =>
//     {
//         Log.Logger.Debug(JsonConvert.SerializeObject(message));
//         return Task.CompletedTask;
//     });
//     
//     Console.WriteLine($"Connected to method {methodName}");
// }
//
// Console.WriteLine("Starting signalr client...");
// hubConnection.StartAsync().Wait();
// Console.WriteLine("Signalr client started !");
//
// Console.ReadLine();
//


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

var methodNames = new HashSet<string>();
while (true)
{
    Console.Write("Method name (QUIT for stop inputting): ");
    var methodName = Console.ReadLine();
    if (string.IsNullOrEmpty(methodName))
    {
        Console.WriteLine("Method name cannot be empty");
        continue;
    }

    if ("QUIT".Equals(methodName, StringComparison.InvariantCultureIgnoreCase))
    {
        break;
    }

    methodNames.Add(methodName);
}

var hubConnection = new HubConnectionBuilder()
    .WithUrl(hubUrl)
    .WithAutomaticReconnect()
    .Build();

if (!methodNames.Any())
{
    Console.WriteLine("No method name is defined. Application will be stopped.");
    return;
}

foreach (var methodName in methodNames)
{
    hubConnection.On<object>(methodName, (message) =>
    {
        Log.Logger.Debug(JsonConvert.SerializeObject(message));
        return Task.CompletedTask;
    });
    
    Console.WriteLine($"Connected to method {methodName}");
}

Console.WriteLine("Starting signalr client...");
hubConnection.StartAsync().Wait();
Console.WriteLine("Signalr client started !");

Console.ReadLine();

