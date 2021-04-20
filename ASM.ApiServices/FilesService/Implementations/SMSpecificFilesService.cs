using System;
using System.IO;
using System.Threading.Tasks;
using ASM.ApiServices.FilesService.Abstractions;
using ASM.ApiServices.FilesService.Configuration;
using Microsoft.Extensions.Options;
using Tools.Library.Analyzers.String.Abstractions;

namespace ASM.ApiServices.FilesService.Implementations
{
    public class SMSpecificFilesService : IFilesService
    {
        private readonly Random _random = new Random();
        private readonly FilesServiceConfiguration _configuration;

        private readonly IStringSimilarityTool _stringSimilarityTool;

        public SMSpecificFilesService(IOptions<FilesServiceConfiguration> configuration,
            IStringSimilarityTool stringSimilarityTool)
        {
            _configuration = configuration.Value;
            _stringSimilarityTool = stringSimilarityTool;
        }
        
        public Task<byte[]> GetRandomFileAsync()
        {
            var filesInDirectory = getFilesInDirectory();
            var randomFileIndex = _random.Next(filesInDirectory.Length);

            var randomFilePath = filesInDirectory[randomFileIndex];
            return File.ReadAllBytesAsync(randomFilePath);
        }

        public Task<byte[]> GetFileClosestToStringTimeAsync()
        {
            var filesInDirectory = getFilesInDirectory();
            var currentDt = DateTime.Now;
            var targetDtString = $"Time_{currentDt.Year}_{currentDt.Month}_{currentDt.Day}_{currentDt.Hour}_{currentDt.Minute}_{currentDt.Second}.png";
            var targetFile = _stringSimilarityTool.findTheMostSimilarString(filesInDirectory, targetDtString);
            return File.ReadAllBytesAsync(targetFile);
        }

        private string[] getFilesInDirectory()
        {
            return Directory.GetFiles(
                Path.Combine(Directory.GetCurrentDirectory(), 
                    _configuration.pathToFolderWithFiles));
        }
    }
}