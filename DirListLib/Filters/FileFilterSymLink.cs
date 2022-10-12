namespace DirListLib;

public class FileFilterSymLink : IFileFilter {
    public bool Exclusive { get; }
    public FileFilterSymLink() {
        Exclusive = true;
    }
    public bool Filter(IFileSystemEntry file) {
        return file.Type == FileSystemEntryType.Symlink;
    }
}