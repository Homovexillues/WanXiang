using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace WanXiang.FileTools
{
    public class Label
    {
        public double x { get; set; }
        public double new_x { get; set; }
        public double y { get; set; }
        public double new_y { get; set; }
        public double width { get; set; }
        public double new_width { get; set; }
        public double height { get; set; }
        public double new_height { get; set; }
        public double imageWidth { get; set; }
        public double image_height { get; set; }
        public string? type { get; set; }
        public int frameIndex { get; set; }
        public int instanceCount { get; set; }
        public int framesCount { get; set; }
        public int picture_frameIndex { get; set; }
        public string? imageUrl { get; set; }
        public string? imageName { get; set; }
        public int imageFrameIndex { get; set; }
        public string? id { get; set; }
        public static int counter_license_plate = 0;
        public static int counter_container_number = 0;
        public static int counter_imdg_code = 0;
        public static int counter_LS = 0;
        public static int counter_door_open = 0;
        public static int counter_Broken = 0;
        public static int counter_Cut = 0;
        public static int counter_DentedOrDistorted = 0;
        public static int counter_Hole = 0;
        public static int counter_Uncargoworthy = 0;
        public static int counter_damage = 0;
        public static int counter_keyhole = 0;
        public static int new_type = 0;
        public string yamlfilePath = @"C:\uzone\项目\2024\2024-02 PoC视觉\文档\图像训练第二批（20240407）\HIT0407.yaml";
        //public string json_path = @"C:\Users\rolen\Documents\example\test\";
        //public string targetFilePath = @"C:\Users\rolen\Documents\example\test\";
        //public string counter_path = @"C:\Users\rolen\Documents\example\test\Counter\Counter.txt";

        public static string json_path = @"C:\uzone\项目\2024\2024-02 PoC视觉\文档\图像训练第二批（20240407）\sorts labels\正常标注\";
        public static string targetFilePath = @"C:\uzone\项目\2024\2024-02 PoC视觉\文档\图像训练第二批（20240407）\labels\train\";
        public string counter_path = @"C:\uzone\项目\2024\2024-02 PoC视觉\文档\图像训练第二批（20240407）\正常标注_Counter.txt";
    }

    public class JsonTools:Label
    {

        private JObject? jo1;

        //json数据读取和处理
        public void Data_a(int a)
        {
            //读取图片数据
            x = double.Parse(jo1!["instances"]![a]!["children"]![0]!["cameras"]![0]!["frames"]![0]!["shape"]!["x"]!.ToString());
            y = double.Parse(jo1["instances"]![a]!["children"]![0]!["cameras"]![0]!["frames"]![0]!["shape"]!["y"]!.ToString());
            width = double.Parse(jo1["instances"]![a]!["children"]![0]!["cameras"]![0]!["frames"]![0]!["shape"]!["width"]!.ToString());
            height = double.Parse(jo1["instances"]![a]!["children"]![0]!["cameras"]![0]!["frames"]![0]!["shape"]!["height"]!.ToString());
            type = jo1["instances"]![a]!["category"]!.ToString();
            frameIndex = int.Parse((jo1["instances"]![a]!["children"]![0]!["cameras"]![0]!["frames"]![0]!["frameIndex"]!).ToString());
            imageWidth = double.Parse(jo1["frames"]![0]!["frames"]![frameIndex]!["imageWidth"]!.ToString());
            image_height = double.Parse(jo1["frames"]![0]!["frames"]![frameIndex]!["imageHeight"]!.ToString());
            id = jo1["instances"]![a]!["children"]![0]!["id"]!.ToString();
        }
        public void Data_b(int b)
        {
            picture_frameIndex = int.Parse(jo1!["frames"]![0]!["frames"]![b]!["frameIndex"]!.ToString());
            imageUrl = jo1["frames"]![0]!["frames"]![b]!["imageUrl"]!.ToString();
            imageName = Path.GetFileNameWithoutExtension(imageUrl);
            imageFrameIndex = int.Parse((jo1["frames"]![0]!["frames"]![b]!["frameIndex"]!).ToString());
        }
        //计数器 
        public void Counter()
        {//共标记了多少张图，每种图有多少张

            switch (type)
            {
                case "license_plate": counter_license_plate += 1; break;
                case "container_number": counter_container_number += 1; break;
                case "imdg_code": counter_imdg_code += 1; break;
                case "LS": counter_LS += 1; ; break;
                case "door-open": counter_door_open += 1; ; break;
                case "Broken": counter_Broken += 1; break;
                case "Cut": counter_Cut += 1; break;
                case "DentedOrDistorted": counter_DentedOrDistorted += 1; break;
                case "Hole": counter_Hole += 1; break;
                case "Uncargoworthy": counter_Uncargoworthy += 1; break;
                case "damage": counter_damage += 1; ; break;
                case "keyhole": counter_keyhole += 1; break;
            }

        }
        //生成txt文件
        public void DoTxt()
        {
            var ymds = new Deserializer();
            var yamlObject = ymds.Deserialize<dynamic>(new StreamReader(yamlfilePath));
            var names = yamlObject["names"];
            var cnames = yamlObject["cnames"];
            foreach (string filepath in Directory.GetFiles(json_path, "*.json"))
            {


                string jsonFilePath = File.ReadAllText(filepath);
                jo1 = (JObject)JsonConvert.DeserializeObject(jsonFilePath)!;
                instanceCount = ((JArray)jo1["instances"]!).Count;
                framesCount = ((JArray)jo1["frames"]![0]!["frames"]!).Count;

                for (int b = 0; b < framesCount; b++)
                {
                    List<string> toast_list = new List<string>();
                    Data_b(b);
                    string text_name = imageName + ".txt";
                    //for (int a = 0; a < instanceCount; a++)
                    for (int a = 0; a < instanceCount; a++)
                    {

                        //从json中提取图片数据
                        Data_a(a);

                        //根据名称获取位置
                        if (b == 0)
                        {
                            Counter();
                        }
                        //创建txt文档
                        if (frameIndex == imageFrameIndex && x < imageWidth && y < image_height)
                        {
                            //处理图片数据 
                            new_type = names.IndexOf(type);
                            new_x = Math.Round(((x + width / 2) / imageWidth), 6);
                            new_y = Math.Round(((y + height / 2) / image_height), 6);
                            new_width = Math.Round((width / imageWidth), 6);
                            new_height = Math.Round((height / image_height), 6);
                            string toast_data = $"{new_type} {new_x} {new_y} {new_width} {new_height}";
                            toast_list.Add(toast_data);

                        }

                    }
                    File.WriteAllLines(targetFilePath + text_name, toast_list);

                }


            }
            string license_plate = $"(1){cnames[1]}有\t\t{counter_license_plate}张\n";
            string container_number = $"(2){cnames[2]}有\t\t{counter_container_number}张\n";
            string imdg_code = $"(3){cnames[3]}有\t\t{counter_imdg_code}张\n";
            string LS = $"(4){cnames[4]}有\t\t{counter_LS}张\n";
            string door_open = $"(5){cnames[5]}有\t\t{counter_door_open}张\n";
            string Broken = $"(6){cnames[6]}有\t{counter_Broken}张\n";
            string Cut = $"(7){cnames[7]}有\t{counter_Cut}张\n";
            string DentedOrDistorted = $"(8){cnames[8]}有\t{counter_DentedOrDistorted}张\n";
            string Hole = $"(9){cnames[9]}有\t\t{counter_Hole}张\n";
            string Uncargoworthy = $"(10){cnames[10]}有\t\t{counter_Uncargoworthy}张\n";
            //string damage = $"(11){cnames[11]}有\t\t{counter_damage}张\n";
            //string keyhole = $"(12){cnames[12]}有\t\t\t{counter_keyhole}张\n";
            string counter_data = license_plate + container_number + imdg_code + LS + door_open + Broken + Cut + DentedOrDistorted + Hole + Uncargoworthy;
            File.WriteAllText(counter_path, counter_data);

        }
        public void DoTxt(string jsonPath, string targetPath)
        {
            json_path = jsonPath;
            targetFilePath = targetPath;
            DoTxt();
        }


    }
}
