using RabbitMQ.Client;
using ServiceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ceshi2
{
    class Program
    {
        static void Main(string[] args)
        {
            var uri = new Uri("amqp://192.168.0.62");
            var factory = new ConnectionFactory

            {

                UserName = "ceshi",

                Password = "ceshi",

                RequestedHeartbeat = 0,

                Endpoint = new AmqpTcpEndpoint(uri)

            };
            while(true)
            { 
            RabbitMQReceiveServer server = RabbitMQReceiveServer.GetSingnalInstance();
            server.MessageReceive(factory, "topicque1", "topicceshi", "ceshi.*");
            }
            Console.ReadKey();
        }
    }
}
