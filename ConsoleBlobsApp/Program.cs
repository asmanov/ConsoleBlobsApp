//using AzureBlobStorageClient;
using System;

//await AzureBlobClient.UploadBlob("Testfile1.txt");
//await AzureBlobClient.UploadBlob("Testfile2.txt");
//await AzureBlobClient.ListBlobs();
//await AzureBlobClient.DeleteBlob("myfiles");
await AzureBlobClient.DownloadBlobToFileAsync("Testfile2.txt", "myfiles", "testlocal2.txt");
Console.ReadKey();
