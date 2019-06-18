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
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<ReturnObject> Get(int id)
        {
            var returnObject = new ReturnObject();

            try
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(FileManager.GetCompany(id));
                returnObject.Data = json;
                returnObject.Success = true;
            }
            catch (Exception ex)
            {
                returnObject.Data = ex.Message;
                returnObject.Success = false;
            }

            return Ok(returnObject);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<ReturnObject> Post([FromBody]Company com)
        {
            var returnObject = new ReturnObject();

            try
            {
                var id = FileManager.AddUpdateCompany(com);
                returnObject.Data = id.ToString();
                returnObject.Success = true;
            }
            catch (Exception ex)
            {
                returnObject.Data = ex.Message;
                returnObject.Success = false;
            }

            return Ok(returnObject);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<ReturnObject> Delete(int id)
        {
            var returnObject = new ReturnObject();

            try
            {
                var removedName = FileManager.RemoveCompany(id);
                returnObject.Data = removedName;
                returnObject.Success = true;
            }
            catch (Exception ex)
            {
                returnObject.Data = ex.Message;
                returnObject.Success = false;
            }

            return Ok(returnObject);
        }
    }
}
