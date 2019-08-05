using System.IO;
using InfraStructure.Storage;
using System.Collections.Generic;

public static class InitFile
{
    public static Dictionary<string, string> ImageFileNameDict = new Dictionary<string, string>();
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
            if (ImageFileNameDict.ContainsKey(f.Name.Split(".")[0]))
            {
                System.Console.WriteLine("重复图片项目:" + f.Name.Split(".")[0]);
            }
            else
            {
                ImageFileNameDict.Add(f.Name.Split(".")[0], f.Name);
            }
            //暂时去掉文件扩展名，下载的时候不考虑扩展名
            MongoStorage.InsertStreamWithFixFileName(f.OpenRead(), f.Name, Config.FSDBName);
        }
        foreach (var item in Directory.GetDirectories(root))
        {
            UploadDirect(item);
        }
    }

}