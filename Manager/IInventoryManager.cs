using LIN.Inventory.Realtime.Manager.Models;
using LIN.Types.Inventory.Models;

namespace LIN.Inventory.Realtime.Manager;

public interface IInventoryManager
{
    void Clear();
    InventoryContext? Get(int id);
    ProductModel? GetProduct(int id);
    void Post(InventoryDataModel model);
    void PostAndReplace(InventoryDataModel model);
    InventoryContext? FindContextByInflow(int id);
    InventoryContext? FindContextByOutflow(int id);
}