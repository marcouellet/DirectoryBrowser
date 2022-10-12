namespace DirListLib;
public class FileSizeFilter : IFileFilter {

    private long MinSize { get; } 
    private long MaxSize { get; } 
    public bool Exclusive { get; }
    public FileSizeFilter (long minSize, long maxSize) {
        if (minSize > maxSize) throw new Exception("minSize greater than maxSize");
        (MinSize, MaxSize) = (minSize, maxSize);
        Exclusive = true;
    }
    public bool Filter(IFileSystemEntry fileEntry) {
        if (fileEntry.Type == FileSystemEntryType.File) {
            return fileEntry.Size >= MinSize && fileEntry.Size <= MaxSize;
        }
        return true;
    }
}