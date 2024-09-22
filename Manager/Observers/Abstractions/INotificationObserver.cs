using LIN.Inventory.Realtime.Manager.Interfaces;
using LIN.Types.Inventory.Transient;

namespace LIN.Inventory.Realtime.Manager.Observers.Abstractions
{
    public interface INotificationObserver
    {
        void Add(INotificationModelObserver notification);
        void Append(Notificacion modelo);
        void Delete(int id);
        void Remove(INotificationModelObserver notification);
        void Update(int id);
    }
}