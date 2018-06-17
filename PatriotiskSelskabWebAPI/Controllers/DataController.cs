using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PatriotiskSelskabWebAPI.Models;
using Microsoft.AspNetCore.Cors;

namespace PatriotiskSelskabWebAPI.Controllers
{

    [EnableCors("AllowAnyOrigin")]
    public class DataController : Controller
    {
        [Route("GetYears")]
        [HttpGet]
        public IEnumerable<int> Get()
        {
            return DataBaseConnector.GetYears();
        }

        [Route("GetFieldBlocks/{year}")]
        [HttpGet]
        public IEnumerable<FieldBlock> GetFieldBlocks(int year)
        {
            return DataBaseConnector.GetYearFieldBlocks(year);
        }

        [Route("GetFieldBlock/{fieldblockid}")]
        [HttpGet]
        public FieldBlock GetFieldBlock(int fieldblockid)
        {
            return DataBaseConnector.GetYearFieldBlock(fieldblockid);
        }

        [Route("GetSubBlocks/{fieldblockid}")]
        [HttpGet]
        public IEnumerable<SubBlock> GetSubBlocks(int fieldblockid)
        {
            return DataBaseConnector.GetSubBlocks(fieldblockid);
        }

        [Route("GetSubBlock/{subblockid}")]
        [HttpGet]
        public SubBlock GetSubBlock(int subblockid)
        {
            return DataBaseConnector.GetSubBlock(subblockid);
        }

        [Route("GetSubBlockFieldBlock/{subblockid}")]
        [HttpGet]
        public FieldBlock GetSubBlockFieldBlock(int subblockid)
        {
            return DataBaseConnector.GetSubBlockFieldBlock(subblockid);
        }

        [Route("GetTrialGroups/{subblockid}")]
        [HttpGet]
        public IEnumerable<TrialGroup> GetTrialGroups(int subblockid)
        {
            return DataBaseConnector.GetTrialGroups(subblockid);
        }

        [Route("GetTrialGroup/{trialgroupid}")]
        [HttpGet]
        public TrialGroup GetTrialGroup(int trialgroupid)
        {
            return DataBaseConnector.GetTrialGroup(trialgroupid);
        }

        [Route("GetTrialGroupSubBlock/{trialgroupid}")]
        [HttpGet]
        public SubBlock GetTrialGroupSubBlock(int trialgroupid)
        {
            return DataBaseConnector.GetTrialGroupSubBlock(trialgroupid);
        }

        [Route("GetTrialGroupTreatments/{trialgroupid}")]
        [HttpGet]
        public IEnumerable<Treatment> GetTrialGroupTreatments(int trialgroupid)
        {
            return DataBaseConnector.GetTrialGroupTreatments(trialgroupid);
        }

        [Route("GetAllWeeds/")]
        [HttpGet]
        public IEnumerable<Crop> GetAllWeeds()
        {
            return DataBaseConnector.GetAllWeeds();
        }

        [Route("GetTopResults/")]
        [HttpGet]
        public IEnumerable<TopResult> GetTopResults()
        {
            return DataBaseConnector.GetTopResults();
        }

        [Route("GetTrialTypes/")]
        [HttpGet]
        public IEnumerable<TrialType> GetTrialTypes()
        {
            return DataBaseConnector.GetTrialTypes();
        }

        [Route("GetTrialTypeCrops/{trialtypeid}")]
        [HttpGet]
        public IEnumerable<Crop> GetTrialTypeCrops(int trialtypeid)
        {
            return DataBaseConnector.GetTrialTypeCrops(trialtypeid);
        }

        [Route("GetCropYears/{trialtypeid}/{cropid}")]
        [HttpGet]
        public IEnumerable<int> GetCropYears(int trialtypeid, int cropid)
        {
            return DataBaseConnector.GetCropYears(trialtypeid,cropid);
        }


        [Route("AddFieldBlock")]
        [HttpPost]
        public void Post([FromBody]FieldBlock fieldBlock)
        {
            DataBaseConnector.AddFieldBlock(fieldBlock);
        }
    }
}
