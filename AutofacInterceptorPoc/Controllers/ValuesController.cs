using System.Collections.Generic;
using System.Web.Http;
using AutofacInterceptorPoc.Repositories;

namespace AutofacInterceptorPoc.Controllers
{
    [RoutePrefix("api/values")]
    public class ValuesController : ApiController
    {
        private readonly IValuesRepository _valuesRepository;

        public ValuesController(IValuesRepository valuesRepository)
        {
            _valuesRepository = valuesRepository;
        }
        // GET api/values
        public IEnumerable<string> Get()
        {
            return _valuesRepository.Get();
        }

        // GET api/values/5
        public string Get(int id)
        {
            return _valuesRepository.Get(id);
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            _valuesRepository.Post(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            _valuesRepository.Put(id, value);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            _valuesRepository.Delete(id);
        }

        [HttpGet]
        [Route("unstable")]
        public string UnstableTest()
        {
            return _valuesRepository.PotentialyInstableMethod();
        }
    }
}
