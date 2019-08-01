using System.IO;
using InfraStructure.Storage;

public static class FileMgr
{


    public static void Init()
    {
        var root = @"F:\HelloChinaApi\Image";
        UploadDirect(root);
    }

    static void UploadDirect(string root)
    {
        foreach (var item in Directory.GetFiles(root))
        {
            var f = new System.IO.FileInfo(item);
            MongoStorage.InsertStreamWithFixFileName(f.OpenRead(), f.Name, "Main");
        }
        foreach (var item in Directory.GetDirectories(root))
        {
            UploadDirect(item);
        }
    }

}