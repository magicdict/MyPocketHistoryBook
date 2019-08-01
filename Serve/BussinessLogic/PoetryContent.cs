using InfraStructure.DataBase;
namespace HelloChinaApi.BussinessLogic
{
    /// <summary>
    /// 诗词类 - 内容
    /// </summary>
    public class PoetryContent : EntityBase
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name;
        
        /// <summary>
        /// 顺序
        /// </summary>
        public int Order;

        /// <summary>
        /// 诗句
        /// </summary>
        public string Content;

        /// <summary>
        /// 注释
        /// </summary>
        public string Comment;

    }

    /// <summary>
    /// 文物类数据
    /// </summary>
    public class PoetryContentRecord : PoetryContent, IEntityBase
    {
        string IEntityBase.GetCollectionName()
        {
            return nameof(PoetryContent);
        }

        string IEntityBase.GetPrefix()
        {
            return string.Empty;
        }
    }
}
