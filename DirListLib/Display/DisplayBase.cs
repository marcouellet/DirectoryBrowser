namespace DirListLib;

public class DisplayBase {
    protected string IndentString { get; }
    protected int IndentValue { get; }
    protected string Indent(string text, int times = 1) {
        return UtilsFns.Indent(text, IndentString, times);
    }
    public DisplayBase(int indent = 4) {
        (IndentValue, IndentString) = (indent, new String(' ', indent > 0 ? indent : 0));
    }
}