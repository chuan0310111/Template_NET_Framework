using _2.Template_NET_Framework.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Template_NET_Framework.Services.Interface
{
    public interface ISampleService
    {
        /// <summary>
        /// 鄉鎮市公所名稱
        /// </summary>
        /// <returns></returns>
        HsinChuAreaResultDto GetArea();
    }
}
