## ModbusDC

ModbusDC is a communication library for the modbus protocol.

This project was largely inspired by the EasyModbusTCP.NET library. https://github.com/rossmann-engineering/EasyModbusTCP.NET but was rebuilt from scratch to add flexibility
and solve some limitations in the implementation.


## About Modbus

Modbus is a communication protocol for serial devices. It was built to enable communication over long distances over a two wire bus cable using the RS-485 standard.
A traditional Modbus "system" consists of a 'Master' device and up to 32 slave devices along a single BUS cable. The master consisted of a PC with a RS-485
PCIE card, or a RS-485 modem connected to the PC`s Serial port.

When multiple serial devices are connected to a single bus line, the communication needs to be synchronized to prevent two devices transmitting at  the same time.
In modbus this is handled by only allowing the master to initiate communication. The master sends out a Read or Write command containting a Unit Identification number,
and the slave device whith the corresponding id then responds to the message.

Modbus later added a protocol standard to enable communication over TCP/IP which added great flexibility to the modbus topology. Using a Modbus TCP/IP Gateway, 
Masters and slaves no longer have to reside on the same physical network and a single master can communicate with an unlimited number of slaves.

## How to use

Create a communication channel for the device. The channel needs to match the transport layer and encoding of the device.
You can read more about possible channels and configurations under `Modes of Communication`

Transport types:
* Modbus RTU
* Modbus ASCII
* Modbus TCP/IP
* Modbus RTU over TCP

This project is primarily focused on RTU over TCP/IP, since this is the most common when integrating with a modbus device built for RS-485 and using a TCP/IP serial gateway.


```


            var device = ModbusDirekt.Device.DeviceFactory.CreateTcpDevice((channelConfig, deviceConfig) =>
            {
                channelConfig.Host = "192.168.1.10";
                channelConfig.SlaveId = 1;                

                deviceConfig.Add("Temperature", ModbusAddressType.InputRegister, 0x6f, 2);
                deviceConfig.Add("Humidity", ModbusAddressType.InputRegister, 0x6d, 2);
                deviceConfig.Add("ProgramName", ModbusAddressType.InputRegister, 0x260, 17);
            });

            var temp = device.GetRegister("Temperature").AsFloat();
            var hum = device.GetRegister("Humidity").AsFloat();
            var prog = device.GetRegister("ProgramName").AsString();

            Console.WriteLine($"Temperature: {temp}°C");
            Console.WriteLine($"Humidity: {hum}%rH");
            Console.WriteLine($"Program name: {prog}");
```

## Features


## Modes of communication

Modbus consists of two layers of communication, the encoding layer and the transport layer. 

Modbus communication can either use ASCII or RTU to encode commands and responses. The transport layer defines what physical material is used to communicate. The two most common types are Ethernet and Serial (RS-422/485/232).


Modbus Serial - This mode is used when directly connected to a serial device such as 

Modbus TCP/IP - This mode is specifically designed for ethernet communication, either connecting directly to the slave with ethernet or using a ethernet to serial bridge (Gateway). When using a gateway, the gateway will handle CRC checksum and RTU framing.

Modbus TCP/IP Encapsulation - This mode is used when using a non-Modbus compatible RS-485 bridge. The RTU/ASCII frames are encoded as when using a serial connection, including CRC checksum.

### Connection multiplexing
The ConnectionMultiplexer is used to communicate with multiple slaves on a serial bus through a single gateway. The multiplexer is required to synchronize communication to different slaves through a single socket.


