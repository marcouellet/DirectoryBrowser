namespace DirListLib;

using System.Text;
public static class UtilsFns {
        public static string Indent(string text, string indent, int times = 1) {
                var builder = new StringBuilder();
                while (times > 0) {
                        builder.Append(indent);
                        times--;
                }
                builder.Append(text);
                return builder.ToString();
        }
}
