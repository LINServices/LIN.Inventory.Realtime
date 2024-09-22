namespace LIN.Inventory.Realtime.Manager;

public interface IDeviceManager
{
    void StartSession(string token);
    void CloseSession();
    Task SendCommand(string command, int? inventory = null);
    Task JoinInventory(int inventory); 
    void SendToDevice(string command, string device);
}