using System.IO;
using InfraStructure.Storage;

public static class InitFile
{
    public static void InitImage()
    {
        MongoStorage.EmptyFileSystem(Config.FSDBName);
        UploadDirect(Config.LocalImageFileRoot);
    }
    static void UploadDirect(string root)
    {
        foreach (var item in Directory.GetFiles(root))
        {
            var f = new System.IO.FileInfo(item);
            MongoStorage.InsertStreamWithFixFileName(f.OpenRead(), f.Name, Config.FSDBName);
        }
        foreach (var item in Directory.GetDirectories(root))
        {
            UploadDirect(item);
        }
    }

}