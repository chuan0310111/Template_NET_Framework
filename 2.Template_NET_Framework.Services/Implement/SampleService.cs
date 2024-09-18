using _0.Template_NET_Framework.Common.Interface;
using _2.Template_NET_Framework.Services.Dtos;
using _2.Template_NET_Framework.Services.Interface;
using _3.Template_NET_Framework.Repositories.Interface;
using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _2.Template_NET_Framework.Services.Implement
{
    public class SampleService : ISampleService
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IHsinChuRepository _hsinChuRepository;
        private readonly IAppSettings _appSettings;

        public SampleService(ILogger logger, IMapper mapper, IHsinChuRepository hsinChuRepository, IAppSettings appSettings)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._hsinChuRepository = hsinChuRepository;
            this._appSettings = appSettings;
        }

        /// <summary>
        /// 鄉鎮市公所名稱
        /// </summary>
        /// <returns></returns>
        public HsinChuAreaResultDto GetArea()
        {
            var cMethed = MethodBase.GetCurrentMethod();
            var logTitle = $"{cMethed.DeclaringType.Name}.{cMethed.Name}";
            var result = new HsinChuAreaResultDto() {
                Areas = new List<HsinChuAreaDto>()
            };

            try
            {
                this._logger.Info($"{logTitle} START");

                var areaResult = this._mapper.Map<List<HsinChuAreaDto>>(_hsinChuRepository.GetArea());
                result.Areas = areaResult;
                result.ResultCode = "000000";

            }
            catch (Exception ex)
            {
                var isLogged = (ex.Data["IsLogged"] as string == "Y");
                if (isLogged == false)
                {
                    this._logger.Error($"{logTitle} [error: {ex.Message}]\n{ex.StackTrace}");
                    ex.Data.Add("IsLogged", "Y");
                }

                result = new HsinChuAreaResultDto()
                {
                    ResultCode = "999901",
                    ResultMsg = ex.Message
                };
            }


            this._logger.Info($"{logTitle} [Response: {JsonConvert.SerializeObject(result)}] FINISH");
            return result;

        }

    }
}
