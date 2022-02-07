namespace ModbusDirekt.Device
{
    public interface ITcpChannelConfiguration
    {
        string Host { get; set; }
        int SlaveId { get; set; }
    }
}