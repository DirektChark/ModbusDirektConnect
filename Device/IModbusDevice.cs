using ModbusDirekt.Modbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusDirekt.Device
{
    public interface IModbusDevice
    {
        IModbusResponse GetRegister(string v);
    }
}
