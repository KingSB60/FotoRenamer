using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.ComponentModel;
using FotoRenamer.Model.Interfaces;

namespace FotoRenamer.Model;

public partial class FotoRenamerData : ObservableObject, IFotoRenamerData
{
    #region Fields

    private ISettings _settings;

    #endregion

    #region Constructor(s)

    public FotoRenamerData(ISettings settings)
    {
        _settings = settings;
        RootPath = _settings.RootPath;
#if DEBUG
        RootPath = @"f:\Media\Bilder\Fotos\";
#else
        RootPath = _settings.RootPath;
#endif
    }

    #endregion

    #region Observable Properties

    [ObservableProperty] private string? _rootPath;

    [ObservableProperty] private DirectoryInfoData? _rootData;

    #endregion

    #region Partial Methods

    /// <summary>Executes the logic for when <see cref="P:FotoRenamer.Model.FotoRenamerData.RootPath" /> just changed.</summary>
    partial void OnRootPathChanged(string? value)
    {
        _settings.RootPath = value;
        if (Directory.Exists(value))
            RootData = new DirectoryInfoData(value);
    }

    #endregion

    #region Properties


    #endregion

    #region Methods


    #endregion


}