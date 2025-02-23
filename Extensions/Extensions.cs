using LIN.Inventory.Realtime.Manager;
using LIN.Inventory.Realtime.Manager.Observers;
using LIN.Inventory.Realtime.Manager.Observers.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using SILF.Script.Interfaces;

namespace LIN.Inventory.Realtime.Extensions;

public static class ExtensionsRealtime
{

    private static IDevice _device = new Device();

    /// <summary>
    /// Agregar servicios de tiempo real.
    /// </summary>
    public static IServiceCollection AddRealTime(this IServiceCollection services)
    {
        services.AddSingleton<IDevice>(t => _device);
        services.AddSingleton<IDeviceManager, DeviceManager>();
        services.AddSingleton<IInventoryManager, InventoryManager>();

        // Observadores.
        services.AddSingleton<IInflowObserver, InflowObserver>();
        services.AddSingleton<INotificationObserver, NotificationObserver>();
        services.AddSingleton<IOutflowObserver, OutflowObserver>();
        services.AddSingleton<IInventoryObserver, InventoryObserver>();

        return services;
    }


    /// <summary>
    /// Usar tiempo real.
    /// </summary>
    public static IServiceProvider UseRealTime(this IServiceProvider services, string name, string platform, List<IFunction> actions, List<Delegate> delegates)
    {

        // Obtener servicios.
        var deviceService = services.GetService<IDevice>();
        var deviceManager = services.GetService<IDeviceManager>();

        // Validar.
        if (deviceService is not null)
        {
            deviceService.Name = name;
            deviceService.Platform = platform;
        }

        // Validar.
        if (deviceManager is DeviceManager manager)
        {
            manager.Actions = actions;
            manager.Delegates = delegates;
        }

        return services;
    }

}