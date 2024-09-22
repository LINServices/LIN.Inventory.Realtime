using LIN.Inventory.Realtime.Manager.Interfaces;

namespace LIN.Inventory.Realtime.Manager.Observers.Abstractions
{
    public interface IOutflowObserver
    {
        void Add(int id, IOutflowModelObserver product);
        void Remove(IOutflowModelObserver product);
        void Update(int id);
    }
}