namespace LIN.Inventory.Realtime;

public interface IDevice
{
    string Key { get; }
    string Name { get; set; }
    string Platform { get; set; }
    void RefreshGuid(string? guid = null);
}