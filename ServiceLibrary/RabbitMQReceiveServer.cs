using System;
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
    }
}
