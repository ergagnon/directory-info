namespace DirectoryInfo.Api.Domain.DirectoryInfoAggregate
{
    public interface IDirectoryService
    {
        AbstractFileInfo GetInfo(string path);
    }
}