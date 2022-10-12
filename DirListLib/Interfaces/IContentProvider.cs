namespace DirListLib;

public interface IContentProvider {
    IEnumerable<IFileSystemEntry> GetContent();
}