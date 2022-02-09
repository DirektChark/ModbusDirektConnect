using ModbusDirekt.Modbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusDirekt
{
    public interface IModbusClient
    {
        void Disconnect();
        InputRegisters ReadInputRegisters(int startingAddress, int count);
    }
}
