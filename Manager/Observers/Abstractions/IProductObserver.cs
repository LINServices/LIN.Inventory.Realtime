using LIN.Inventory.Realtime.Manager.Interfaces;

namespace LIN.Inventory.Realtime.Manager.Observers.Abstractions
{
    public interface IProductObserver
    {
        void Add(int inventoryId, IProductModelObserver observer);
        void Remove(IProductModelObserver product);
        void Update(int id);
    }
}