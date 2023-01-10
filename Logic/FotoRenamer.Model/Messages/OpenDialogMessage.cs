namespace FotoRenamer.Model.Messages;

public class OpenDialogMessage
{
    #region Properties

    public object? ViewModel { get; set; }

    public object? Parent { get; set; }
    public Action<object>? OnDialogClosed;

    #endregion
}