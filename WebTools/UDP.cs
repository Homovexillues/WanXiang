using System.Net.Sockets;
using System.Net;
using System.Text;

namespace WanXiang.WebTools
{
    public static class UDP
    {
        /// <summary>
        /// 向指定ip和端口发送UDP数据
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <param name="port"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        private static async Task SendUdpMessage(string ipAddress,int port,string message) {
            using(var udpClient = new UdpClient()) {
                var endpoint = new IPEndPoint(IPAddress.Parse(ipAddress),port);
                byte[] sendBytes = Encoding.UTF8.GetBytes(message);

                try {
                    await udpClient.SendAsync(sendBytes,sendBytes.Length,endpoint);
                    Console.WriteLine($"Message sent to {ipAddress}:{port}");
                }
                catch(Exception e) {
                    Console.WriteLine($"Error sending message: {e.Message}");
                }
            }
        }
    }
}