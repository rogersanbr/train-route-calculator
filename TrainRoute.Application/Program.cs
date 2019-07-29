using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using TrainRoute.Domain;

namespace TrainRoute.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            // Register Services
            var collection = new ServiceCollection();
            collection.AddScoped<IRouteService, RouteService>();
            collection.AddSingleton<IFileProvider>(new PhysicalFileProvider("/"));

            // Build Service Provider
            var serviceProvider = collection.BuildServiceProvider();

            var routeService = serviceProvider.GetService<IRouteService>();
            var fileInfo = routeService.GetFileInfo("/home/spartanroger/Firefox_wallpaper.png");

            serviceProvider.Dispose();
        }
    }
}