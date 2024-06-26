namespace WanXiang.FileTools;

internal static class LogThingy
{
    public static void Log(this Exception ex,string logText,string logFilePath = @$"") {
        string logDirectoryPath = Path.GetDirectoryName(logFilePath);
        if(!Directory.Exists(logDirectoryPath)) { Directory.CreateDirectory(logDirectoryPath); }
        if(!File.Exists(logFilePath)) {
            using(var writer = new StreamWriter(logFilePath)) {
                writer.WriteLine(logText);
            }
        }
        else {
            using(var writer = File.AppendText(logFilePath)) {
                writer.WriteLine(logText);
            }
        }
    }
}