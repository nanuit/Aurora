using System;
using System.Reflection;

namespace Aurora.Misc.Application
{
    public static class ApplicationInfo
    {
        ///TODO: Move to Aurora
        /// <summary>
        /// Retrieves the linker timestamp.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        /// <remarks>http://www.codinghorror.com/blog/2005/04/determining-build-date-the-hard-way.html</remarks>
        private static System.DateTime RetrieveLinkerTimestamp(string filePath)
        {
            const int peHeaderOffset = 60;
            const int linkerTimestampOffset = 8;
            var b = new byte[2048];
            System.IO.FileStream s = null;
            using (s = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                    s.Read(b, 0, 2048);
            
            var dt = new System.DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(System.BitConverter.ToInt32(b, System.BitConverter.ToInt32(b, peHeaderOffset) + linkerTimestampOffset));
            return dt.AddHours(System.TimeZone.CurrentTimeZone.GetUtcOffset(dt).Hours);
        }
        /// <summary>
        /// get the linked timestamp for the assembly
        /// </summary>
        /// <param name="assembly">assembly to get the date for</param>
        /// <returns></returns>
        public static DateTime CompiledDate(this Assembly assembly)
        {
            //string path = Path.GetDirectoryName(new Uri(assembly.GetName().CodeBase).LocalPath);
            string path = new Uri(assembly.GetName().CodeBase).LocalPath;
            return (RetrieveLinkerTimestamp(path));
        }
        /// <summary>
        /// Retreive the version 
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static Version GetVersion(this Assembly assembly)
        {
            return (assembly.GetName().Version);
        }
    }
}
