
namespace PozorDomStoreService.Infrastructure.Providers
{
    public interface IImageProvider
    {
        Task<string> SaveSingleImage(Stream imageStream, string originalFileName, string destination = "uploads");
        Task DeleteSingleImage(string relativePath);
    }
}
