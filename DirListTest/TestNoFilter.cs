using WinDirListLib;
using DirListLib;

public static class TestNoFilter {
    public static void TestAll() {
        var testDisplayXmlResult = TestDisplayXml();
        var testDisplayTextResult = TestDisplayJson();
    }

    public static string TestDisplayXml() {
        var provider = new WinContentProvider(System.IO.Directory.GetCurrentDirectory());
        var directory = new DirListLib.Directory(
                        "DirectoryBrowser", 
                        System.IO.Directory.GetCurrentDirectory(), 
                        provider.GetContent());
        var displayContent = ContentDisplay.Display(directory, ContentDisplayType.Xml);
        return displayContent;
    }

    public static string TestDisplayJson() {
        var provider = new WinContentProvider(System.IO.Directory.GetCurrentDirectory());
        var directory = new DirListLib.Directory(
                        "DirectoryBrowser", 
                        System.IO.Directory.GetCurrentDirectory(), 
                        provider.GetContent());
        var displayContent = ContentDisplay.Display(directory, ContentDisplayType.Json);
        return displayContent;
    }
}