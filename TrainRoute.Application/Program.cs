using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using TrainRoute.Application.Services;
using TrainRoute.Domain;

namespace TrainRoute.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            // Register Services
            var collection = new ServiceCollection();
            collection.AddScoped<IFileService, FileService>();
            collection.AddSingleton<IFileProvider>(new PhysicalFileProvider("/"));

            // Build Service Provider
            var serviceProvider = collection.BuildServiceProvider();
            var filePath = "/home/spartanroger/Firefox_wallpaper.png";
            var routeService = serviceProvider.GetService<IFileService>();
            var fileInfo = routeService.GetFileInfo(filePath);

            if(!fileInfo.Exists) ExecutionService.ExecuteFromHardCoded();

            serviceProvider.Dispose();
        }
    }
}