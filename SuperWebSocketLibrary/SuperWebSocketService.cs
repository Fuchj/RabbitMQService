using SuperSocket.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SuperWebSocketLibrary
{
    class SuperWebSocketService
    {
        #region 创建SuperWebSocketService单列对象
        private static readonly object _lock = new object();
        private volatile static SuperWebSocketService Instance;
        public static SuperWebSocketService GetInstance()
        {
            if (Instance == null)
            {
                lock (_lock)
                {
                    if (Instance == null)
                    {
                        Instance = new SuperWebSocketService();
                    }
                }
            }
            return Instance;
        }

        #endregion
        private WebSocketServer serverClient = null;//服务器对象
        private Timer Timer_SendData = null;//定时器

        private SuperWebSocketService()
        {
            //初始化服务器对象
            serverClient = new WebSocketServer();
            serverClient.NewSessionConnected += ServerClient_NewSessionConnected;//处理连接
            serverClient.NewDataReceived += ServerClient_NewDataReceived; //处理连接
            serverClient.NewMessageReceived += ServerClient_NewMessageReceived;//处理请求
            serverClient.SessionClosed += ServerClient_SessionClosed;//处理关闭
            Timer_SendData = new Timer(5000);
            Timer_SendData.AutoReset = true;
            Timer_SendData.Elapsed += Timer_SendData_Elapsed;
        }

        private void ServerClient_SessionClosed(WebSocketSession session, SuperSocket.SocketBase.CloseReason value)
        {
            throw new NotImplementedException();
        }

        private void ServerClient_NewMessageReceived(WebSocketSession session, string value)
        {
            throw new NotImplementedException();
        }

        private void ServerClient_NewDataReceived(WebSocketSession session, byte[] value)
        {
            throw new NotImplementedException();
        }

        private void ServerClient_NewSessionConnected(WebSocketSession session)
        {
            throw new NotImplementedException();
        }

        private void Timer_SendData_Elapsed(object sender, ElapsedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
