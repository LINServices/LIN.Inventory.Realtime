using LIN.Access.Inventory.Hubs;
using SILF.Script.Interfaces;

namespace LIN.Inventory.Realtime.Manager;

public class DeviceManager(IDevice device) : IDeviceManager
{

    /// <summary>
    /// Access Hub.
    /// </summary>
    private InventoryAccessHub? Hub { get; set; } = null;


    /// <summary>
    /// Funciones
    /// </summary>
    public List<IFunction> Actions { get; set; } = [];


    /// <summary>
    /// Iniciar la sesión de Realtime
    /// </summary>
    /// <param name="token">Token de acceso.</param>
    public void StartSession(string token)
    {
        // Actualizar el id único.
        device.RefreshGuid();

        // Crear el hub de acceso a inventario.
        Hub = new(token, new()
        {
            Name = device.Name,
            LocalId = device.Key,
            Platform = device.Platform
        });

        // Evento.
        Hub.On += OnReceiveCommand;
    }


    /// <summary>
    /// Cerrar sesión de Realtime.
    /// </summary>
    public void CloseSession()
    {
        // Actualizar el id único.
        device.RefreshGuid(string.Empty);
        Hub!.Dispose();
        Hub = null;
    }


    /// <summary>
    /// Evento al recibir un comando.
    /// </summary>
    private void OnReceiveCommand(object? sender, Types.Inventory.Transient.CommandModel e)
    {

        // Generar la app.
        var app = new SILF.Script.App(e.Command);

        // Agregar funciones del framework de Inventory.
        app.AddDefaultFunctions(Actions);

        // Ejecutar app.
        app.Run();

    }


    /// <summary>
    /// Enviar comando.
    /// </summary>
    /// <param name="command">Comando a enviar.</param>
    /// <param name="inventory">Inventario de grupo.</param>
    public async Task SendCommand(string command, int? inventory = null)
    {
        if (Hub is null)
            return;

        await Hub!.SendCommand(new()
        {
            Command = command,
            Inventory = inventory ?? 0
        });
    }


    /// <summary>
    /// Unir a inventario.
    /// </summary>
    /// <param name="inventory">Id del inventario.</param>
    public async Task JoinInventory(int inventory)
    {
        if (Hub is null || inventory <= 0)
            return;
        await Hub!.JoinInventory(inventory);
    }


    /// <summary>
    /// Enviar comando.
    /// </summary>
    public void SendToDevice(string command, string device)
    {
        if (Hub is null)
            return;

        Hub!.SendToDevice(device, new()
        {
            Command = command
        });
    }

}