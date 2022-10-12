namespace DirListLib;

public class SymLink : ISymLink {
    public string Name { get; }
    public string Path { get; }
    public FileSystemEntryType Type { get; }
    public long Size {get; init; }
    public IEnumerable<IFileSystemEntry> Target { get; }
    public SymLink(string name, string path, IEnumerable<IFileSystemEntry> target) {
        (Name, Path, Type, Size, Target) = (name, path, FileSystemEntryType.File, 0, target);
    }
}