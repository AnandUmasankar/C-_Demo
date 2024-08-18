using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using System;
using System.Threading.Tasks;

namespace AwsFileUploader
{
    class AwsUploadFile
    {
        static async Task Main(string[] args)
        {
            int inputint = 0;
            Console.WriteLine("Enter the task to be done");
            do
            {
                Console.WriteLine("1.ListBucket");
                Console.WriteLine("2.CreateBucket");
                Console.WriteLine("3.DeleteBucket");
                Console.WriteLine("4.DeleteObject");
                Console.WriteLine("5.DownloadObject");
                Console.WriteLine("6.UploadObject");
                Console.WriteLine("7.EndProcess");
                Console.WriteLine();
                var client = new AmazonS3Client();
                string input = Console.ReadLine();
                inputint = Convert.ToInt32(input);
                if (inputint == 1)
                {
                    await ListBucketsRequest(client);
                }
                if (inputint == 2)
                {
                    await CreateBucketRequest(client);
                }
                if (inputint == 3)
                {
                    await DeleteBucket(client);
                }
                if (inputint == 4)
                {
                    await DeleteObjectNonVersionedBucketAsync(client);
                }
                if (inputint == 5)
                {
                    await DownloadObjectFromS3(client);
                }
                if (inputint == 6)
                {
                    await UploadObjecttoS3(client);
                }
                Console.WriteLine();
            }
            while (inputint != 7);
        }
        static async Task ListBucketsRequest(AmazonS3Client client)
        {
            try
            {
                Console.WriteLine("Listing all the buckets present in AWS:" + Environment.NewLine);

                var listResponse = await MyListBucketAsyncResponse(client);

                foreach (S3Bucket b in listResponse.Buckets)
                {
                    Console.WriteLine(b.BucketName);
                }
            }
            catch (AmazonS3Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static async Task<ListBucketsResponse> MyListBucketAsyncResponse(IAmazonS3 client)
        {
            return await client.ListBucketsAsync();
        }
        public static async Task<bool> CreateBucketRequest(IAmazonS3 client)
        {
            Console.WriteLine("Bucket Name should be Global and All Small Case Letters");
            Console.Write("Enter Bucket Name: ");
            string bucketName = Console.ReadLine();
            try
            {
                var request = new PutBucketRequest
                {
                    BucketName = bucketName,
                    UseClientRegion = true,
                };

                var response = await client.PutBucketAsync(request);
                Console.WriteLine("Bucket Creation SuccessFull");
                return response.HttpStatusCode == System.Net.HttpStatusCode.OK;
            }
            catch (AmazonS3Exception ex)
            {
                Console.WriteLine($"Error creating bucket: '{ex.Message}'");
                return false;
            }
        }
        public static async Task<bool> DeleteBucket(IAmazonS3 client)
        {
            Console.Write("Enter the Bucket Name: ");
            string bucketName= Console.ReadLine();
            try
            {
                var request = new DeleteBucketRequest
                {
                    BucketName = bucketName,
                };

                var response = await client.DeleteBucketAsync(request);
                Console.WriteLine("Deletion of {0} bucket SuccessFull", bucketName);
                return response.HttpStatusCode == System.Net.HttpStatusCode.OK;
            }
            catch (AmazonS3Exception ex)
            {
                Console.WriteLine($"Error creating bucket: '{ex.Message}'");
                return false;
            }
        }
        public static async Task DeleteObjectNonVersionedBucketAsync(IAmazonS3 client)
        {
            Console.Write("Enter the Bucket Name: ");   
            string bucketName =Console.ReadLine();
            Console.Write("Enter the File Name: "); 
                string keyName=Console.ReadLine();  
            try
            {
                var deleteObjectRequest = new DeleteObjectRequest
                {
                    BucketName = bucketName,
                    Key = keyName,
                };

                Console.WriteLine($"Deleting object: {keyName}");
                await client.DeleteObjectAsync(deleteObjectRequest);
                Console.WriteLine($"Object: {keyName} deleted from {bucketName}.");
            }
            catch (AmazonS3Exception ex)
            {
                Console.WriteLine($"Error encountered on server. Message:'{ex.Message}' when deleting an object.");
            }
        }
        public static async Task<bool> DownloadObjectFromS3(
            IAmazonS3 client)
        {
            Console.Write("Enter the Bucket Name: ");
            string bucketName = Console.ReadLine();
            Console.Write("Enter the File Name To be Downloaded: ");
            string objectName = Console.ReadLine();
            Console.Write("Enter the path to be saved : ");
            String filePath = Console.ReadLine();
            var request = new GetObjectRequest
            {
                BucketName = bucketName,
                Key = objectName,
            };
            using GetObjectResponse response = await client.GetObjectAsync(request);

            try
            {
                await response.WriteResponseStreamToFileAsync($"{filePath}\\{objectName}", true, CancellationToken.None);
                Console.WriteLine("Download  Object {0} SuccessFull",objectName);
                return response.HttpStatusCode == System.Net.HttpStatusCode.OK;
            }
            catch (AmazonS3Exception ex)
            {
                Console.WriteLine($"Error saving {objectName}: {ex.Message}");
                return false;
            }
        }
        public static async Task<bool> UploadObjecttoS3(
            IAmazonS3 client)
        {
            Console.Write("Enter the Bucket Name: ");
            string bucketName= Console.ReadLine();

            Console.Write("Enter the File Name that has to be saved : ");
            string objectName= Console.ReadLine();

            Console.Write("Enter the file  path: ");
            string filePath= Console.ReadLine();

            var request = new PutObjectRequest
            {
                BucketName = bucketName,
                Key = objectName,
                FilePath = filePath,
            };

            var response = await client.PutObjectAsync(request);
            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine($"Successfully uploaded {objectName} to {bucketName}.");
                return true;
            }
            else
            {
                Console.WriteLine($"Could not upload {objectName} to {bucketName}.");
                return false;
            }
        }
    }
}
