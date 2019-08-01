using System;
using Microsoft.Data.Sqlite;
using InfraStructure.DataBase;

namespace HelloChinaApi.BussinessLogic
{
    /// <summary>
    /// 初始化历史数据(原来iOS所使用数据保存为Sqlite)
    /// </summary>
    public static class InitPoetry
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
                    FROM ZPOETRYRECORD
                ";
                //删除原始数据
                MongoDbRepository.DeleteAllRecPhysical(nameof(Poetry));

                using (var reader = queryCommand.ExecuteReader())
                {
                    int sn = 1;
                    while (reader.Read())
                    {
                        var t = new PoetryRecord();
                        for (int i = 0; i < 8; i++)
                        {
                            var fieldName = reader.GetName(i);
                            Console.WriteLine(fieldName + ":" + reader.GetValue(i));
                            switch (fieldName)
                            {
                                case "ZNAME":
                                    t.Name = reader.GetValue(i).ToString();
                                    break;
                                case "ZDESCRIPTIONA":
                                    t.Description = reader.GetValue(i).ToString();
                                    break;
                                case "ZSPECIAL":
                                    t.Special = reader.GetValue(i).ToString();
                                    break;
                                case "ZAUTHOR":
                                    t.Author = reader.GetValue(i).ToString();
                                    break;
                                case "ZIMAGENAME":
                                    t.ImageName = reader.GetValue(i).ToString();
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
