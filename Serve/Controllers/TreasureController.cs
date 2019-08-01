using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HelloChinaApi.BussinessLogic;
using InfraStructure.DataBase;
using Newtonsoft.Json;

namespace HelloChinaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreasureController : ControllerBase
    {
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
        public ActionResult<int> GetRecordCount(){
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
    }
}
