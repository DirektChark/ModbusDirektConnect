using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusDirekt.Device
{
    public class TcpChannelConfiguration : ITcpChannelConfiguration
    {
        public string Host { get; set; }
        public int SlaveId { get; set; }
    }
}
