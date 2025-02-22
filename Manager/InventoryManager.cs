using LIN.Types.Inventory.Models;

namespace LIN.Inventory.Realtime.Manager;

public class InventoryManager : IInventoryManager
{

    /// <summary>
    /// Lista de contextos.
    /// </summary>
    private readonly Dictionary<int, Models.InventoryContext> _contextList = [];


    /// <summary>
    /// Insertar un contexto.
    /// </summary>
    /// <param name="model">Modelo de inventario.</param>
    public void Post(InventoryDataModel model)
    {

        // Buscar el contexto.
        _contextList.TryGetValue(model.Id, out Models.InventoryContext? context);

        // Validar.
        if (context is not null)
            return;

        // Agregar el contexto.
        _contextList.Add(model.Id, new Models.InventoryContext
        {
            Inventory = model
        });
    }


    /// <summary>
    /// Tratar de poner el Inventario.
    /// </summary>
    public void PostAndReplace(InventoryDataModel model)
    {
        // Buscar el contexto.
        _contextList.TryGetValue(model.Id, out Models.InventoryContext? res);

        if (res is not null)
        {
            res.Inventory = model;
            return;
        }

        _contextList.Add(model.Id, new()
        {
            Inventory = model
        });

    }


    /// <summary>
    /// Tratar de obtener el contexto de Inventario.
    /// </summary>
    /// <param name="id">Id del inventario.</param>
    public Models.InventoryContext? Get(int id)
    {
        _contextList.TryGetValue(id, out Models.InventoryContext? model);
        return model;
    }


    /// <summary>
    /// Tratar de obtener un producto.
    /// </summary>
    /// <param name="id">Id del producto.</param>
    public ProductModel? GetProduct(int id)
    {
        // Encontrar el producto.
        foreach (var inv in _contextList.Values)
        {
            // Encontrar el producto.
            var model = inv.FindProduct(id);

            // Validar
            if (model is not null)
                return model;
        }
        return null;
    }


    /// <summary>
    /// Encontrar contexto según una entrada.
    /// </summary>
    /// <param name="id">Id de la entrada.</param>
    public Models.InventoryContext? FindContextByInflow(int id)
    {
        // Obtener el Contexto.
        var inventoryContext = (from context in _contextList
                                where (context.Value.Inflows ?? new()).Models.Any(t => t.Id == id)
                                select context.Value).FirstOrDefault();
        return inventoryContext;
    }


    /// <summary>
    /// Encontrar contexto según una salida.
    /// </summary>
    /// <param name="id">Id de la salida.</param>
    public Models.InventoryContext? FindContextByOutflow(int id)
    {
        // Obtener el Contexto.
        var inventoryContext = (from context in _contextList
                                where (context.Value.Outflows ?? new()).Models.Any(t => t.Id == id)
                                select context.Value).FirstOrDefault();
        return inventoryContext;
    }


    /// <summary>
    /// Limpiar data.
    /// </summary>
    public void Clear()
    {
        _contextList.Clear();
    }

}