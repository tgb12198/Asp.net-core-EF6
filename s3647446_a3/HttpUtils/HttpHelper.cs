using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace s3647446_a3.HttpUtils
{
    public class HttpHelper
    {
        /// <summary>
        /// Get请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="Timeout">超时时间默认两分钟</param>
        /// <returns></returns>
        public static string HttpGet(string url, int Timeout = 120000)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";
            request.UserAgent = null;
            request.Timeout = Timeout;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }
        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="pm_str">请求参数</param>
        /// <param name="pm_ContentType">参数类型</param>
        /// <param name="headstr">请求头</param>
        /// <returns></returns>
        public static string HttpPost(string url, string postDataStr)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json;charset=UTF-8";
            request.ContentLength = postDataStr.Length;
            StreamWriter writer = new StreamWriter(request.GetRequestStream(), Encoding.ASCII);
            writer.Write(postDataStr);
            writer.Flush();
            writer.Close();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string encoding = response.ContentEncoding;
            if (encoding == null || encoding.Length < 1)
            {
                encoding = "UTF-8";
            }
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encoding));
            string retString = reader.ReadToEnd();
            reader.Close();
            return retString;
        }
    }
}
