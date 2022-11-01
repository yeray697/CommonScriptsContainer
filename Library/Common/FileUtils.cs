namespace Common
{
    public static class FileUtils
    {
        private const string COMMON_SCRIPTS_FOLDER_NAME = "CommonScripts";

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
                path = GetConfigDirectory() + path;
            }
            return path;
        }
        public static string GetConfigDirectory()
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string path = Path.Combine(folder, COMMON_SCRIPTS_FOLDER_NAME);
#if DEBUG
            path = Path.Combine(path, "Debug");
#endif
            return path;
        }
    }
}