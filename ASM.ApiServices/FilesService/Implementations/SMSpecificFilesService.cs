using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ASM.ApiServices.FilesService.Abstractions;
using ASM.ApiServices.FilesService.Configuration;
using Microsoft.Extensions.Options;
using Tools.Library.Analyzers.DateTime.Abstractions;
using Tools.Library.Analyzers.String.Abstractions;

namespace ASM.ApiServices.FilesService.Implementations
{
    public class SMSpecificFilesService : IFilesService
    {
        private readonly Random _random = new Random();
        private readonly FilesServiceConfiguration _configuration;
        
        private readonly IDateTimeAnalyzer _dateTimeAnalyzer;

        private readonly IEnumerable<string> _entireFilesList;

        private readonly IEnumerable<DateTime> _filesDateTimeRepresentation;

        public SMSpecificFilesService(IOptions<FilesServiceConfiguration> configuration,
            IDateTimeAnalyzer dateTimeAnalyzer)
        {
            _configuration = configuration.Value;
            _dateTimeAnalyzer = dateTimeAnalyzer;

            _entireFilesList = getFilesInDirectory();
            var withoutExtensionList = getFilesInDirectory().Select(Path.GetFileNameWithoutExtension).ToArray();
            _filesDateTimeRepresentation =
                dateTimeAnalyzer.extractDateTimesFromStringArrays(withoutExtensionList, "_", true);
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
            var currentDt = DateTime.UtcNow;
            var theMostClosestDt =
                _dateTimeAnalyzer.findTheMostClosestDateTime(currentDt, _filesDateTimeRepresentation, true, true, true);
            var targetFile =
                $"Time_{theMostClosestDt.Year}_{theMostClosestDt.Month}_{theMostClosestDt.Day}_{theMostClosestDt.Hour}_{theMostClosestDt.Minute}_{theMostClosestDt.Second}.png";
            return File.ReadAllBytesAsync(targetFile);
        }

        private string[] getFilesInDirectory()
        {
            return Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(),
                _configuration.pathToFolderWithFiles));
        }
    }
}
