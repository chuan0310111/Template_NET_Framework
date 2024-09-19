using _0.Template_NET_Framework.Common.Interface;
using _1.Template_NET_Framework.Application.WebApi.Filters;
using _1.Template_NET_Framework.Application.WebApi.ViewModels;
using _2.Template_NET_Framework.Services.Dtos;
using _2.Template_NET_Framework.Services.Interface;
using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;

namespace _1.Template_NET_Framework.Application.WebApi
{
    public class SampleController : ApiController
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly ISampleService _sampleService;

        public SampleController(
            ILogger logger, IMapper mapper, ISampleService sampleService)
        {
            _logger = logger;
            _mapper = mapper;
            _sampleService = sampleService;
        }

        [TimeLog]
        public HsinChuAreaResultViewModel GetAreas() { 
            var cMethed = MethodBase.GetCurrentMethod();
            var logTitle = $"{cMethed.DeclaringType.Name}.{cMethed.Name}";
            var result = new HsinChuAreaResultViewModel();

            try
            {
                this._logger.Info($"{logTitle} START");

                result = this._mapper.Map<HsinChuAreaResultViewModel>(_sampleService.GetArea());

            }
            catch (Exception ex)
            {
                var isLogged = (ex.Data["IsLogged"] as string == "Y");
                if (isLogged == false)
                {
                    this._logger.Error($"{logTitle} [error: {ex.Message}]\n{ex.StackTrace}");
                    ex.Data.Add("IsLogged", "Y");
                }

                result = new HsinChuAreaResultViewModel()
                {
                    ResultCode = "999901",
                    ResultMsg = ex.Message
                };
            }


            this._logger.Info($"{logTitle} [Response: {JsonConvert.SerializeObject(result)}] FINISH");
            return result;

        }

        //// GET: api/Sample
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "A", "B" };
        //}

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
