using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore2.Interfaces
{
    public interface IS3Storage
    {
        Task<Stream> Download(string s3Key);
        Task<string> DownloadTextFile(string s3Key);
        Task Upload(Stream stream, string s3Key);
    }
}
