namespace Common
{
    public static class FileUtils
    {
        public static bool IsAbsolutePath(string path)
        {
            return !string.IsNullOrWhiteSpace(path)
                && path.IndexOfAny(Path.GetInvalidPathChars().ToArray()) == -1
                && Path.IsPathRooted(path)
                && !(Path.GetPathRoot(path) ?? string.Empty).Equals(Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal);
        }
        public static string GetAbsolutePath(string path)
        {
            if (!IsAbsolutePath(path))
            {
                if (path.StartsWith(".\\"))
                    path = path.Remove(0, 2);
                if (!path.StartsWith("\\"))
                    path = "\\" + path;
                path = GetProjectPath() + path;
            }
            return path;
        }
        public static string GetConfigDirectory()
        {
#if DEBUG
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            return Path.Combine(folder, "CommonScriptsDebug");
#else
            return GetProjectPath();
#endif
        }
        public static string GetProjectPath()
            => AppDomain.CurrentDomain.BaseDirectory;
    }
}