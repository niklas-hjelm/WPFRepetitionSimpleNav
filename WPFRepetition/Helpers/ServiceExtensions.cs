using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using WPFRepetition.Factories;

namespace WPFRepetition.Helpers;

public static class ServiceExtensions
{
    public static void AddViewModelFactory<TVM>(this IServiceCollection services) where TVM : ObservableObject
    {
        services.AddTransient<TVM>();
        services.AddTransient<Func<TVM>>(sp => () => sp.GetService<TVM>()!);
        services.AddSingleton<IViewModelFactory<TVM>, ViewModelFactory<TVM>>();
    }
}