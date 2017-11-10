using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TBaseMode : IServerBase
    {
        /// <summary>
        /// Serialize data
        /// </summary>
        /// <returns></returns>
        public byte[] Serialize()
        {
            using (MemoryStream IO = new MemoryStream())
            {
                Serializer.Serialize(IO, this);
                IO.Position = 0;
                return IO.ToArray();
            }
        }
        public static TModel DeSerialize<TModel>(byte[] ByteArray) where TModel : TBaseMode, new()
        {
            try
            {
                using (MemoryStream IO = new MemoryStream())
                {
                    IO.Write(ByteArray, 0, ByteArray.Length);
                    IO.Position = 0;
                    return Serializer.Deserialize<TModel>(IO);
                }
            }
            catch
            {
                return new TModel();
            }
        }
    }
}
