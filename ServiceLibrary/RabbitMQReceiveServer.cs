using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLibrary
{
    /// <summary>
    /// 对接接收消息服务类
    /// </summary>
   public class RabbitMQReceiveServer
    {
        static readonly object lockset = new object();
        volatile static RabbitMQReceiveServer Instance;
        private RabbitMQReceiveServer()
        {

        }
        public static RabbitMQReceiveServer GetSingnalInstance()
        {
            if (Instance == null)
            {
                lock (lockset)
                {
                    if (Instance == null)
                    {
                        Instance = new RabbitMQReceiveServer();
                    }
                }
            }
            return Instance;
        }
        /// <summary>
        /// 声明RabbitMQ连接配置文件
        /// </summary>
        private ConnectionFactory myConnectionFactory;
        /// <summary>
        /// 声明队列配置文件的线程安全集合
        /// </summary>
        private ConcurrentDictionary<Guid, string> myQueueConfig = new ConcurrentDictionary<Guid, string>();
        public void MessageReceive(ConnectionFactory Connection, string qName, string exchangeName, string routingKey)
        {
            myConnectionFactory = Connection;
            using (var connection = myConnectionFactory.CreateConnection())

            {

                using (var channel = connection.CreateModel())

                {

                    //channel.ExchangeDeclare(exchangeName, exchangeType, true, false, null);

                    //channel.QueueDeclare(qName, true, false, false, null);

                    channel.QueueBind(qName, exchangeName, routingKey);

                    //定义这个队列的消费者

                    var consumer = new EventingBasicConsumer(channel);
                    //---------------------------

                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);
                        Console.WriteLine(" [x] Received {0}", message);
                    };
                    channel.BasicConsume(queue: qName,
                                         autoAck: true,
                                         consumer: consumer);//设置应答       
                                                             //Console.WriteLine(" Press [enter] to exit.");
                    Console.ReadLine();


                    //---------------------------

                    //QueueingBasicConsumer consumer = new QueueingBasicConsumer(channel);

                    //false为手动应答，true为自动应答

                    // var sdf=   channel.BasicConsume(qName, true, consumer);

                    //while (true)

                    //{

                    //    BasicGetResult msgResponse = channel.BasicGet(qName, noAck: true);

                    //    string msgBody = Encoding.UTF8.GetString(msgResponse.Body);

                    //    //BasicDeliverEventArgs ea = (BasicDeliverEventArgs)consumer.Queue.Dequeue();

                    //    //byte[] bytes = ea.Body;

                    //    //var messageStr = Encoding.UTF8.GetString(bytes);

                    //    Console.WriteLine("Receive a Message, DateTime:" + msgBody+"源自"+url);
                    //}

                }

            }
        }
    }
}
