﻿using LIN.Inventory.Realtime.Manager.Interfaces;
using LIN.Inventory.Realtime.Manager.Observers.Abstractions;

namespace LIN.Inventory.Realtime.Manager.Observers;

public class InflowObserver : IInflowObserver
{

    /// <summary>
    /// Valores.
    /// </summary>
    private readonly Dictionary<int, List<IInflowModelObserver>> Values = [];



    /// <summary>
    /// Agregar un observable.
    /// </summary>
    /// <param name="id">Id del inventario.</param>
    /// <param name="product">Observable.</param>
    public void Add(int id, IInflowModelObserver product)
    {

        // Si existe la lista.
        if (!Values.TryGetValue(id, out List<IInflowModelObserver>? products))
        {
            // Nueva lista.
            products = [];

            // Agregar valor.
            Values.Add(id, products);
        }

        // Agregar a la lista el producto.
        products.Add(product);

    }



    /// <summary>
    /// Actualizar los observables de un inventario.
    /// </summary>
    /// <param name="id">Id del inventario.</param>
    public void Update(int id)
    {

        // Recorrer los valores.
        if (Values.TryGetValue(id, out List<IInflowModelObserver>? products))
            foreach (var product in products)
                product.Render();

    }



    /// <summary>
    /// Remover observable.
    /// </summary>
    /// <param name="product">Observable.</param>
    public void Remove(IInflowModelObserver product)
    {
        // Obtener elemento.
        var items = Values.FirstOrDefault(t => t.Value.Contains(product));

        // Eliminar producto.
        items.Value?.Remove(product);

    }


}