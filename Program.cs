///Copyright(c) 2022,uZone All rights reserved.
///摘要：.json提取label数据脚本
///作者：Homovexillues
///日期：2024年4月3日
///说明：
///修订：
///
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using YamlDotNet.Serialization;
using WanXiang.WebTools;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace WanXiang.FileTools
{
    
               
    public class OperateJson:IType
    {
        static void Main()
        {
            DateTimeOffset now;
           
            var dateTime1 = DateTimeOffset.Now.DateTime;
            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();
            //JsonTools jt = new JsonTools();
            //jt.doTxt();
            //string sourceFilePath = @"C:\Users\15190\Downloads\乐吾乐2D可视化";
            string UnSortedPictureFilePath = @"C:\Users\rolen\Documents\Damage_picture（第二批）\train";
            string SortedPictureFilePath = @"C:\Users\rolen\Documents\Damage_picture（第二批）\val";
            Move mv = new();
            mv.sortFile(UnSortedPictureFilePath,SortedPictureFilePath,0.1);
            //string[] subDirectories = Directory.GetDirectories(sourceFilePath);
            //List<string> allFiles = new List<string>();
            //foreach (var files in subDirectories )
            //{
            //    string[] fileInSubdir = Directory.GetFiles(files);
            //    foreach (var file in fileInSubdir )
            //        if (File.Exists(Path.Combine(sourceFilePath,Path.GetFileName(file)))) { break; }
            //        else
            //        {

            //            File.Move(file, Path.Combine(sourceFilePath,Path.GetFileName(file)));

            //        }

            //}
            //DoJson2 dj2 = new();
            //dj2.Test();
            //string url = "https://www.4khd.com/content/12/artgravia-vol566-the-best-of-artgravia-vol.html";
            //HttpCrawelHelper.CreatFile();
            //string path = Path.Combine(@"F:\Picture");
            //HttpCrawelHelper.HttpGetHandle(url, path, 1);
            //Clean cl = new Clean();
            //cl.CleanFolder(@"C:\Users\15190\Downloads\乐吾乐2D可视化 - 副本");
            //Move mv = new Move();

            //mv.sortFile(@"C:\Users\15190\Downloads\乐吾乐2D可视化 - 副本", @"C:\Users\15190\Downloads\乐吾乐2D可视化 - 副本\新建文件夹", 0.1);
            //Timer timer = new Timer();
            //stopwatch.Stop();
            //Console.WriteLine((decimal)stopwatch.ElapsedMilliseconds/1000+"s");
            
            var dateTime2 = DateTimeOffset.Now.DateTime;
            Console.WriteLine(dateTime1);
            Console.WriteLine(dateTime2);
            Console.WriteLine(dateTime2-dateTime1);
        }
    }
}