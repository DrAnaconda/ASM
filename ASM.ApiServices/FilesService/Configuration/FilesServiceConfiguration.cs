using System.IO;

namespace ASM.ApiServices.FilesService.Configuration
{
    public class FilesServiceConfiguration
    {
        public string pathToFolderWithFiles { get; set; } = Directory.GetCurrentDirectory();
    }
}