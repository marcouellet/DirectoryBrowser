namespace DirListLib;

public class FileFilterBuilder {
    public List<IFileFilter> FileFilters {get; }
    public FileFilterBuilder() {
        FileFilters = new List<IFileFilter>();
    }
    public void AddFileFilter(IFileFilter filter) {
        FileFilters.Add(filter);
    }
}