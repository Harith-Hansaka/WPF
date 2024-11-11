using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace UNDAI.MODELS.SLAVE
{
    public class SendDataSlave
    {
        string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SlaveSend.txt");

        public SendDataSlave(TcpClient client, string text, bool isLongPressed) 
        {
            if (client != null)
            {
                bool longPress = isLongPressed;
                if (longPress) { HandleLongPress(client, text); }
                else { HandleShortPress(client, text); }
                using (StreamWriter writer = new StreamWriter(_filePath, true, Encoding.UTF8))
                {
                    writer.WriteLine(text); // This writes the response on a new line
                }
            }            
        }

        public async void HandleShortPress(TcpClient client, string text)
        {
            var messageBytes = Encoding.UTF8.GetBytes(text);
            await client.GetStream().WriteAsync(messageBytes, 0, messageBytes.Length);

        }

        public async void HandleLongPress(TcpClient client, string text)
        {
            var messageBytes = Encoding.UTF8.GetBytes(text);
            await client.GetStream().WriteAsync(messageBytes, 0, messageBytes.Length);
        }
    }
}
