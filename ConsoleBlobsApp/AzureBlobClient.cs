using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

public class AzureBlobClient 
{ 
    private static String connectionString = "DefaultEndpointsProtocol=https;AccountName=asmafm46;AccountKey=KngEMPYHuldQp15PeYFvWN1ucMd4nQasdjijdhOt1KLTNDBP1/koQ5B6EJvAssCB4d2SGxIftlXH+AStRx//rg==;EndpointSuffix=core.windows.net";
    private static string containerName = "myfiles";
    private static BlobServiceClient serviceClient = new BlobServiceClient(connectionString);

    public static async Task UploadBlob(string fileName) 
    { 
        var containerClient = serviceClient.GetBlobContainerClient(containerName); 
        var path = @""; 
        //var fileName = "Testfile.txt"; 
        var localFile = Path.Combine(path, fileName); 
        await File.WriteAllTextAsync(localFile, "This is a test message"); 
        var blobClient = containerClient.GetBlobClient(fileName); 
        Console.WriteLine("Uploading to Blob storage"); 
        using FileStream uploadFileStream = File.OpenRead(localFile); 
        await blobClient.UploadAsync(uploadFileStream, true); 
        uploadFileStream.Close(); 
    } 

    public static async Task DeleteBlob(string containerName)
    {
        var containerClient = serviceClient.GetBlobContainerClient(containerName);
        var fileName = "Testfile.txt";
        var blobClient = containerClient.GetBlobClient(fileName);
        await blobClient.DeleteAsync();
    }

    public static async Task ListBlobs()
    {
        var containerClient = serviceClient.GetBlobContainerClient(containerName);
        await foreach (BlobItem blobItem in containerClient.GetBlobsAsync())
        {
            Console.WriteLine("\t" + blobItem.Name);
        }
    }

    public static async Task DownloadBlobToFileAsync(string fileName, string containerName, string localFilePath)
    {
        var containerClient = serviceClient.GetBlobContainerClient(containerName);
        var blobClient = containerClient.GetBlobClient(fileName);
        await blobClient.DownloadToAsync(localFilePath);
        Console.WriteLine("ownload from Blob storage");
    }
}