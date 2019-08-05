using System;
using System.Collections.Generic;
using MongoDB.Driver.GridFS;
using System.IO;
using MongoDB.Driver;
using Microsoft.AspNetCore.Http;

namespace InfraStructure.Storage
{
    public static class MongoStorage
    {
        /// <summary>
        ///     服务器
        /// </summary>
        private static MongoServer _innerServer;


        /// <summary>
        ///     初始化MongoDB
        /// </summary>
        /// <param name="dbList">除去Logger以外</param>
        /// <param name="defaultDbName"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public static bool Init(string ConnectionString = @"mongodb://localhost:27017")
        {
            try
            {
                _innerServer = new MongoClient(ConnectionString).GetServer();
                _innerServer.Connect();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void EmptyFileSystem(string databaseType)
        {
            _innerServer.GetDatabase(databaseType).DropCollection("fs.files");
            _innerServer.GetDatabase(databaseType).DropCollection("fs.chunks");

        }

        /// <summary>
        ///     保存文件
        /// </summary>
        /// <param name="file"></param>
        /// <param name="ownerId"></param>
        /// <param name="databaseType"></param>
        /// <returns></returns>
        public static string InsertFile(IFormFile file, string ownerId, string databaseType)
        {
            var mongofilename = ownerId + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + file.FileName;
            var FSDB = _innerServer.GetDatabase(databaseType);
            var gfs = FSDB.GetGridFS(new MongoGridFSSettings());
            gfs.Upload(file.OpenReadStream(), mongofilename);
            return mongofilename;
        }

        /// <summary>
        ///     保存文件
        /// </summary>
        /// <param name="file"></param>
        /// <param name="fileName"></param>
        /// <param name="ownerId"></param>
        /// <param name="databaseType"></param>
        /// <returns></returns>
        public static string InsertFile(Stream file, string fileName, string ownerId, string databaseType)
        {
            var mongofilename = ownerId + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + fileName;
            var FSDB = _innerServer.GetDatabase(databaseType);
            var gfs = FSDB.GetGridFS(new MongoGridFSSettings());
            gfs.Upload(file, mongofilename);
            return mongofilename;
        }

        /// <summary>
        /// 保存流为固定文件名
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="filename"></param>
        /// <param name="databaseType"></param>
        public static void InsertStreamWithFixFileName(Stream stream, string filename, string databaseType)
        {
            var FSDB = _innerServer.GetDatabase(databaseType);
            var gfs = FSDB.GetGridFS(new MongoGridFSSettings());
            gfs.Upload(stream, filename);
        }


        /// <summary>
        ///     获得文件
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="filename"></param>
        public static Stream GetFile(string filename, string databaseType)
        {
            var FSDB = _innerServer.GetDatabase(databaseType);
            var gfs = FSDB.GetGridFS(new MongoGridFSSettings());
            if (gfs.Exists(filename))
            {
                return gfs.Open(filename, FileMode.Open);
            }
            return null;
        }


        /// <summary>
        /// Mongo文件结构
        /// </summary>
        public struct DbFileInfo
        {
            /// <summary>
            /// 文件名
            /// </summary>
            public string FileName;
            /// <summary>
            /// 数据库文件名
            /// </summary>
            public string DbFileName;
        }

        /// <summary>
        /// 文件备份
        /// </summary>
        /// <param name="fileList">文件列表</param>
        /// <param name="path">备份路径。注意以斜线结尾</param>
        /// <param name="databaseType">数据库名称</param>
        public static void BackUpFiles(List<DbFileInfo> fileList, string path, string databaseType)
        {
            var FSDB = _innerServer.GetDatabase(databaseType);
            foreach (var item in fileList)
            {
                var gfs = FSDB.GetGridFS(new MongoGridFSSettings());
                gfs.Download(path + item.FileName, item.DbFileName);
            }
        }
    }
}
