using Autofac;
using FotoRenamer.Model.Interfaces;

namespace FotoRenamer.Model;

public class Installer : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        // Foto-Renamer Data
        builder.RegisterType<FotoRenamerData>()
            .As<IFotoRenamerData>()
            .SingleInstance();

        // Setings
        builder.RegisterType<Settings>()
            .As<ISettings>().
            SingleInstance();
    }
}