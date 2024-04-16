using System;
using System.Text.Json;

namespace WanXiang.FileTools;

public class labelJson
{
    public List<one_instances> instances { get; set; }
    public List<one_frames> frames { get; set; }
}
public class one_frames
{
    public List<two_frames> frames { get; set; }
}
public class two_frames
{
    public int frameIndex { get; set; }
    public string imageUrl { get; set; }
}
public class one_instances
{
    public List<two_children> children { get; set; }
}

public class two_children
{
    public List<three_cameras> cameras { get; set; }
}

public class three_cameras
{
    public List<four_frames> frames { get; set; }
}

public class four_frames
{
    public int frameIndex { get; set; }
    public shape shape { get; set; }
}

public class shape
{
    private double x { get; set; }
    private double y { get; set; }
    private double width { get; set; }
    private double height { get; set; }
}

public class Data
{
    public static void doData(int x)
    {
        string json = File.ReadAllText(@"C:\Users\rolen\Documents\example\toast.json");
        labelJson lJ = JsonSerializer.Deserialize<labelJson>(json);
        int label_frameIndex = lJ.instances[x].children[0].cameras[0].frames[0].frameIndex;
        int pic_frameIndex = lJ.frames[0].frames[x].frameIndex;
    }
}
public class DoJson2:Data
{
    public void Test()
    {
        string json = File.ReadAllText(@"C:\Users\rolen\Documents\example\toast.json");
        labelJson lJ = JsonSerializer.Deserialize<labelJson>(json);
        for (int a = 0; a < lJ.instances.Count;a++)
        {
            
            
            //List<turple>有没有搞头？{ (frameIndex x y width height),() }
        }
    }
}