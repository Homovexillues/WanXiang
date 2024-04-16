using System;

namespace WanXiang.FileTools
{
    public interface IType
    {
        public static List<string>? allFolders { get; set; }
        public static List<string>? allFiles { get; set; }
        public static List<string>? FileAndFolder { get; set; }
    }
    public class Name:IType
    {
        public void getAllName(string filePath)
        {
            IType.FileAndFolder = Directory.GetFileSystemEntries(filePath).ToList();
        }
        public void getFileName(string filePath, string type = "*")
        {
            IType.allFiles = Directory.GetFiles(filePath, $"*.{type}").ToList();
        }
        public void getFolderName(string filePath)
        {
            IType.allFolders = Directory.GetDirectories(filePath).ToList();
        }
        public void reNameFolder(string path)
        {
            
        }
        public void reNameFile(string path,string type = "*")
        {

        }
    }
}
