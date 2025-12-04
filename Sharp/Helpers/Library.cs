using System;
using System.Collections.Concurrent;
using System.IO;
using System.Runtime.InteropServices;

namespace Sharp.Helpers
{
    public static class Library
    {
        private static ConcurrentDictionary<string, nint> Cache { get; }

        static Library()
            => Cache = new ConcurrentDictionary<string, nint>();

        public static nint GetExport(string libraryName, string name)
        {
            nint handle = Cache.GetOrAdd(libraryName, OnLibraryMissing);

            return NativeLibrary.GetExport(handle, name);
        }

        private static nint OnLibraryMissing(string libraryName)
        {
            string currentDirectory = Environment.CurrentDirectory;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                libraryName += Constants.WINDOWS_LIBRARY_EXTENSION;
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                libraryName = Constants.LIBRARY_PREFIX + libraryName + Constants.LINUX_LIBRARY_EXTENSION;
            
            string libraryPath = Path.Combine(currentDirectory, libraryName);
            
            return NativeLibrary.Load(libraryPath);;
        }
    }
}
