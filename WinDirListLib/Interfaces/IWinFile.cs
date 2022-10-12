namespace WinDirListLib;

using DirListLib;

public interface IWinFile : IFileSystemEntry {
    string FileNameExtension { get; }
}