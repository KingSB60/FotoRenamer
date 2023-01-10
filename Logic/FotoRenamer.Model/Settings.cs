using FotoRenamer.Model.Interfaces;
using System.Xml;
using System.Xml.Serialization;

namespace FotoRenamer.Model;

[Serializable]
public class Settings : ISettings
{
    #region Fields

    private static readonly string AppDataDir = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
    private static readonly string SettingsPath = Path.Combine(AppDataDir, "Settings.xml");

    private string? _rootPath;
    private string[] _imageTypeFilter;
    private string? _newNameTemplate;
    private string? _ignoreNameRegexp;

    #endregion

    #region Constructor(s)

    public Settings(IShell<IMainWindow> shell)
    {
        var loaded = Load();
        if(loaded != null)
        {
            _rootPath = loaded.RootPath;
        }

        _imageTypeFilter = new[] {".jpg", ".jpeg"};

        shell.RegisterForApplicationShutdown(this);
    }

    #endregion

    #region Properties

    [XmlElement(nameof(RootPath))]
    public string? RootPath
    {
        get => _rootPath;
        set => _rootPath = value;
    }

    [XmlElement("Filter")]
    public string[] ImageTypeFilter
    {
        get => _imageTypeFilter;
        set => _imageTypeFilter = value;
    }

    [XmlElement(nameof(NewNameTemplate))]
    public string? NewNameTemplate
    {
        get => _newNameTemplate;
        set => _newNameTemplate = value;
    }

    [XmlElement(nameof(IgnoreNameRegexp))]
    public string? IgnoreNameRegexp
    {
        get => _ignoreNameRegexp;
        set => _ignoreNameRegexp = value;
    }

    #endregion

    #region Methods

    private static Settings? Load()
    {
        if (!File.Exists(SettingsPath)) return null;

        using (var reader = XmlReader.Create(SettingsPath))
        {
            return (Settings)new XmlSerializer(typeof(Settings)).Deserialize(reader)!;
        }
    }

    private void Save()
    {
        using (StreamWriter streamWriter = new StreamWriter(SettingsPath))
        {
            new XmlSerializer(typeof(Settings)).Serialize(streamWriter, this);
        }
    }

    #endregion

    #region INotifyAtAppExit Implementation

    public void AtAppExit()
    {
        Save();
    }

    #endregion
}