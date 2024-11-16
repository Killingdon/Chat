using System;
using System.Net.Sockets;
using System.Text;

const string serverIp = "127.0.0.1";
const int port = 5000;

try
{
    using var client = new TcpClient(serverIp, port);
    using var stream = client.GetStream();

    Console.WriteLine("Подключено к серверу, Введите сообщение!");
    while (true)
    {
        string message = Console.ReadLine();
        if (string.IsNullOrEmpty(message)) break;

        //Отправка данных 
        byte[] data = Encoding.UTF8.GetBytes(message);
        stream.Write(data, 0, data.Length);

        //Чтение ответа
        var buffer = new byte[1024];
        int bytesRead = stream.Read(buffer, 0, buffer.Length);
        string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);

        Console.WriteLine($"Ответ: {response}");
    }
}
catch(Exception ex)
{
    Console.WriteLine($"Ошибка: {ex.Message}");
}