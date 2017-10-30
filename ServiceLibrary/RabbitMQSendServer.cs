using RabbitMQ.Client;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLibrary
{
    /// <summary>
    /// 队列发送服务
    /// </summary>
  public  class RabbitMQSendServer
    {
        static readonly object lockset = new object();
        volatile  static RabbitMQSendServer Instance;
        private RabbitMQSendServer()
        {
           
        }
        public static RabbitMQSendServer GetSingnalInstance()
        {
            if (Instance == null)
            {
                lock (lockset)
                {
                    if (Instance == null)
                    {
                        Instance = new RabbitMQSendServer();
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
        public void ServiceSendMessage(ConnectionFactory Connection, string exchangeName,string routingKey,string value)
        {

            myConnectionFactory = Connection;
            using (var connection = myConnectionFactory.CreateConnection())
            {
                using (var channel = connection.CreateModel())

                {
                    //if(exchangeName!=null)
                    //{
                    ////设置交换器的类型,且为可持久化
                    //channel.ExchangeDeclare(exchangeName, exchangeType, false, false, null);
                    //}

                    ////声明一个队列，设置队列是否持久化，排他性，与自动删除
                    //if (qName != null&& )
                    //{
                    //    channel.QueueDeclare(qName, false, false, false, null);
                    //}          

                    ////绑定消息队列，交换器，routingkey

                    //channel.QueueBind(qName, exchangeName, routingKey);

                    //将队列设置为持久化之后，还需要将消息也设为可持久化的

                    var properties = channel.CreateBasicProperties();

                    //队列持久化

                    properties.Persistent = true;

                    var body = Encoding.UTF8.GetBytes(value);

                    //发送信息

                    channel.BasicPublish(exchangeName, routingKey, properties, body);

                    //Console.WriteLine("Producter Sent: {0}" + url, value);
                }

            }

        }

    }
}
