using LIN.Inventory.Realtime.Manager.Interfaces;

namespace LIN.Inventory.Realtime.Manager.Observers.Abstractions
{
    public interface IInflowObserver
    {
        void Add(int id, IInflowModelObserver product);
        void Remove(IInflowModelObserver product);
        void Update(int id);
    }
}