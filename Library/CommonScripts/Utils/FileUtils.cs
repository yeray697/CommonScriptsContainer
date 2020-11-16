using CommonScripts.Settings;
using System;
using System.IO;
using System.Linq;

namespace CommonScripts.Utils
{
    public static class FileUtils
    {
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
                path = GetProjectPath() + path;
            }
            return path;
        }

        public static string GetProjectPath()
        {
            return AppSettingsManager.GetProjectInstallationPath();
        }
    }
}
