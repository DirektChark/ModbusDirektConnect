using ModbusDirekt.Modbus.Channel;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ModbusDirekt.Modbus
{
    /// <summary>
    /// 16 bit Read-Write
    /// </summary>
    public class InputRegisters : IModbusResponse
    {
        public byte[] Data { get; }

        public InputRegisters()
        {
        }

        public InputRegisters(ModbusResponse response)
        {
            this.Data = response.Data;
        }
    }
}