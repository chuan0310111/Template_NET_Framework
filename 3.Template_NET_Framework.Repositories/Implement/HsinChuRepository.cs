using _0.Template_NET_Framework.Common.Interface;
using _3.Template_NET_Framework.Repositories.DataModels;
using _3.Template_NET_Framework.Repositories.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _3.Template_NET_Framework.Repositories.Implement
{
    public class HsinChuRepository : IHsinChuRepository
    {
        private readonly ILogger _logger;
        private readonly HttpClient _hsinChuHttpClient;

        public HsinChuRepository(ILogger logger, HttpClient hsinChuHttpClient)
        {
            this._logger = logger;
            this._hsinChuHttpClient = hsinChuHttpClient;
        }

        /// <summary>
        /// 鄉鎮市公所名稱
        /// </summary>
        /// <returns></returns>
        public List<HsinChuAreaDataModel> GetArea() {

            var cMethed = MethodBase.GetCurrentMethod();
            var logTitle = $"{cMethed.DeclaringType.Name}.{cMethed.Name}";
            var apiUrl = "001/Upload/1/opendata/8774/2110/2a6edd5b-dd82-464d-82e9-2518e27e98eb.json";

            try
            {
                this._logger.Info($"{logTitle} [apiUrl:{this._hsinChuHttpClient.BaseAddress}{apiUrl}]");
                var apiResp = this._hsinChuHttpClient.GetAsync(apiUrl).Result;

                // todo 這甚麼意思
                apiResp.EnsureSuccessStatusCode();

                var apiResult = apiResp.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
                var result = JsonConvert.DeserializeObject<List<HsinChuAreaDataModel>>(apiResult);

                this._logger.Info($"{logTitle} [Response: {JsonConvert.SerializeObject(result)}]");

                return result;
            }
            catch (Exception ex)
            {
                this._logger.Error($"{logTitle} [error: {ex.Message}]\n{ex.StackTrace}");
                ex.Data.Add("IsLogged", "Y");
                throw;
            }
        }
    }
}
