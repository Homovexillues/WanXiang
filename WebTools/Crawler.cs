using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WanXiang.WebTools
{
   
    class HttpCrawelHelper
    {
        #region    爬取图片
        public static void HttpGetHandle(string url, string path, int name)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.CreateHttp(url);
            webRequest.Method = "GET";
            webRequest.UserAgent = " Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:75.0) Gecko/20100101 Firefox/75.0";
            var webResponse = webRequest.GetResponse();
            StreamReader streamReader = new StreamReader(webResponse.GetResponseStream(), Encoding.UTF8);
            string str = streamReader.ReadToEnd();
            streamReader.Close();
            if (string.IsNullOrEmpty(str))
            {
                Console.WriteLine("————————-错误—————————");
                Console.ReadKey();
            }
            Regex regex = new Regex(@"<img\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<Group>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>");
            MatchCollection match = regex.Matches(str);
            WebClient client = new WebClient();
            int temp = 0;
            try
            {
                foreach (Match match1 in match)
                {
                    string src = match1.Groups[1].Value;
                    if (src.Contains("http") && !src.Contains(".svg"))
                    {
                        temp++;
                        client.DownloadFile(src, path + name + ".jpg");
                        name++;
                        Console.WriteLine("\n正在爬取———————" + "|" + temp);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("-------------" + ex);
            }
            stopwatch.Stop();
            Console.WriteLine("————-———爬取成功！—————");
            Console.WriteLine("\n_______总共爬取了" + temp + "张图片!_______________");
            Console.WriteLine("\n一共耗时" + stopwatch.ElapsedMilliseconds / 1000 + "秒");
        }
        #endregion
        #region 创建一个文件夹
        public static void CreatFile()
        {
            string crawlerPath = @"F:\Picture";
            if (Directory.Exists(crawlerPath))
            {
                Console.WriteLine("\n————————开始——————————");
            }
            else
            {
                DirectoryInfo directory = new DirectoryInfo(crawlerPath);
                directory.Create();
            }
        }
        #endregion 
    }
}

