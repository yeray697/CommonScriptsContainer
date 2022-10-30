namespace Common
{
    public static class FileUtils
    {
        private const string COMMON_SCRIPTS_FOLDER_NAME = "CommonScripts";

        public static bool IsAbsolutePath(string path)
        {
            return !String.IsNullOrWhiteSpace(path)
                && path.IndexOfAny(System.IO.Path.GetInvalidPathChars().ToArray()) == -1
                && Path.IsPathRooted(path)
                && !Path.GetPathRoot(path).Equals(Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal);
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
#if DEBUG
            return Path.Combine(folder, COMMON_SCRIPTS_FOLDER_NAME, "Debug");
#endif
            return Path.Combine(folder, COMMON_SCRIPTS_FOLDER_NAME);
        }
    }
}