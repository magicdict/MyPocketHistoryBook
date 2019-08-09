using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HelloChinaApi.BussinessLogic;
using InfraStructure.DataBase;
using Newtonsoft.Json;
using System.Linq;

namespace HelloChinaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<EventRecord>> Get()
        {
            var list = new List<EventRecord>();
            list = MongoDbRepository.GetRecList<EventRecord>();
            return list;
        }

        [HttpGet("GetRecBySN")]
        public ActionResult<EventRecord> GetRecBySN(string Sn)
        {
            var t = MongoDbRepository.GetRecBySN<EventRecord>(Sn);
            return t;
        }


        /// <summary>
        /// 获得件数
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetRecordCount")]
        public ActionResult<int> GetRecordCount()
        {
            int cnt = MongoDbRepository.GetRecordCount<EventRecord>();
            return cnt;
        }


        [HttpPost("Insert")]
        public ActionResult<string> Insert(dynamic data)
        {
            EventRecord treasure = JsonConvert.DeserializeObject(data.ToString(), typeof(EventRecord));
            MongoDbRepository.InsertRec(treasure);
            return treasure.Sn;
        }



        [HttpGet("GetByPageId")]
        public ActionResult<List<EventRecord>> GetByPageId(int Page)
        {
            var list = new List<EventRecord>();
            var SkipCnt = (Page - 1) * Config.PageSize;
            //性能不好，考虑将整个数据集进行缓存，或者将简要信息和详细信息分离。
            list = MongoDbRepository.GetRecList<EventRecord>().Skip(SkipCnt).Take(Config.PageSize).ToList();
            return list;
        }
    }
}
