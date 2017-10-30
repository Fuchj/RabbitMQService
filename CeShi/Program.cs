﻿using RabbitMQ.Client;
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
            var uri = new Uri("amqp://192.168.0.62");
            var factory = new ConnectionFactory

            {

                UserName = "ceshi",

                Password = "ceshi",

                RequestedHeartbeat = 0,

                Endpoint = new AmqpTcpEndpoint(uri)

            };
            RabbitMQSendServer SDF = RabbitMQSendServer.GetSingnalInstance();
            for (int i = 0; i <5; i++)
            {
                SDF.ServiceSendMessage(factory, "topicceshi", "ceshi.*", "你好啊");
            }
           
        }
    }
}
