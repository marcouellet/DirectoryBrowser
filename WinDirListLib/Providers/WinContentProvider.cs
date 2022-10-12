namespace WinDirListLib;

using DirListLib;

public class  WinContentProvider: ContentProvider {

    public WinContentProvider(string dirPath, SortType? sortType = DirListLib.SortType.Size, SortOrder? sortOrder = DirListLib.SortOrder.Asc,
                                int depth = int.MaxValue, IFileFilter[]? filters = null):
        base (dirPath, depth, filters, sortType, sortOrder) {}

    public override IEnumerable<IFileSystemEntry> GetContent() {
        if (!System.IO.Directory.Exists(Path)) {
            throw new Exception("Path does not exist");
        }

        var content = new List<IFileSystemEntry>();
        var fileInfo = new System.IO.FileInfo(Path);
        var provider = new WinContentProvider(Path, SortType, SortOrder, Depth - 1, FileFilter?.Filters);

        if (fileInfo.Attributes == FileAttributes.Normal || fileInfo.Attributes == FileAttributes.Archive) {
            if (fileInfo.LinkTarget is not null) {
                content.Add(new SymLink(fileInfo.Name, Path, provider.GetContent()));
            } else {
                content.Add(new File(fileInfo.Name, Path, fileInfo.Length));
            }
            return content;
        }

        if (fileInfo.Attributes == FileAttributes.Directory && Depth > 0) {
            var dirContent = new List<IFileSystemEntry>();
            AddFilesToContent(dirContent);
            AddDirectoriesToContent(dirContent);
            content.AddRange(SortContent(dirContent, SortType, SortOrder));
        }

        return content;
    }
    private void AddFilesToContent(List<IFileSystemEntry> content) {
        foreach (var fileName in System.IO.Directory.GetFiles(Path)) {
            var fileInfo = new System.IO.FileInfo(fileName);
           if (fileInfo.Attributes == FileAttributes.Normal || fileInfo.Attributes == FileAttributes.Archive) {
                if (fileInfo.LinkTarget is null) {
                    var file = new File(fileInfo.Name, Path, fileInfo.Length);
                    var selected = (FileFilter is null) ? true : FileFilter.Filter(file);
                    if (selected) {
                        content.Add(file);
                    }
                } 
           }
        }
    }
    private void AddDirectoriesToContent(List<IFileSystemEntry> content) {
        foreach (var directoryPath in System.IO.Directory.GetDirectories(Path)) {
            var fileInfo = new System.IO.FileInfo(directoryPath);
            if (fileInfo.Attributes == FileAttributes.Directory) {
                var provider = new WinContentProvider(directoryPath, SortType, SortOrder, Depth - 1, FileFilter?.Filters);
                content.Add(new Directory(fileInfo.Name, directoryPath, provider.GetContent()));
            }
        }
    }
}