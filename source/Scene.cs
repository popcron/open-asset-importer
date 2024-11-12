using OpenAssetImporter.Native;
using System;
using System.Diagnostics;

namespace OpenAssetImporter;

public unsafe struct Scene : IDisposable
{
    private AiScene* scene;

    public readonly bool IsDisposed => scene is null;
    public readonly string Name => scene->name.ToString();

    public readonly ReadOnlySpan<Mesh> Meshes
    {
        get
        {
            ThrowIfDisposed();
            return new ReadOnlySpan<Mesh>(scene->meshes, (int)scene->numMeshes);
        }
    }

    [Obsolete("Default constructor not supported", true)]
    public Scene()
    {
        throw new NotSupportedException();
    }

    public Scene(ReadOnlySpan<byte> bytes, ReadOnlySpan<char> hint)
    {
        fixed (byte* bytesPointer = bytes)
        {
            scene = Assimp.aiImportFileFromMemory(bytesPointer, (uint)bytes.Length, default, hint.ToString());
        }
    }

    public Scene(ReadOnlySpan<char> filePath)
    {
        scene = Assimp.aiImportFile(filePath.ToString(), default);
        if (scene is null)
        {
            string message = Assimp.aiGetErrorString();
            throw new Exception(message);
        }
    }

    public void Dispose()
    {
        Assimp.aiReleaseImport(scene);
        scene = default;
    }

    public readonly override string ToString()
    {
        return Name.ToString();
    }

    [Conditional("DEBUG")]
    public readonly void ThrowIfDisposed()
    {
        if (IsDisposed)
        {
            throw new ObjectDisposedException(nameof(Scene));
        }
    }
}
