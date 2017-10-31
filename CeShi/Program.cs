using RabbitMQ.Client;
using ServiceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeShi
{
    class Program
    {
        static void Main(string[] args)
        {
            var uri = new Uri("amqp://192.168.0.200");
            var factory = new ConnectionFactory

            {

                UserName = "ceshi",

                Password = "ceshi",

                RequestedHeartbeat = 0,

                VirtualHost="myhost",
                Endpoint = new AmqpTcpEndpoint(uri)

            };
            Console.WriteLine($"当前连接服务器：{uri}");
            RabbitMQSendServer SDF = RabbitMQSendServer.GetSingnalInstance();
            for (int i = 1; i <=10; i++)
            {
                SDF.ServiceSendMessage(factory, "sss.a", "ceshi.*", $"{i}你好啊,消息来自200服务器");
            }
            Console.WriteLine("发送完毕");
            Console.ReadKey();
        }
    }
}
