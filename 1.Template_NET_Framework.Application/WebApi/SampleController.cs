using _0.Template_NET_Framework.Common.Interface;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _1.Template_NET_Framework.Application.WebApi
{
    public class SampleController : ApiController
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public SampleController(
            ILogger logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }


        // GET: api/Sample
        public IEnumerable<string> Get()
        {
            return new string[] { "A", "B" };
        }

        // GET: api/Sample/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Sample
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Sample/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Sample/5
        public void Delete(int id)
        {
        }
    }
}
