using LIN.Types.Inventory.Transient;

namespace LIN.Inventory.Realtime.Manager.Interfaces;

/// <summary>
/// Interfaz observable de productos.
/// </summary>
public interface INotificationModelObserver
{

    /// <summary>
    /// Renderizar.
    /// </summary>
    void Render();


    /// <summary>
    /// Agregar.
    /// </summary>
    void Add(Notificacion modelo);


    /// <summary>
    /// Agregar.
    /// </summary>
    void Remove(int id);

}