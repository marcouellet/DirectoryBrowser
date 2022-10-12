namespace DirListLib;
public class FilterFile {
    public IFileFilter[] Filters { get; }
    public FilterFile(IFileFilter[] filters) {
        Filters = filters;
    }
    public bool Filter(IFileSystemEntry fileEntry) {
        return Filters.Where(filter => filter.Exclusive).All(filter => filter.Filter(fileEntry)) &&
                Filters.Where(filter => !filter.Exclusive).Any(filter => filter.Filter(fileEntry));
    }
}