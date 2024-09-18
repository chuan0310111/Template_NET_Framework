using _3.Template_NET_Framework.Repositories.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Template_NET_Framework.Repositories.Interface
{
    public interface IHsinChuRepository
    {
        /// <summary>
        /// 鄉鎮市公所名稱
        /// </summary>
        /// <returns></returns>
        List<HsinChuAreaDataModel> GetArea();
    }
}
