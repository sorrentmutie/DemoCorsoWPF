using Microsoft.Extensions.DependencyInjection;
using System;
using System.Security.Cryptography.X509Certificates;

namespace DemoCorso.StartupHelpers;

public static class ServicesCollectionExtensions
{

    public static void AddWindowFactory<TForm>(this IServiceCollection services)
        where TForm: class
    {
        services.AddTransient<TForm>();
        services.AddSingleton<Func<TForm>>(x =>  () => x.GetService<TForm>()!);
        services.AddSingleton<IAbstractFactory<TForm>, AbstractFactory<TForm>>();
    }

}
