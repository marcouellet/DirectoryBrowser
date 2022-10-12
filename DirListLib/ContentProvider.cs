namespace DirListLib;

public abstract class ContentProvider: IContentProvider {
    protected string Path {get; set; }
    protected int Depth { get; set; }
    protected FilterFile? FileFilter { get; }
    protected SortType? SortType { get; }
    protected SortOrder? SortOrder { get; }
    protected IFileSystemEntry? Content {get;  set;}
    protected ContentProvider(string dirPath, int depth = int.MaxValue, IFileFilter[]? filters = null, 
                            SortType? sortType = DirListLib.SortType.Size, SortOrder? sortOrder = DirListLib.SortOrder.Asc) {
        (Path, Depth, SortType, SortOrder) = (dirPath, depth, sortType, sortOrder);
        if (filters is not null) {
            FileFilter =  new FilterFile(filters);
        }
    }
    protected IEnumerable<IFileSystemEntry> SortContent(List<IFileSystemEntry> listContent, SortType?sortType, SortOrder? sortOrder) {

        return sortType switch {
            DirListLib.SortType.Size => SortSize(listContent, sortOrder),
            DirListLib.SortType.Name => SortName(listContent, sortOrder),
            _ => listContent
        };
    }

    private IEnumerable<IFileSystemEntry> SortSize(List<IFileSystemEntry> listContent, SortOrder? sortOrder) {
        return sortOrder switch {
            DirListLib.SortOrder.Asc =>  listContent.OrderBy(entry => entry.Size),
            DirListLib.SortOrder.Desc =>  listContent.OrderByDescending(entry => entry.Size),
            _ => listContent
        };
    }

    private IEnumerable<IFileSystemEntry> SortName(List<IFileSystemEntry> listContent, SortOrder? sortOrder) {
        return sortOrder switch {
            DirListLib.SortOrder.Asc =>  listContent.OrderBy(entry => entry.Name),
            DirListLib.SortOrder.Desc =>  listContent.OrderByDescending(entry => entry.Name),
            _ => listContent
        };
    }

    public abstract IEnumerable<IFileSystemEntry> GetContent();
}