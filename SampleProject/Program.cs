
// See https://aka.ms/new-console-template for more information
using MenuBuilder.Builders.MenuBuilder;
using MenuBuilder.Interfaces;
using MenuBuilder.Models;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    private static void Main(string[] args)
    {
        // Crear un proveedor de servicios
        var serviceProvider = new ServiceCollection()
            .AddScoped<IUserInputReader, ConsoleUserInputReader>()
            .BuildServiceProvider();

        // Obtener una instancia del servicio
        IUserInputReader miServicio = serviceProvider.GetService<IUserInputReader>();
        Console.WriteLine("Hello, World!");

        var menuBuilder = new ConsoleMenuReadBuilder<int>();
        menuBuilder.AddOption("1", () => 1)
                   .AddOption("2", () => 2)
                   .AddOption("3", () => 3)
                   .AsLoop()
                   .SetPrompt("Please enter a number: ");


        int selectedOption = menuBuilder.ReadInput();
        Console.WriteLine("You selected option: " + selectedOption);

        Thread.Sleep(1000);

        new ConsoleMenuBuilder(miServicio)
            .AddOption("1","Ejecuta suma", () => Console.WriteLine("Option 1"))
            .AddOption("2", "Ejecuta resta", () => Console.WriteLine("Option 2"))
            .AddOption("3", "Ejecuta multiplicacion",() => Console.WriteLine("Option 3"))
            .AsLoop()
            .ClearAfterSelection(() => Console.WriteLine("Press any key to continue..."))
            .Build();
    }
}