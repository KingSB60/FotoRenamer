using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using FotoRenamer.Model;
using FotoRenamer.Model.Interfaces;
using FotoRenamer.Model.Messages;
using FotoRenamer.Model.Resources;

namespace FotoRenamer.ViewModel;

public class MainWindowViewModel : ObservableRecipient, IMainWindowViewModel
{
    #region Fields

    private IMessenger _messenger;

    private IFotoRenamerData _data;

    private ICommand? _setRootPathCommand;

    #endregion

    #region Constructor(s)

    public MainWindowViewModel(IFotoRenamerData data, IMessenger messenger)
        : base(messenger)
    {
        _data = data;
        _messenger = messenger;
    }

    #endregion

    #region Properties

    public string? RootPath
    {
        get => _data.RootPath;
        set
        {
            var dataRootPath = _data.RootPath;
            if (SetProperty(ref dataRootPath, value))
                _data.RootPath = dataRootPath;
        }
    }

    public ICommand SetRootPathCommand => _setRootPathCommand ??= new RelayCommand(() =>
    {
        var msg1 = new RequestMainWindowAndDispatcherMessage();
        _messenger.Send(msg1);

        var msg2 = new RequestFolderPathMessage
        {
            Title = Strings.TITLE_SelectRootPathDialog,
            RootPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer),
            SelectedDirectory = _data.RootPath,
            Parent = msg1.MainWindow
        };
        _messenger.Send(msg2);
        RootPath = msg2.SelectedDirectory;
    });

    #endregion
}