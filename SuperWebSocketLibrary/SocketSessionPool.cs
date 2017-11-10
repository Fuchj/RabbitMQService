using Model;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperWebSocketLibrary
{
    /// <summary>
    /// WebSocket连接池
    /// </summary>
    public class SocketSessionPool
    {
        #region 创建WebSocketPool单列对象
        private static readonly object _lock = new object();
        private volatile static SocketSessionPool Instance;
        public static SocketSessionPool GetInstance<T>(T t) where T: IServerBase, new()
        {
            if (Instance == null)
            {
                lock (_lock)
                {
                    if (Instance == null)
                    {
                        Instance = new SocketSessionPool(t);
                    }
                }
            }
            return Instance;
        }
        #endregion
        ConcurrentDictionary<Guid, IServerBase> SocketSessionDictionary = null;
        SocketSessionPool(IServerBase Tmodel) 
        {

            SocketSessionDictionary = new ConcurrentDictionary<Guid, IServerBase>();

        }
        /// <summary>
        /// 增加一个键值对
        /// </summary>
        /// <param name="Guid"></param>
        /// <param name="RequestInfo"></param>
        /// <returns></returns>
        public bool TryAdd(Guid Key,IServerBase Value)
        {
            return SocketSessionDictionary.TryAdd(Key, Value);
        }
        /// <summary>
        /// 删除一个键值对
        /// </summary>
        /// <param name="Guid"></param>
        /// <param name="RequestInfo"></param>
        /// <returns></returns>
        public bool TryRemove(Guid Key, out IServerBase Value)
        {
            return SocketSessionDictionary.TryRemove(Key, out Value);
        }

        /// <summary>
        /// 更新一个键值对,先使用Comparison比较字典中当前值，如果一样则更新
        /// </summary>
        /// <param name="Guid"></param>
        /// <param name="RequestInfo"></param>
        /// <returns></returns>
        public bool TryUpdate(Guid Key, IServerBase NewValue, IServerBase ComparisonValue)
        {
            return SocketSessionDictionary.TryUpdate(Key, NewValue, ComparisonValue);
        }
        /// <summary>
        /// 获取一个值
        /// </summary>
        /// <param name="Guid"></param>
        /// <param name="RequestInfo"></param>
        /// <returns></returns>
        public bool TryGetValue(Guid Key, out IServerBase Value)
        {
            return SocketSessionDictionary.TryGetValue(Key, out Value);
        }

        /// <summary>
        /// 获取实例 
        /// </summary>
        /// <param name="Guid"></param>
        /// <param name="RequestInfo"></param>
        /// <returns></returns>
        public KeyValuePair<Guid, IServerBase>[] GetAllValue()
        {
            return SocketSessionDictionary.ToArray();//此方法性能不好
        }
    }
}
