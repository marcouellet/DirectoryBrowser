namespace DirListLib;

public static class ContentDisplay {
    public static string Display(IFileSystemEntry entry, ContentDisplayType displayType)
    {
        return entry.Type switch {
            _ when entry.Type == FileSystemEntryType.Directory => new DirectoryDisplay().Display((IDirectory)entry, 0, displayType),
            _ when entry.Type == FileSystemEntryType.File => new FileDisplay().Display(entry, 0, displayType),
            _ when entry.Type == FileSystemEntryType.Symlink => new SymLinkDisplay().Display((ISymLink)entry, 0, displayType),
            _ => throw new Exception("Unknown display type")
        };
    }
}