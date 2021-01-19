using Microsoft.Extensions.FileProviders;
using TrainRoute.Domain;
using Moq;
using Xunit;
using FluentAssertions;

namespace TrainRoute.Test.Domain.Services
{
    public class FileServiceTest
    {
        private Mock<IFileProvider> _mockFileProvider { get; set; }

        // [Fact]
        // public void ShouldGetFileInfo()
        // {
        //     //Given
        //     _mockFileProvider = new Mock<IFileProvider>();
        //     var fileService = new FileService(_mockFileProvider.Object);
        //     //Then
        //     fileService.GetFileInfo("data/test.txt").Should().BeOfType<IFileInfo>();
        // }
    }
}