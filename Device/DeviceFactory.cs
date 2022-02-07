using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusDirekt.Device
{
    public class DeviceFactory
    {
        public static IModbusDevice CreateSerial()
        {
            ModbusDevice dev = null;
            return dev;
        }

        public static IModbusDevice CreateTcpDevice(Action<ITcpChannelConfiguration, IDeviceConfiguration> p)
        {
            var channelConfig = new TcpChannelConfiguration();
            var devConfig = new DeviceConfiguration();
            p(channelConfig, devConfig);


            var channel = new Modbus.Channel.ModbusTCPChannel(channelConfig.Host, channelConfig.SlaveId);
            var client = new ModbusClient(channel);

            ModbusDevice dev = new ModbusDevice(client);

            foreach(var r in devConfig.reg)
            {
                dev.AddRegister(r.Key, r.Value);
            }

            return dev;
        }
    }

    internal struct ModbusRegister
    {
        internal ModbusAddressType addressType;
        internal int address;
        internal int count;

        public ModbusRegister(ModbusAddressType type, int address, int count) : this()
        {
            this.addressType = type;
            this.address = address;
            this.count = count;
        }
    }
}
