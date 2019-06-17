using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsitenServer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace InsitenServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<ReturnObject> Get()
        {
            var returnObject = new ReturnObject();
            var test = string.Empty;
            try
            {
                returnObject.Data = FileManager.GetCompanies();
                returnObject.Success = true;
            }
            catch (Exception ex)
            {
                returnObject.Data = ex.Message;
                returnObject.Success = false;
            }

            return Ok(returnObject);
            //return Request.CreateResponse(HttpStatusCode.OK, returnObject, Formatting.Indented); 
        }
    }
}
