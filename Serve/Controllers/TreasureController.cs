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
    public class TreasureController : ControllerBase
    {

         [HttpGet("HelloWorld")]
        public ActionResult<string> HelloWorld()
        {
            return "HelloWorld";
        }

        

        [HttpGet]
        public ActionResult<List<TreasureRecord>> Get()
        {
            var list = new List<TreasureRecord>();
            list = MongoDbRepository.GetRecList<TreasureRecord>();
            return list;
        }

        [HttpGet("GetRecBySN")]
        public ActionResult<TreasureRecord> GetRecBySN(string Sn)
        {
            var t = MongoDbRepository.GetRecBySN<TreasureRecord>(Sn);
            return t;
        }


        /// <summary>
        /// 获得件数
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetRecordCount")]
        public ActionResult<int> GetRecordCount()
        {
            int cnt = MongoDbRepository.GetRecordCount<TreasureRecord>();
            return cnt;
        }


        [HttpPost("Insert")]
        public ActionResult<string> Insert(dynamic data)
        {
            TreasureRecord treasure = JsonConvert.DeserializeObject(data.ToString(), typeof(TreasureRecord));
            MongoDbRepository.InsertRec(treasure);
            return treasure.Sn;
        }



        [HttpGet("GetByPageId")]
        public ActionResult<List<TreasureRecord>> GetByPageId(int Page)
        {
            var list = new List<TreasureRecord>();
            var SkipCnt = (Page - 1) * Config.PageSize;
            //性能不好，考虑将整个数据集进行缓存，或者将简要信息和详细信息分离。
            list = MongoDbRepository.GetRecList<TreasureRecord>().Skip(SkipCnt).Take(Config.PageSize).ToList();
            return list;
        }
    }
}
