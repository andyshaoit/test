using Amazon.S3;
using Amazon.S3.Model;
using DotNetCore2.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore2.Services
{
    public class S3Storage : IS3Storage
    {
        private readonly string _accessKey = "AKIAIBDVTYG2KG6TWMAQ";
        private readonly string _secretKey = "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";
        private readonly string _bucketName = "myfirstbucket88";

        public async Task<string> DownloadTextFile(string s3Key)
        {
            using (Stream stream = await Download(s3Key))
            {
                TextReader tr = new StreamReader(stream);

                string content = tr.ReadToEnd();

                tr.Dispose();

                return content;
            }
        }

        public async Task<Stream> Download(string s3Key)
        {
            IAmazonS3 client = new AmazonS3Client(_accessKey, _secretKey, Amazon.RegionEndpoint.USEast1);

            GetObjectRequest request = new GetObjectRequest
            {
                BucketName = _bucketName,
                Key = s3Key,
            };

            return (await client.GetObjectAsync(request)).ResponseStream;
        }

        public async Task Upload(Stream stream, string s3Key)
        {
            using (var client = new AmazonS3Client(_accessKey, _secretKey, Amazon.RegionEndpoint.APSoutheast2))
            {
                var request = new PutObjectRequest()
                {
                    BucketName = _bucketName,
                    CannedACL = S3CannedACL.Private,
                    Key = s3Key,
                    InputStream = stream
                };

                await client.PutObjectAsync(request);
            }
        }
    }
}
