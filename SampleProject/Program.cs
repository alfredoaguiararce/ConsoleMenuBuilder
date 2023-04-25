
// See https://aka.ms/new-console-template for more information
using MenuBuilder.Builders.MenuBuilder;
using MenuBuilder.Interfaces;
using MenuBuilder.Models;
using Microsoft.Extensions.DependencyInjection;

// Crear un proveedor de servicios
var serviceProvider = new ServiceCollection()
    .AddScoped<IUserInputReader, ConsoleUserInputReader>()
    .BuildServiceProvider();

// Obtener una instancia del servicio
IUserInputReader? miServicio = serviceProvider.GetService<IUserInputReader>();

Console.WriteLine("Hello, World!");

var firstvaluepicker = new ConsoleMenuReadBuilder<int>()
           .AddOption("1", () => 1)
           .AddOption("2", () => 2)
           .AddOption("3", () => 3)
           .AsLoop()
           .SetPrompt("Please enter a number: ");

var secondvaluepicker = new ConsoleMenuReadBuilder<int>()
           .AddOption("1", () => 1)
           .AddOption("2", () => 2)
           .AddOption("3", () => 3)
           .AsLoop()
           .SetPrompt("Please enter a number: ");


int a = firstvaluepicker.ReadInput();
int b = secondvaluepicker.ReadInput();

Thread.Sleep(1000);

new ConsoleMenuBuilder(miServicio)
    .AddOption("1", "Ejecuta suma", () => Console.WriteLine($"{a} + {b} = {a+b}"))
    .AddOption("2", "Ejecuta resta", () => Console.WriteLine($"{a} - {b} = {a - b}"))
    .AddOption("3", "Ejecuta multiplicacion", () => Console.WriteLine($"{a} x {b} = {a * b}"))
    .AsLoop()
    .ClearAfterSelection(() => Console.WriteLine("Press any key to continue..."))
    .Build();


Thread.Sleep(1000);

new ConsoleMenuBuilder(miServicio)
    .SetPrompt("Select (y/n)")
    .CreateSimpleYesNoMenu(() => Console.WriteLine("Option yes"),
                           () => Console.WriteLine("Option no")
                            )
    .Build();
