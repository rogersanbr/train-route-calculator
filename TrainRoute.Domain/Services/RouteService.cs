using Microsoft.Extensions.FileProviders;

namespace TrainRoute.Domain
{
    public class RouteService : IRouteService
    {
        private readonly IFileProvider _fileProvider;

        public RouteService(IFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
        }

        public IFileInfo GetFileInfo(string FilePath)
        {
            return _fileProvider.GetFileInfo(FilePath);
        }

        public void LoadFromFile()
        {
            throw new System.NotImplementedException();
        }
    }
}