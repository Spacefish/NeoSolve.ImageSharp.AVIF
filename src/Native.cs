using System;
using System.IO;
using System.Runtime.InteropServices;

namespace NeoSolve.ImageSharp.AVIF;

public static class Native {
    public static string CAVIFENC => Path.Combine("native", OSFolder, "avifenc") + ExecutableExtension;
    public static string CAVIFDEC => Path.Combine("native", OSFolder, "avifdec") + ExecutableExtension;

    private static string OSFolder {
        get {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                if (RuntimeInformation.ProcessArchitecture == Architecture.X64)
                    return "linux-x64";
                if (RuntimeInformation.ProcessArchitecture == Architecture.Arm64)
                    return "linux-arm64";
                throw new InvalidOperationException("Only x64 and arm64 are supported on Linux.");
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                if (Environment.Is64BitProcess)
                    return "win-x64";

                throw new InvalidOperationException("Only x64 is supported on Windows.");
            }

            throw new InvalidOperationException("Somehow this system seems unsupported.");
        }
    }

    private static string ExecutableExtension {
        get {
            if(RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return string.Empty;

            if(RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return ".exe";

            throw new InvalidOperationException("Somehow this system seems unsupported.");
        }
    }
}
