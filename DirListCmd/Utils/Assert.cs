namespace DirListCmd;

public static class Assert {

    public static bool True(bool ok, Action? action) {
        if (!ok) {
            if (action is not null) {
                action();               
            };
        }
        return ok;
    }
    public static bool AreEqual(string value1, string value2, Action? action) {
        var ok = value1 == value2;

        if (!ok) {
            if (action is not null) {
                action();               
            }
        } 
        return ok;
    }
    public static void Log(string text) {
        Console.WriteLine(text);
    }
}