using System;
using Microsoft.Data.Sqlite;
using InfraStructure.DataBase;

namespace HelloChinaApi.BussinessLogic
{
    /// <summary>
    /// 初始化历史数据(原来iOS所使用数据保存为Sqlite)
    /// </summary>
    public static class InitEvent
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
                    FROM ZEVENTRECORD
                ";
                //删除原始数据
                MongoDbRepository.DeleteAllRecPhysical(nameof(Event));

                using (var reader = queryCommand.ExecuteReader())
                {
                    int sn = 1;
                    while (reader.Read())
                    {
                        var t = new EventRecord();
                        for (int i = 0; i < 12; i++)
                        {
                            var fieldName = reader.GetName(i);
                            Console.WriteLine(fieldName + ":" + reader.GetValue(i));
                            switch (fieldName)
                            {
                                case "ZNAME":
                                    t.Name = reader.GetValue(i).ToString();
                                    break;
                                case "ZDETAILDYNASTY":
                                    t.DetailDynasty = reader.GetValue(i).ToString();
                                    break;
                                case "ZDESCRIPTIONA":
                                    t.Description = reader.GetValue(i).ToString();
                                    break;
                                case "ZNATION":
                                    t.Nation = reader.GetValue(i).ToString();
                                    break;
                                case "ZMEANING":
                                    t.Meaning = reader.GetValue(i).ToString();
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
