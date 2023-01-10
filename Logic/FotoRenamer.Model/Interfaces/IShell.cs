namespace FotoRenamer.Model.Interfaces;

public interface IShell<T> where T:class
{
    /// <summary>
    /// Gets or sets the window.
    /// </summary>
    /// <value>
    /// The window.
    /// </value>
    T Window { get; }

    /// <summary>
    /// Configure MainWindow and attach datacontext to it.
    /// </summary>
    void ConfigureSession(IMainWindowViewModel workSpace);

    /// <summary>
    /// Runs this instance.
    /// </summary>
    void Run();

    /// <summary>
    /// Registers an class for 
    /// </summary>
    /// <param name="obj"></param>
    void RegisterForApplicationShutdown<N>(N obj) where N : INotifyAtAppExit;

    /// <summary>
    /// performs application shutdown
    /// </summary>
    void PerformShutdown();
}