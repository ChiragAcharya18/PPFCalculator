using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PPFCalculator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPFCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PPFCalc : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "API works";
        }

        [HttpPost]
        [Route("getCompleteDetails")]
        public JsonResult GetCompleteDetails([FromBody] PPFParameters parameters)
        {
            PPFCalculator pPFCalculator = new PPFCalculator(parameters.Deposite,parameters.Duration,parameters.RateOfInterest);

            List<Data> datas = pPFCalculator.getCompleteDetails();
            return new JsonResult(datas);
        }

        [HttpPost]
        [Route("GetMaturityAmount")]
        public JsonResult GetMaturityAmount([FromBody] PPFParameters parameters)
        {
            PPFCalculator pPFCalculator = new PPFCalculator(parameters.Deposite, parameters.Duration, parameters.RateOfInterest);

            Maturity datas = pPFCalculator.CalcMaturityAmount();
            return new JsonResult(datas);
        }
    }
}
