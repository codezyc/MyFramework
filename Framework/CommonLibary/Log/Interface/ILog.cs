using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibary.Log.Interface
{
    /// <summary>
    /// 日志接口
    /// </summary>
    public interface ILog
    {
        void WriteInfo();

        void WriteError();

        void WriteFatal();

        void WriteDebug();
    }
}
