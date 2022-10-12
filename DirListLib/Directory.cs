namespace DirListLib;

public class Directory : IDirectory {
    public string Name { get; }
    public string Path { get; }
    public FileSystemEntryType Type { get; }
    public long Size { get; }
    public IEnumerable<IFileSystemEntry> Content { get; }
    public Directory(string name, string path, IEnumerable<IFileSystemEntry> content) {
        Name = name ?? throw new Exception("Directory name cannot be null");
        Path = path ?? throw new Exception("Directory path cannot be null");
        Type = FileSystemEntryType.Directory;
        Content = content;
        Size = Content.Sum(entry => entry.Size);
    }
}