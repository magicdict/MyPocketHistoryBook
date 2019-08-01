using InfraStructure.DataBase;
namespace HelloChinaApi.BussinessLogic
{
    /// <summary>
    /// 诗词类 - 概要
    /// </summary>
    public class Poetry : EntityBase
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name;

        /// <summary>
        /// 种类
        /// </summary>
        public string Special;

        /// <summary>
        /// 图片名称
        /// </summary>
        public string ImageName;

        /// <summary>
        /// 作者
        /// </summary>
        public string Author;

        /// <summary>
        /// 描述
        /// </summary>
        public string Description;
    }

    /// <summary>
    /// 文物类数据
    /// </summary>
    public class PoetryRecord : Poetry, IEntityBase
    {
        string IEntityBase.GetCollectionName()
        {
            return nameof(Poetry);
        }

        string IEntityBase.GetPrefix()
        {
            return string.Empty;
        }
    }
}
