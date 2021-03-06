using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace Common
{
    public static class HttpHelper
    {
        //1.  3次握手 string 3个参数 第1个参数 4个标志位； 第2个参数 方法名；  第3个参数 实体对象；
        public static string GetApiResult(string retype, string actionname, object obj = null)
        {
            //2.实例化客户端
            HttpClient hc = new HttpClient();
            //3.配置API地址  （重要：这个地址需要改成自己的）
            hc.BaseAddress = new Uri("http://localhost:5000/");
            //4.创建收包任务
            Task<HttpResponseMessage> task = null;
            //5.第1次握手,发送请求
            switch (retype.ToLower())
            {
                case "get":
                    task = hc.GetAsync(actionname);
                    break;
                case "post":
                    StringContent postContent = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
                    task = hc.PostAsync(actionname, postContent);
                    //task = hc.PostAsJsonAsync(actionname, obj);
                    break;
                case "put":
					StringContent putContent = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
                    task = hc.PutAsync(actionname, putContent);
                    //task = hc.PutAsJsonAsync(actionname, obj);
                    break;
                case "delete":
                    task = hc.DeleteAsync(actionname);
                    break;
            }
            //6.第2次握手
            if (task != null)
            {
				task.Wait();
				
                //7.第3次握手
                if (task.Result.IsSuccessStatusCode)
                {
                    //8.获取请求的数据,转换为字符串
                    var strdata = task.Result.Content.ReadAsStringAsync();
                    //9.获取转换的结果
                    return strdata.Result;
                }
            }
            return "";
        }

    }
}