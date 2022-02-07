using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ModbusDirekt.Modbus.Channel
{
    internal class MultiplexedTCPChannel : ModbusTCPChannel
    {
        public MultiplexedTCPChannel(): base((IPAddress)null ,0,0)
        {

        }
        public MultiplexedTCPChannel(IPAddress iPAddress, int unitId, int port = 502) : base(iPAddress, unitId, port)
        {
        }

        public MultiplexedTCPChannel(string host, int unitId, int port = 502) : base(host, unitId, port)
        {
        }
    }
}
