using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace OpenAssetImporter.Native;

public unsafe static partial class Assimp
{
    public const int MaxNumberOfColorSets = 8;
    public const int MaxNumberOfTextureCoordinates = 8;
    public const int MaxLength = 1024;

    private const string Name = "assimp";

    public static event DllImportResolver? Assimp_DllImporterResolver;

    static Assimp()
    {
        NativeLibrary.SetDllImportResolver(Assembly.GetExecutingAssembly(), OnDLLImport);
    }

    private static nint OnDLLImport(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
    {
        if (libraryName != Name)
        {
            return default;
        }

        nint nativeLibrary = default;
        DllImportResolver? resolver = Assimp_DllImporterResolver;
        if (resolver != null)
        {
            nativeLibrary = resolver(libraryName, assembly, searchPath);
        }

        if (nativeLibrary != default)
        {
            return nativeLibrary;
        }

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            if (NativeLibrary.TryLoad("assimp.dll", assembly, searchPath, out nativeLibrary))
            {
                return nativeLibrary;
            }
        }
        else
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                if (NativeLibrary.TryLoad("libassimp.so", assembly, searchPath, out nativeLibrary))
                {
                    return nativeLibrary;
                }
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                if (NativeLibrary.TryLoad("libassimp.dylib", assembly, searchPath, out nativeLibrary))
                {
                    return nativeLibrary;
                }

                if (NativeLibrary.TryLoad("/usr/local/opt/Assimp/lib/libassimp.dylib", assembly, searchPath, out nativeLibrary))
                {
                    return nativeLibrary;
                }
            }
        }

        if (NativeLibrary.TryLoad("assimp", assembly, searchPath, out nativeLibrary))
        {
            return nativeLibrary;
        }

        if (NativeLibrary.TryLoad("assimp", assembly, searchPath, out nativeLibrary))
        {
            return nativeLibrary;
        }

        return default;
    }

    [LibraryImport(Name, StringMarshalling = StringMarshalling.Utf8)]
    internal static partial AiScene* aiImportFile(string pFile, PostProcessSteps pFlags);

    [LibraryImport(Name, StringMarshalling = StringMarshalling.Utf8)]
    internal static partial AiScene* aiImportFileEx(string file, uint flags, IntPtr fileIO);

    [LibraryImport(Name, StringMarshalling = StringMarshalling.Utf8)]
    internal static partial AiScene* aiImportFileExWithProperties(string file, uint flags, IntPtr fileIO, AiPropertyStore* pProps);

    [LibraryImport(Name, StringMarshalling = StringMarshalling.Utf8)]
    internal static partial AiScene* aiImportFileFromMemory(byte* pBuffer, uint pLength, PostProcessSteps pFlags, string pHint);

    [LibraryImport(Name, StringMarshalling = StringMarshalling.Utf8)]
    internal static partial AiScene* aiImportFileFromMemoryWithProperties(byte* pBuffer, uint pLength, PostProcessSteps pFlags, string pHint, AiPropertyStore* pProps);

    [LibraryImport(Name)]
    internal static partial AiScene* aiApplyPostProcessing(AiScene* pScene, PostProcessSteps pFlags);

    [LibraryImport(Name)]
    internal static partial void aiReleaseImport(AiScene* pScene);

    [LibraryImport(Name, StringMarshalling = StringMarshalling.Utf8)]
    internal static partial string aiGetErrorString();
}
