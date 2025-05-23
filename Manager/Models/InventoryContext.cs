﻿using LIN.Types.Inventory.Models;
using LIN.Types.Payments.Models;
using LIN.Types.Responses;

namespace LIN.Inventory.Realtime.Manager.Models;

public class InventoryContext
{

    /// <summary>
    /// Modelo del inventario.
    /// </summary>
    public InventoryDataModel? Inventory { get; set; }

    /// <summary>
    /// Productos.
    /// </summary>
    public ReadAllResponse<ProductModel>? Products { get; set; } = null;

    /// <summary>
    /// Entradas.
    /// </summary>
    public ReadAllResponse<InflowDataModel>? Inflows { get; set; } = null;

    /// <summary>
    /// Salidas.
    /// </summary>
    public ReadAllResponse<OutflowDataModel>? Outflows { get; set; } = null;

    /// <summary>
    /// Pagos.
    /// </summary>
    public ReadAllResponse<PayModel>? Payments { get; set; } = null;

    /// <summary>
    /// Encontrar un producto por Id.
    /// </summary>
    /// <param name="id">Id del producto.</param>
    public ProductModel? FindProduct(int id)
    {
        return Products?.Models.Where(t => t.Id == id).FirstOrDefault();
    }

}