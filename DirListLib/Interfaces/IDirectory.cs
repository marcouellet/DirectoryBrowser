namespace DirListLib;

public interface IDirectory: IFileSystemEntry {
    public IEnumerable<IFileSystemEntry> Content { get; }
}