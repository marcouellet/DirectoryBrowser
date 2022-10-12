namespace DirListLib;

public interface IFileSystemEntry {
        string Name { get; }
        string Path { get; }
        FileSystemEntryType Type { get; }
        long Size { get; }
}