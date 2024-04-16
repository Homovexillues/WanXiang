using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanXiang.FileTools
{
    

    public class Move : IType
    {
        private static Random rng = new();
        //获取指定位置的所有文件名字添加到列表中


        //随机抽指定比例的文件移动到另一文件夹
        public void sortFile(string sourcePath, string targetPath, double Rate)
        {
            Name nm=new Name();
            nm.getFileName(sourcePath);
            int length = (int)(IType.allFiles.Count * (Rate));
            var selectedFiles = IType.allFiles.OrderBy(x => rng.Next()).Take(length);
            foreach (var file in selectedFiles)
            {
                var sourceFile = Path.Combine(sourcePath, Path.GetFileName(file));
                var targetFile = Path.Combine(targetPath, Path.GetFileName(file));
                File.Move(sourceFile, targetFile);
            }
        }

    }

}
