using Microsoft.Extensions.FileProviders;

namespace TrainRoute.Domain
{
    public interface IRouteService
    {
        void LoadFromFile();
        IFileInfo GetFileInfo(string FilePath);
    }
}