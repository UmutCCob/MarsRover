using MarsRover.Command;
using MarsRover.Configuration;
using MarsRover.Direction;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection serviceCollection = Initialize();
            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            #region Getting Inputs
            StringBuilder commandStringBuilder = new StringBuilder();
            Console.WriteLine("Would you like to run default values or enter them yourself or use config file? 1 Default 2 Input 3 Config");
            var choice = Console.ReadLine();

            if (choice == "1")
            {
                commandStringBuilder.AppendLine("5 5");
                commandStringBuilder.AppendLine("1 2 N");
                commandStringBuilder.AppendLine("LMLMLMLMM");
                commandStringBuilder.AppendLine("3 3 E");
                commandStringBuilder.AppendLine("MMRMMRMRRM");
            }
            else if (choice == "2")
            {
                Console.WriteLine("Please enter rover count:");
                var roverCount = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < roverCount; i++)
                {
                    if (i == 0)
                    {
                        Console.WriteLine("Please enter surface sizes");
                        commandStringBuilder.AppendLine(Console.ReadLine().Trim());
                    }
                    Console.WriteLine($"Please enter Rover{i + 1}s coordinates");
                    commandStringBuilder.AppendLine(Console.ReadLine().Trim());
                    Console.WriteLine($"Please enter Rover{i + 1}s commands");
                    commandStringBuilder.AppendLine(Console.ReadLine().Trim());
                }
            }
            else if (choice == "3")
            {
                IOperationConfiguration configuration = serviceProvider.GetService<IOperationConfiguration>();
                commandStringBuilder.AppendLine(configuration.SurfaceLimits);

                for (int i = 0; i < configuration.RoverCoordinates.Length; i++)
                {
                    commandStringBuilder.AppendLine(configuration.RoverCoordinates[i]);
                    commandStringBuilder.AppendLine(configuration.RoverCommands[i]);
                }
            }
            else
            {
                Console.WriteLine("Invalid choice");
            }
            #endregion

            var commandStringList = commandStringBuilder.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToList();
            OperationCenter operationCenter = serviceProvider.GetService<OperationCenter>();

            try
            {
                var commands = operationCenter.CreateCommands(commandStringList);
                operationCenter.ExecuteCommands(commands);
                Console.WriteLine(operationCenter.BroadcastResults());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

        private static IServiceCollection Initialize()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true);

            IConfigurationRoot configuration = builder.Build();

            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IConfiguration>(configuration);
            serviceCollection.AddSingleton<IOperationConfiguration, OperationConfiguration>();
            serviceCollection.AddSingleton<ISurface, Surface>();
            serviceCollection.AddSingleton<IRoverFactory, RoverFactory>();
            serviceCollection.AddSingleton<ICommandParser, CommandParser>();
            serviceCollection.AddSingleton<ICommandFactory, CommandFactory>();
            serviceCollection.AddSingleton<OperationCenter>();
            return serviceCollection;
        }
    }
}
