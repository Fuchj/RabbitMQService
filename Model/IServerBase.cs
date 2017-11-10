using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 服务类接口
    /// </summary>
   public interface IServerBase
    {
        byte[] Serialize();
    }
}
