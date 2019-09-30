using Microsoft.Extensions.FileProviders;

namespace TrainRoute.Domain
{
    public interface IFileService
    {
        void LoadFromFile();
        IFileInfo GetFileInfo(string FilePath);
    }
}