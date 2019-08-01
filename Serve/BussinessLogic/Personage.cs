using InfraStructure.DataBase;
namespace HelloChinaApi.BussinessLogic
{
    /// <summary>
    /// 人物类
    /// </summary>
    public class Personage : EntityBase
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name;

        /// <summary>
        /// 国家
        /// </summary>
        public string Nation;

        /// <summary>
        /// 意义
        /// </summary>
        public string Special;

        /// <summary>
        /// 朝代
        /// </summary>
        public string DetailDynasty;

        /// <summary>
        /// 图片名称
        /// </summary>
        public string ImageName;

        /// <summary>
        /// 描述
        /// </summary>
        public string Description;

        /// <summary>
        /// 别称
        /// </summary>
        public string Alias;

        /// <summary>
        /// 主要功绩
        /// </summary>
        public string MainWork;

    }

    /// <summary>
    /// 文物类数据
    /// </summary>
    public class PersonageRecord : Personage, IEntityBase
    {
        string IEntityBase.GetCollectionName()
        {
            return nameof(Personage);
        }

        string IEntityBase.GetPrefix()
        {
            return string.Empty;
        }
    }
}
