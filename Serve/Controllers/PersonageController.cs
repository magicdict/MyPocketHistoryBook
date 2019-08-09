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
    public class PersonageController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<PersonageRecord>> Get()
        {
            var list = new List<PersonageRecord>();
            list = MongoDbRepository.GetRecList<PersonageRecord>();
            return list;
        }

        [HttpGet("GetRecBySN")]
        public ActionResult<PersonageRecord> GetRecBySN(string Sn)
        {
            var t = MongoDbRepository.GetRecBySN<PersonageRecord>(Sn);
            return t;
        }


        /// <summary>
        /// 获得件数
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetRecordCount")]
        public ActionResult<int> GetRecordCount()
        {
            int cnt = MongoDbRepository.GetRecordCount<PersonageRecord>();
            return cnt;
        }


        [HttpPost("Insert")]
        public ActionResult<string> Insert(dynamic data)
        {
            PersonageRecord treasure = JsonConvert.DeserializeObject(data.ToString(), typeof(PersonageRecord));
            MongoDbRepository.InsertRec(treasure);
            return treasure.Sn;
        }



        [HttpGet("GetByPageId")]
        public ActionResult<List<PersonageRecord>> GetByPageId(int Page)
        {
            var list = new List<PersonageRecord>();
            var SkipCnt = (Page - 1) * Config.PageSize;
            //性能不好，考虑将整个数据集进行缓存，或者将简要信息和详细信息分离。
            list = MongoDbRepository.GetRecList<PersonageRecord>().Skip(SkipCnt).Take(Config.PageSize).ToList();
            return list;
        }
    }
}
