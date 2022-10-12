namespace DirListLib;
public interface ISymLink: IFileSystemEntry {
    IEnumerable<IFileSystemEntry> Target { get; }
}