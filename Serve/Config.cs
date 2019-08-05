public static class Config
{
    public const string AliyunConnectionString = @"mongodb://39.105.206.6:27017";

    /// <summary>
    /// 是否初始化数据
    /// </summary>
    public static bool IsInitData = false;

    public const string LocalImageFileRoot = @"F:\MyPocketHistoryBook\资料\图片";

    public const string LocalSqliteConnectiongString = @"Data Source=F:\MyPocketHistoryBook\资料\Sqlite\PocketHistoryBook.sqlite;";

    public const string MainDBName = "Main";

    public const string FSDBName = "FileSystem";

    /// <summary>
    /// 分页数据大小
    /// </summary>
    public const int PageSize = 15;
}