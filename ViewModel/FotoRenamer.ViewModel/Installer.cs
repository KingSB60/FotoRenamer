using Autofac;
using CommunityToolkit.Mvvm.Messaging;
using FotoRenamer.Model.Interfaces;

namespace FotoRenamer.ViewModel;

public class Installer : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        // MainWindowViewModel
        builder.RegisterType<MainWindowViewModel>()
            .As<IMainWindowViewModel>()
            .SingleInstance();
    }
}