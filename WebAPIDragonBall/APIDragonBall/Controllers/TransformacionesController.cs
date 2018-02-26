using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIDragonBall.Controllers
{
    public class TransformacionesController : ApiController
    {
        // GET: api/Transformaciones
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Transformaciones/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Transformaciones
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Transformaciones/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Transformaciones/5
        public void Delete(int id)
        {
        }
    }
}
