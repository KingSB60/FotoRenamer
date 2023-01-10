using System;
using System.Windows;
using CommunityToolkit.Mvvm.Messaging;
using FotoRenamer.Model.Messages;
using FotoRenamer.UI.WPF;
using Syncfusion.Windows.Tools.Controls;

namespace FotoRenamer.UI.Desktop;

public class MessageListener
{
    #region Fields

    private IMessenger _messenger;

    #endregion

    #region Constructor(s)

    protected MessageListener()
    {
        _messenger = StrongReferenceMessenger.Default;
        InitMessenger();
    }

    #endregion

    #region Properties

    public Application App => Application.Current;

    public IMessenger Messenger => _messenger;

    public bool BindableDummy => true;

    #endregion

    #region Methods

    public static MessageListener Listen()
    {
        return new MessageListener();
    }

    protected void InitMessenger()
    {
        _messenger.Register<OpenDialogMessage>(
            this,
            (rec, msg) =>
            {
                if (msg.ViewModel == null)
                    throw new Exception("The ViewModel parameter can not be null");
                Window win = null!;

                try
                {
                    // TODO: depending on type of ViewModel create dialog instance here!
                    if (msg.ViewModel is App)       // check viewModelType
                        win = new Window();         // create related dialog window
                    // TODO: other ViewModel types follow here with <else if>
                }
                finally
                {
                    if (win != null)
                    {

                    }
                }
            });

        _messenger.Register<RequestFolderPathMessage>(
            this,
            (req, msg) =>
            {
                var dlg = new FolderBrowser
                {
                    BrowseForComputerOnly = msg.BrowseForComputerOnly,
                    BrowseForEverything = msg.BrowseForEverything,
                    BrowseForPrinterOnly = msg.BrowseForPrinterOnly,
                    BrowseIncludeURL = msg.BrowseIncludeURL,
                    DescriptionText = msg.DescriptionText,
                    DialogTitle = msg.Title,
                    FilterExtensions = msg.FilterExtensions,
                    IsEditBoxDisabled = msg.IsEditBoxDisabled,
                    IsEditBoxReadOnly = msg.IsEditBoxReadOnly,
                    NoTranslateTargets = msg.NoTranslateTargets,
                    RestrictToDomain = msg.RestrictToDomain,
                    RestrictToFilesystem = msg.RestrictToFilesystem,
                    RestrictToSubfolders = msg.RestrictToSubfolders,
                    RootLocation = msg.RootLocation,
                    RootPath = msg.RootPath,
                    SelectedDirectory = msg.SelectedDirectory,
                    ShowEditBox = msg.ShowEditBox,
                    ShowNewFolderButton = msg.ShowNewFolderButton,
                    ShowFullPath = msg.ShowFullPath,
                    ShowHint = msg.ShowHint,
                    ShowShareable = msg.ShowShareable,
                    ShowStatusText = msg.ShowStatusText,
                    StartExpandedDirectory = msg.StartExpandedDirectory,
                    StartSelectedDirectory = msg.StartSelectedDirectory,
                    StatusText = msg.StatusText,
                    Tag = msg.Tag,
                    UseNewDialogStyle = msg.UseNewDialogStyle,
                    UseNewUI = msg.UseNewUI,
                    ValidateSelection = msg.ValidateSelection
                };

                var result = dlg.ShowDialog(msg.Parent as Window);
                if (result.HasValue && result.Value)
                {
                    msg.SelectedDirectory = dlg.SelectedDirectory;
                }
            });
    }

    #endregion
}