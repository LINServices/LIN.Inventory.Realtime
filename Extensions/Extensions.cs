using LIN.Inventory.Realtime.Manager;
using Microsoft.Extensions.DependencyInjection;
using SILF.Script.Interfaces;

namespace LIN.Inventory.Realtime.Extensions;

public static class ExtensionsRealtime
{

    /// <summary>
    /// Agregar servicios de tiempo real.
    /// </summary>
    public static IServiceCollection AddRealTime(this IServiceCollection services)
    {
        services.AddSingleton<IDevice, Device>();
        services.AddSingleton<IDeviceManager, DeviceManager>();
        return services;
    }


    /// <summary>
    /// Usar tiempo real.
    /// </summary>
    public static IServiceProvider UseRealTime(this IServiceProvider services, string name, string platform, List<IFunction> actions)
    {

        // Obtener servicios.
        var deviceService = services.GetService<IDevice>();
        var deviceManager = services.GetService<IDeviceManager>();

        // Validar.
        if (deviceService is not null)
        {
            deviceService.Name = name;
        }

        // Validar.
        if (deviceManager is DeviceManager manager)
        {
            manager.Actions = actions;
        }

        return services;
    }

}