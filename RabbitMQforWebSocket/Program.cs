using RabbitMQ.Client;
using ServiceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQforWebSocket
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

                VirtualHost = "myhost",
                Endpoint = new AmqpTcpEndpoint(uri)

            };
            RabbitMQSendServer SDF = RabbitMQSendServer.GetSingnalInstance();
       
            Console.WriteLine($"当前连接服务器：{uri}");
        }
    }
}
