﻿using LIN.Inventory.Realtime.Manager.Interfaces;
using LIN.Inventory.Realtime.Manager.Observers.Abstractions;

namespace LIN.Inventory.Realtime.Manager.Observers;

public class ProductObserver : IProductObserver
{

    /// <summary>
    /// Valores.
    /// </summary>
    private readonly Dictionary<int, List<IProductModelObserver>> Values = [];


    /// <summary>
    /// Agregar observable.
    /// </summary>
    /// <param name="inventoryId">Id del inventario.</param>
    /// <param name="observer"></param>
    public void Add(int inventoryId, IProductModelObserver observer)
    {

        // Si existe la lista.
        if (!Values.TryGetValue(inventoryId, out List<IProductModelObserver>? products))
        {
            // Nueva lista.
            products = [];

            // Agregar valor.
            Values.Add(inventoryId, products);
        }

        // Agregar a la lista el producto.
        products.Add(observer);

    }


    /// <summary>
    /// Actualizar los observables de un inventario.
    /// </summary>
    /// <param name="id">Id del inventario.</param>
    public void Update(int id)
    {

        // Recorrer los valores.
        if (Values.TryGetValue(id, out List<IProductModelObserver>? products))
            foreach (var product in products)
                product.Render();

    }


    /// <summary>
    /// Remover observable.
    /// </summary>
    /// <param name="product">Observable.</param>
    public void Remove(IProductModelObserver product)
    {
        // Obtener elemento.
        var items = Values.FirstOrDefault(t => t.Value.Contains(product));

        // Eliminar producto.
        items.Value?.Remove(product);
    }

}