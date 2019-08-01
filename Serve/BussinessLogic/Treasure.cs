using InfraStructure.DataBase;
namespace HelloChinaApi.BussinessLogic
{
    /// <summary>
    /// 文物类
    /// </summary>
    public class Treasure : EntityBase
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name;

        /// <summary>
        /// 博物馆
        /// </summary>
        public string Museum;

        /// <summary>
        /// 描述
        /// </summary>
        public string Description;

        /// <summary>
        /// 朝代
        /// </summary>
        public string DetailDynasty;

        /// <summary>
        /// 种类
        /// </summary>
        public string Special;

        /// <summary>
        /// 出土地
        /// </summary>
        public string Unearthedplace;

        /// <summary>
        /// 作者
        /// </summary>
        public string Author;

        /// <summary>
        /// 临摹者
        /// </summary>
        public string Reproduction;

        /// <summary>
        /// 图片名称
        /// </summary>
        public string ImageName;

    }

    /// <summary>
    /// 文物类数据
    /// </summary>
    public class TreasureRecord : Treasure, IEntityBase
    {
        string IEntityBase.GetCollectionName()
        {
            return nameof(Treasure);
        }

        string IEntityBase.GetPrefix()
        {
            return string.Empty;
        }
    }
}
