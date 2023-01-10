using System.Reflection.Metadata;
using FotoRenamer.Model.Interfaces;
using MetadataExtractor;
using MetadataExtractor.Util;
using Directory = MetadataExtractor.Directory;

namespace FotoRenamer.Model;

public class FileInfoData : IFolderTreeEntry, IRenamable
{
    #region Fields

    private string _path;
    private FileType _imageFileType;
    private IReadOnlyList<Directory>? _imageMetaData;

    #endregion

    #region Constructor(s)

    public FileInfoData(string path)
    {
        _path = path;
        Initialize();
    }

    #endregion

    #region Properties

    public string Path => _path;

    public FileType ImageFileType
    {
        get => _imageFileType;
        private set => _imageFileType = value;
    }

    #endregion

    #region Methods

    private void Initialize()
    {
        if (!File.Exists(_path)) return;

        using Stream stream = File.OpenRead(_path);

        _imageFileType = FileTypeDetector.DetectFileType(stream);
        _imageMetaData = ImageMetadataReader.ReadMetadata(stream);
    }

    public string Rename(string renamingTemplate)
    {
        return String.Empty;
    }

    #endregion
}