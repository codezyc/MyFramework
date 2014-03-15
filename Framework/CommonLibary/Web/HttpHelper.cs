using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CommonLibary.Web
{
    /// <summary>
    /// Http常用方法操作
    /// </summary>
    public class HttpHelper
    {
        /// <summary>
        /// 键值对的QueryString集合转换成Url后面的参数字符串
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task<string> SetUrlQueryString(Dictionary<string, string> data)
        {
            if (data != null)
            {
                var querystring = new FormUrlEncodedContent(data);
                return await querystring.ReadAsStringAsync();
            }
            return null;
        }
    }
}
