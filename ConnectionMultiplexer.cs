using ModbusDirekt.Modbus.Channel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModbusDirekt
{
    /// <summary>
    /// ConnectionMultiplexer is used to communicate with multiple slaves on a bus through a single gateway. The multiplexer is required to synchronize communication
    /// to different slaves through a single socket.
    /// </summary>
    public class ConnectionMultiplexer
    {
        Dictionary<int, ModbusChannel> channels;

        

        public ConnectionMultiplexer(string hostname, int port = 502)
        {
            channels = new Dictionary<int, ModbusChannel>();
        }

        public ModbusChannel GetModbusSlave(int slaveID)
        {
            if (channels.TryGetValue(slaveID, out ModbusChannel channel))
                return channel;

            channel = new MultiplexedTCPChannel();
            channels.Add(slaveID,channel);
            return channel;
        }
    }
}
