namespace DirListLib;

public class File : IFileSystemEntry {
    public string Name { get; }
    public string Path { get; }
    public FileSystemEntryType Type { get; }
    public long Size {get; init; }

    public File(string name, string path, long size) {
        (Name, Path, Type, Size) = (name, path, FileSystemEntryType.File, size);
    }
}