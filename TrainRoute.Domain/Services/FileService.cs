using Microsoft.Extensions.FileProviders;

namespace TrainRoute.Domain
{
    public class FileService : IFileService
    {
        private readonly IFileProvider _fileProvider;

        public FileService(IFileProvider fileProvider)
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