namespace FotoRenamer.Model.Interfaces;

public interface ISettings : INotifyAtAppExit
{
    string? RootPath { get; set; }

    string[] ImageTypeFilter { get; set; }

    string? NewNameTemplate { get; set; }

    string? IgnoreNameRegexp { get; set;}
}