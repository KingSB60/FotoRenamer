using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using FotoRenamer.Model.Interfaces;
using FotoRenamer.UI.WPF;
using FotoRenamer.ViewModel;

namespace FotoRenamer.UI.Desktop;

public class Shell : IShell<IMainWindow>
{
    #region Fields

    private Queue<INotifyAtAppExit> _registeredForAppExit;

    #endregion

    #region Constructor(s)

    /// <summary>
    /// Creates a new instance of the <see cref="Shell"/> class
    /// </summary>
    public Shell()
    {
        Window = new MainWindow();
        _registeredForAppExit = new Queue<INotifyAtAppExit>();
    }

    #endregion

    #region Properties

    /// <inheritdoc/>>
    public IMainWindow Window { get; }

    #endregion

    #region Methods

    /// <inheritdoc/>>
    public void ConfigureSession(IMainWindowViewModel workSpace)
    {
        ((MainWindow)Window).DataContext = workSpace;
    }

    /// <inheritdoc/>>
    public void RegisterForApplicationShutdown<T>([NotNull]T obj) where T : INotifyAtAppExit
    {
        _registeredForAppExit.Enqueue(obj);
    }

    /// <inheritdoc/>>
    public void Run()
    {
        ((MainWindow)Window).Show();
    }

    /// <inheritdoc/>>
    public void PerformShutdown()
    {
        while (_registeredForAppExit.Count > 0)
        {
            var entry = _registeredForAppExit.Dequeue();
            entry.AtAppExit();

            ((IDisposable) entry).Dispose();
        }
    }

    #endregion
}