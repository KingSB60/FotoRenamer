using System.Windows.Input;

namespace FotoRenamer.Model.Interfaces;

public interface IMainWindowViewModel
{
    string? RootPath { get; set; }
    public ICommand SetRootPathCommand { get; }
}