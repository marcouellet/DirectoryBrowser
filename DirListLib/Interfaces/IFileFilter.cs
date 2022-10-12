namespace DirListLib;

public interface IFileFilter {
    bool Exclusive { get; }
    bool Filter(IFileSystemEntry fileEntry);
}