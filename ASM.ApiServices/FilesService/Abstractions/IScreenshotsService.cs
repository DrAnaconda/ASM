using System.Threading.Tasks;

namespace ASM.ApiServices.FilesService.Abstractions
{
    public interface IFilesService
    {
        public Task<byte[]> GetRandomFileAsync();
        public Task<byte[]> GetFileClosestToStringTimeAsync();
    }
}