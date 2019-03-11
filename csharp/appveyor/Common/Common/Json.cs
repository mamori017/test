using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace Common
{
    public static class Json
    {
        public static JObject GetJsonObject(String strUrl)
        {
            try
            {
                string strJson = "";
                try
                {
                    strJson = new HttpClient().GetStringAsync(strUrl).Result;
                }
                catch (Exception)
                {
                    throw;
                }

                JObject objJson = JObject.Parse(strJson);

                return objJson;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}