using LIN.Inventory.Realtime.Manager.Interfaces;
using LIN.Inventory.Realtime.Manager.Observers.Abstractions;
using LIN.Types.Inventory.Transient;

namespace LIN.Inventory.Realtime.Manager.Observers;


public class NotificationObserver : INotificationObserver
{


    /// <summary>
    /// Valores.
    /// </summary>
    private readonly List<INotificationModelObserver> Values = [];




    public void Add(INotificationModelObserver notification)
    {
        Values.Add(notification);
    }



    /// <summary>
    /// Actualizar los observables de un inventario.
    /// </summary>
    /// <param name="id">Id del inventario.</param>
    public void Update(int id)
    {

        // Recorrer los valores.
        foreach (var notification in Values)
            notification.Render();

    }




    /// <summary>
    /// Agregar modelo.
    /// </summary>
    /// <param name="modelo">Modelo.</param>
    public void Append(Notificacion modelo)
    {
        // Recorrer los valores.
        foreach (var notification in Values)
            notification.Add(modelo);

    }



    /// <summary>
    /// Eliminar modelo.
    /// </summary>
    public void Delete(int id)
    {

        // Recorrer los valores.
        foreach (var notification in Values)
            notification.Remove(id);

    }



    /// <summary>
    /// Remover observable.
    /// </summary>
    /// <param name="notification">Observable.</param>
    public void Remove(INotificationModelObserver notification)
    {
        // Obtener elemento.
        var items = Values.RemoveAll(t => t == notification);

    }


}