using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ps.dmv.web.Infrastructure.Core;

namespace ps.dmv.web.Controllers
{
    public class DmvApiController : BaseApiDmvController
    {
        public DmvApiController()
        {
            
        }

        public List<object> Get()
        {
            List<object> listOfItems = new List<object>() { new { description = "coffee pot S" }, new { description = "nerf gun S" }, new { description = "phone S" } };

            //List<string> listOfItems = new List<string>() { {  "coffee pot S" }, { "nerf gun S" }, { "phone S" } };

    //{ "description": "coffee pot" },
    //{ "description": "nerf gun" },
    //{ "description": "phone" }
    //];

            return listOfItems;
        }








        //public HttpResponseMessage Get(int id)
        //{
        //    // ...

        //    return new HttpResponseMessage();
        //}

        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<controller>
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}
