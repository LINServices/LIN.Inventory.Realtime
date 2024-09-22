using LIN.Inventory.Realtime.Manager.Interfaces;

namespace LIN.Inventory.Realtime.Manager.Observers.Abstractions;

public interface IInventoryObserver
{
    void Add(int inventoryId, IInventoryModelObserver observer);
    void Remove(IInventoryModelObserver product);
    void Update(int id);
}