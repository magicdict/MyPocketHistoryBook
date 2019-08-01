using InfraStructure.DataBase;
namespace HelloChinaApi.BussinessLogic
{
    /// <summary>
    /// 事件类
    /// </summary>
    public class Event : EntityBase
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
        public string Meaning;

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
    }

    /// <summary>
    /// 文物类数据
    /// </summary>
    public class EventRecord : Event, IEntityBase
    {
        string IEntityBase.GetCollectionName()
        {
            return nameof(Event);
        }

        string IEntityBase.GetPrefix()
        {
            return string.Empty;
        }
    }
}
