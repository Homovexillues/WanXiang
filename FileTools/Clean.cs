using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WanXiang.FileTools
{
    //用于清理文件夹和文件
    internal class Clean
    {
        public bool IsEmpty(string path)
        {
            //判断是文件夹还是文件
            if(Directory.Exists(path))
            //Directory.EnumerateFileSystemEntries会返回一个可枚举的集合，包含了指定路径path下所有文件和子文件见的名称
            //Any是一个LINQ方法，用来检查集合中是否包含任何元素，true,false
                return !Directory.EnumerateFileSystemEntries(path).Any();
            else if(File.Exists(path))
                return new FileInfo(path).Length == 0;
            //如果没有这个地址，默认false以免删错东西
            else return false;
        }
        public void CleanFolder(string path)
        {
            string[] folders = Directory.GetDirectories(path);
            foreach(string folder in folders)
            {
                if(IsEmpty(folder)){Directory.Delete(folder);Console.WriteLine($"已删除空文件夹{folder}"); }

            }
        }
        public void CleanFile(string path)
        {
            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            { 
                if(IsEmpty(file)){File.Delete(file);}
            }
        }
        public void CleanAll(string path)
        {
            CleanFolder(path);
            CleanFile(path);
        }
    }
}
