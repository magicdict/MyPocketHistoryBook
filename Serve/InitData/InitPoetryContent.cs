using System;
using Microsoft.Data.Sqlite;
using InfraStructure.DataBase;

namespace HelloChinaApi.BussinessLogic
{
    /// <summary>
    /// 初始化历史数据(原来iOS所使用数据保存为Sqlite)
    /// </summary>
    public static class InitPoetryContent
    {
        public static void Init()
        {
            const string connectionString = "Data Source=F:\\HelloChinaApi\\Misc\\PocketHistoryBook.sqlite;";
            var masterConnection = new SqliteConnection(connectionString);
            masterConnection.Open();
            using (var secondConnection = new SqliteConnection(connectionString))
            {
                secondConnection.Open();
                var queryCommand = secondConnection.CreateCommand();
                queryCommand.CommandText =
                @"
                    SELECT *
                    FROM ZPOETRYCONTENTRECORD
                ";
                //删除原始数据
                MongoDbRepository.DeleteAllRecPhysical(nameof(PoetryContent));

                using (var reader = queryCommand.ExecuteReader())
                {
                    int sn = 1;
                    while (reader.Read())
                    {
                        var t = new PoetryContentRecord();
                        for (int i = 0; i < 8; i++)
                        {
                            var fieldName = reader.GetName(i);
                            Console.WriteLine(fieldName + ":" + reader.GetValue(i));
                            switch (fieldName)
                            {
                                case "ZNAME":
                                    t.Name = reader.GetValue(i).ToString();
                                    break;
                                case "ZCOMMENT":
                                    t.Comment = reader.GetValue(i).ToString();
                                    break;
                                case "ZCONTENT":
                                    t.Content = reader.GetValue(i).ToString();
                                    break;
                                case "ZORDER":
                                    t.Order = int.Parse(reader.GetValue(i).ToString());
                                    break;
                                default:
                                    break;
                            }
                        }
                        MongoDbRepository.InsertRec(t,sn);
                        sn++;
                    }
                }
            }
            masterConnection.Close();
        }
    }
}
