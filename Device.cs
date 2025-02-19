namespace LIN.Inventory.Realtime;

public class Device : IDevice
{

    /// <summary>
    /// Nombre del dispositivo.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Identificador único del dispositivo en signalR.
    /// </summary>
    public string Key { get; private set; } = string.Empty;

    /// <summary>
    /// Plataforma.
    /// </summary>
    public string Platform { get; set; } = string.Empty;

    /// <summary>
    /// Refrescar el id único.
    /// </summary>
    public void RefreshGuid(string? guid = null)
    {
        Key = guid is not null ? guid : Guid.NewGuid().ToString();
    }
}