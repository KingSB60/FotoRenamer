using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms.Design;
using Autofac;
using CommunityToolkit.Mvvm.Messaging;
using FotoRenamer.Model.Interfaces;
using FotoRenamer.UI.WPF;
using Module = Autofac.Module;

namespace FotoRenamer.UI.Desktop;

public class Installer : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        // Shell
        builder.RegisterType<Shell>()
            .As<IShell<IMainWindow>>()
            .SingleInstance();

        // Messanger
        builder.Register(_ => MessageListener.Listen().Messenger)
            .As<IMessenger>()
            .SingleInstance();
    }

    public static void InstallAutofac(ContainerBuilder builder)
    {
        var assembly = Assembly.GetAssembly(typeof(Installer));
        string fullPath = assembly!.Location;
        string dir = Path.GetDirectoryName(fullPath)!;

        builder.RegisterAssemblyModules(assembly);

        var assemblyPath = Path.Combine(dir, "FotoRenamer.ViewModel.dll");
        Debug.Assert(File.Exists(assemblyPath));
        assembly = Assembly.LoadFile(assemblyPath);
        builder.RegisterAssemblyModules(assembly);

        assemblyPath = Path.Combine(dir, "FotoRenamer.Model.dll");
        Debug.Assert(File.Exists(assemblyPath));
        assembly = Assembly.LoadFile(assemblyPath);
        builder.RegisterAssemblyModules(assembly);
    }
}