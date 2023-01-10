using Syncfusion.Windows.Tools;

namespace FotoRenamer.Model.Messages;

public class RequestFolderPathMessage
{
    #region Properties

    /// <summary>
    /// Gets or sets a value indicating whether m_BrowseForComputerOnly. Only return computers. If the user selects anything other than a computer, the OK button is grayed.
    /// </summary>
    public bool BrowseForComputerOnly { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether m_BrowseForEverything. The browse dialog box will display files as well as folders.
    /// </summary>
    public bool BrowseForEverything { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether m_BrowseForPrinterOnly. Only return printers. If the user selects anything other than a computer, the OK button is grayed.
    /// </summary>
    public bool BrowseForPrinterOnly { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether m_BrowseIncludeURL. The browse dialog box can display URLs. The UseNewUI and BrowseForEverything flags must also be set. If these three flags are not set, the browser dialog box will reject URLs. Even when these flags are set, the browse dialog box will only display URLs if the folder that contains the selected item supports them.
    /// </summary>
    public bool BrowseIncludeURL { get; set; }

    /// <summary>
    /// Gets or sets Description m_DescriptionText. text to be show under the tree.
    /// </summary>
    public string? DescriptionText { get; set; }

    /// <summary>
    /// Gets or sets m_DialogTitle. Text that will be shown as a dialog title
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// Gets or sets m_FilterExtensions. Specifies file filter extensions.
    /// </summary>
    /// <remarks>
    /// Works only if UseNewUI and BrowseForEverything are set to true.
    /// </remarks>
    public string[]? FilterExtensions { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether m_IsEditBoxDisabled. Defines whether to show path textbox as disabled or not.
    /// </summary>
    public bool IsEditBoxDisabled { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether m_IsEditBoxReadOnly. Defines whether to show path textbox as read-only or not.
    /// </summary>
    public bool IsEditBoxReadOnly { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether m_NoTranslateTargets. Don't traverse target as shortcut if true.
    /// </summary>
    public bool NoTranslateTargets { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether m_RestrictToDomain. Do not include network folders below the domain level in the dialog box's tree view control.
    /// </summary>
    public bool RestrictToDomain { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether m_RestrictToFilesystem. Only return file system directories. If the user selects folders that are not part of the file system, the OK button is grayed.
    /// </summary>
    public bool RestrictToFilesystem { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether m_RestrictToSubfolders. Only return file system ancestors. An ancestor is a subfolder that is beneath the root folder in the namespace hierarchy. If the user selects an ancestor of the root folder that is not part of the file system, the OK button is grayed.
    /// </summary>
    public bool RestrictToSubfolders { get; set; }

    /// <summary>
    /// Gets or sets m_RootLocation. path to the root of FolderBrowser tree
    /// </summary>
    public LocationID RootLocation { get; set; }

    /// <summary>
    /// Gets or sets m_RootPath Custom path to the folder which will be shown as a start root
    /// </summary>
    public string? RootPath { get; set; }

    /// <summary>
    /// Gets or sets m_SelectedDirectory. Folder chosen by the user.
    /// </summary>
    public string? SelectedDirectory { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether m_ShowEditBox. Include an edit control in the browse dialog box that allows the user to type the name of an item.
    /// </summary>
    public bool ShowEditBox { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether [show full path].
    /// </summary>
    public bool ShowFullPath { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether m_ShowHint. When UseNewDialogStyle is set to true, adds a usage hint to the dialog box in place of the edit box. ShowEditBox sets to true overrides this property.
    /// </summary>
    public bool ShowHint { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether m_ShowNewFolderButton. Defines whether include the New Folder button in the browse dialog or not.
    /// </summary>
    public bool ShowNewFolderButton { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether m_ShowShareable. The browse dialog box can display shareable resources on remote systems. UseNewDialogStyle must also be set to true.
    /// </summary>
    public bool ShowShareable { get; set; }

    /// <summary>
    /// Gets or sets m_StartSelectedDirectory. path to the directory which will be selected when the dialog appears.
    /// </summary>
    public string? StartSelectedDirectory { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether m_ShowStatusText. If set to true, enables status text area in the dialog This is not supported when UseNewDialogStyle is set to true.
    /// </summary>
    public bool ShowStatusText { get; set; }

    /// <summary>
    /// Gets or sets m_StartExpandedDirectory. path to the directory which be expanded when the dialog appears.
    /// </summary>
    public string? StartExpandedDirectory { get; set; }

    /// <summary>
    /// Gets or sets m_StatusText. Status text that can be shown if old dialog style is using and ShowStatusText is set to true.
    /// </summary>
    public string? StatusText { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public object? Tag { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether m_UseNewDialogStyle. Use the new user interface. Setting this flag provides the user with a larger dialog box that can be resized.
    /// </summary>
    public bool UseNewDialogStyle { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether m_UseNewUI. Use the new user interface, including an edit box. This is equivalent to UseNewDialogStyle and ShowEditBox set to true.
    /// </summary>
    public bool UseNewUI { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether m_ValidateSelection. If the user types an invalid name into the edit box, the browse dialog box will raise the ValidateFailed event. It is ignored if ShowEditBox is not set to true.
    /// </summary>
    public bool ValidateSelection { get; set; }

    /// <summary>
    /// the parent- / owner window
    /// </summary>
    public object? Parent { get; set; }

    #endregion
}