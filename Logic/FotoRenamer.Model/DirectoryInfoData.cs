using FotoRenamer.Model.Interfaces;

namespace FotoRenamer.Model;

public class DirectoryInfoData : IFolderTreeEntry
{
    #region Fields

    private string _path;
    private List<IFolderTreeEntry> _entries;

    #endregion

    #region Constructor(s)

    public DirectoryInfoData(string path)
    {
        _path = path;
        _entries=new List<IFolderTreeEntry>();
        Initialize();
    }

    #endregion

    #region Properties

    public string Path => _path;
    public List<IFolderTreeEntry> Entries => _entries;

    #endregion

    #region Methods

    private void Initialize()
    {
        foreach (var directory in Directory.EnumerateDirectories(_path))
            _entries.Add(new DirectoryInfoData(directory));
        foreach (var file in Directory.EnumerateFiles(_path))
            _entries.Add(new FileInfoData(file));
    }

    #endregion
}