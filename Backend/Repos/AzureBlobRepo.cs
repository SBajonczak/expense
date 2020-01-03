using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace SBA.Expense.Repos
{
    public class AzureBlobRepo : IAzureBlobRepo
    {

        CloudStorageAccount storageAccount;

        public AzureBlobRepo(string connectionString)
        {
            this.storageAccount = CloudStorageAccount.Parse(connectionString);
        }


        public async Task Store(string containerName, string relativePath, string fileName, Stream contents)
        {
            contents.Position = 0;
            var myClient = storageAccount.CreateCloudBlobClient();

            var container = myClient.GetContainerReference(containerName);
            await container.CreateIfNotExistsAsync();
            CloudBlockBlob cloudBlockBlob = container.GetBlockBlobReference(relativePath + "/" + fileName);
            
            await  cloudBlockBlob.UploadFromStreamAsync(contents);
        }

        public async Task<Tuple<string, Stream>> GetFile(string containerName, string relativepath)
        {
            var myClient = storageAccount.CreateCloudBlobClient();
            var container = myClient.GetContainerReference(containerName);
            await container.CreateIfNotExistsAsync();
            var blob = container.GetBlobReference(relativepath);


            MemoryStream stream = new MemoryStream();
            await blob.DownloadToStreamAsync(stream);

            return new Tuple<string, Stream>(blob.Name, stream);
        }

        public async Task DeleteFile(string containerName, string fullPathFileName)
        {
            var myClient = storageAccount.CreateCloudBlobClient();
            var container = myClient.GetContainerReference(containerName);
            await container.CreateIfNotExistsAsync();
            var blob = container.GetBlockBlobReference(fullPathFileName);
            await blob.DeleteIfExistsAsync();
        }
    }
}