using System;
using System.IO;
using DirectoryInfo.Api.Domain.DirectoryInfoAggregate;
using DirectoryInfo.Api.Domain.Exceptions;
using SystemDirectoryInfo = System.IO.DirectoryInfo;
using DomainDirectoryInfo = DirectoryInfo.Api.Domain.DirectoryInfoAggregate.DirectoryInfo;
using FileInfo = DirectoryInfo.Api.Domain.DirectoryInfoAggregate.FileInfo;

namespace DirectoryInfo.Api.Infrastructure
{
    public class DirectoryService : IDirectoryService
    {
        public AbstractFileInfo GetInfo(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ValidationException("Directory path is null or empty");
            }

            if (!Directory.Exists(path))
            {
                throw new ValidationException("Directory don't exists.");
            }

            AbstractFileInfo result;
            
            try
            {
                var systemDir = new SystemDirectoryInfo(path);
                result = CreateDirectoryInfo(systemDir);

            }
            catch (Exception ex)
            {
                throw new ValidationException(ex.Message);
            }
            

            return result;
        }

        private DomainDirectoryInfo CreateDirectoryInfo(SystemDirectoryInfo systemDir)
        {
            DomainDirectoryInfo directoryInfo = 
                new DomainDirectoryInfo(systemDir.Name, systemDir.LastWriteTime);
            
            foreach(var fi in systemDir.EnumerateFiles())
            {
                directoryInfo.Add(new FileInfo(fi.Name, fi.Length, fi.LastWriteTime));
            } 

            foreach(var di in systemDir.EnumerateDirectories())
            {
                directoryInfo.Add(CreateDirectoryInfo(di));               
            }                  

            return directoryInfo;
        }
    }
}