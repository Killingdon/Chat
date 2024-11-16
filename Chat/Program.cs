using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

const int port = 5000;
var listener = new TcpListener(IPAddress.Any, port);
listener.Start();

while (true)
{
    using var client = listener.AcceptTcpClient();
    Console.WriteLine("Клиент Подключён!");
    using var stream = client.GetStream();

    while (client.Connected)
    {
        try
        {
            //Чтение сообщения!
            var buffer = new byte[1024];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            if (bytesRead == 0) break;

            string gotenAnswere = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            Console.WriteLine($"Полученное сообщение {gotenAnswere}");

            //Отправить ответ
            if (gotenAnswere == "Привет." || gotenAnswere == "Hello.")
            {
                string sendMessage = "Hi";
                byte[] responseData = Encoding.UTF8.GetBytes(sendMessage);
                stream.Write(responseData, 0, responseData.Length);
                Console.WriteLine($"Отправлено: {sendMessage}");
            }
            else if (gotenAnswere == "Как дела?" || gotenAnswere == "How are you?")
            {
                string sendMessage = "Im Good! What About You?";
                byte[] responseData = Encoding.UTF8.GetBytes(sendMessage);
                stream.Write(responseData, 0, responseData.Length);
                Console.WriteLine($"Отправлено: {sendMessage}");
            }
            else if (gotenAnswere == "Хорошо." || gotenAnswere == "Im good.")
            {
                string sendMessage = "It Sounds Good! What are You Doing?";
                byte[] responseData = Encoding.UTF8.GetBytes(sendMessage);
                stream.Write(responseData, 0, responseData.Length);
                Console.WriteLine($"Отправлено: {sendMessage}");
            }
            else if (gotenAnswere == "Нечего, а ты," || gotenAnswere == "Nothing, you?")
            {
                string sendMessage = "Im chating with the greatest person, You!";
                byte[] responseData = Encoding.UTF8.GetBytes(sendMessage);
                stream.Write(responseData, 0, responseData.Length);
                Console.WriteLine($"Отправлено: {sendMessage}");
            }
            else
            {
                string sendMessage = "Im tyred!";
                byte[] responseData = Encoding.UTF8.GetBytes(sendMessage);
                stream.Write(responseData, 0, responseData.Length);
                Console.WriteLine($"Отправлено: {sendMessage}");
                break;
            }
        }
        catch (Exception e) {
            Console.WriteLine($"Ошибка: {e.Message}");
        }
        Console.WriteLine("Клиент Отключился!");
    }
}