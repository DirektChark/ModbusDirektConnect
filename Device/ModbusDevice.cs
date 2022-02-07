using ModbusDirekt.Modbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusDirekt.Device
{

    public enum ModbusAddressType
    {
        DiscreteOutputCoil,
        DiscreteInputContact,
        InputRegister,
        HoldingRegister

    }
    public class ModbusDevice : IModbusDevice
    {
        private ModbusClient client;
        private Dictionary<string, ModbusRegister> Registers = new Dictionary<string, ModbusRegister>();

        public ModbusDevice(ModbusClient client)
        {
            this.client = client;
        }

        public IModbusResponse GetRegister(string key)
        {
            var reg = this.Registers[key];
            Func<int, int, IModbusResponse> callback;
            switch (reg.addressType)
            {
                case ModbusAddressType.DiscreteInputContact: 
                    callback = client.ReadDiscreteInputs; 
                    break;
                case ModbusAddressType.DiscreteOutputCoil: 
                    callback = client.ReadCoils; 
                    break;
                case ModbusAddressType.InputRegister:
                    callback = client.ReadInputRegisters;break;
                case ModbusAddressType.HoldingRegister:
                    callback = client.ReadHoldingRegisters;
                    break;
                default: throw new InvalidOperationException("Unknown Address type.");
            }

            return callback(reg.address, reg.count);
        }



        internal void AddRegister(string key, ModbusRegister value)
        {
            this.Registers.Add(key, value);
        }
    }


}
