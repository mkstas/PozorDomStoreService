namespace PozorDomStoreService.Infrastructure.Providers
{
    public class ImageProvider : IImageProvider
    {
        private readonly string _baseStoragePath;
        private readonly string[] _allowedImageExtensions = [".jpg", ".jpeg", ".png", ".gif"];

        public ImageProvider(string baseStoragePath)
        {
            _baseStoragePath = baseStoragePath ?? throw new ArgumentNullException(nameof(baseStoragePath));
            if (!Directory.Exists(_baseStoragePath))
                throw new ArgumentException($"Base storage path does not exist: {_baseStoragePath}", nameof(baseStoragePath));
        }

        public async Task<string> SaveSingleImage(Stream imageStream, string originalFileName, string destination = "uploads")
        {
            ValidateImageStream(imageStream);
            ValidateImageExtension(originalFileName);

            var absoluteDestinationPath = Path.Combine(_baseStoragePath, destination);
            Directory.CreateDirectory(absoluteDestinationPath);

            var fileName = GenerateFileName(originalFileName);
            var filePath = Path.Combine(absoluteDestinationPath, fileName);

            await SaveFileAsync(imageStream, filePath);

            // Возвращаем относительный путь для удобства (например, для URL)
            return Path.Combine(destination, fileName).Replace('\\', '/');
        }

        public Task DeleteSingleImage(string relativePath)
        {
            if (string.IsNullOrWhiteSpace(relativePath))
                return Task.CompletedTask;

            // Защита от path traversal
            var normalizedRelative = Path.GetFullPath(relativePath.Replace('/', Path.DirectorySeparatorChar));
            var fullPath = Path.Combine(_baseStoragePath, normalizedRelative);

            // Убедимся, что путь всё ещё внутри _baseStoragePath (защита от ../ атак)
            if (!fullPath.StartsWith(_baseStoragePath, StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException("Invalid path: attempted directory traversal.", nameof(relativePath));

            if (File.Exists(fullPath))
                File.Delete(fullPath);

            return Task.CompletedTask;
        }

        private static void ValidateImageStream(Stream stream)
        {
            ArgumentNullException.ThrowIfNull(stream);

            if (!stream.CanRead)
                throw new ArgumentException("Image stream is not readable.", nameof(stream));

            // Опционально: проверить, что stream.Length > 0 (если поддерживается)
            // Некоторые потоки не поддерживают Length, поэтому лучше читать байт
        }

        private void ValidateImageExtension(string originalFileName)
        {
            var extension = Path.GetExtension(originalFileName).ToLowerInvariant();
            if (!_allowedImageExtensions.Contains(extension))
                throw new InvalidDataException("Invalid image format.");
        }

        private static string GenerateFileName(string originalFileName)
        {
            var extension = Path.GetExtension(originalFileName).ToLowerInvariant();
            return $"{Guid.NewGuid()}{extension}";
        }

        private static async Task SaveFileAsync(Stream source, string destination)
        {
            using var fileStream = new FileStream(destination, FileMode.Create, FileAccess.Write, FileShare.None);
            await source.CopyToAsync(fileStream);
        }
    }
}
