using System.Collections.Generic;

namespace ModbusDirekt.Device
{
    internal class DeviceConfiguration : IDeviceConfiguration
    {



        internal Dictionary<string, ModbusRegister> reg = new Dictionary<string, ModbusRegister>();
        public DeviceConfiguration()
        {
        }

        public void Add(string key, ModbusAddressType type, int address, int count)
        {
            reg.Add(key, new ModbusRegister(type, address, count));
        }


        
    }
}