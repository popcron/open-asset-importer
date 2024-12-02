using OpenAssetImporter.Native;
using System;
using System.Diagnostics;

namespace OpenAssetImporter;

public unsafe struct Scene : IDisposable
{
    private AiScene* scene;

    public readonly bool IsDisposed => scene is null;
    public readonly string Name => scene->name.ToString();
    public readonly ref SceneFlags Flags => ref scene->flags;
    public readonly Node RootNode => new(scene->rootNode);
    public readonly Metadata Metadata => new(scene->metadata);

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

    /// <summary>
    /// Imports a scene from a byte array.
    /// </summary>
    public Scene(ReadOnlySpan<byte> bytes, ReadOnlySpan<char> hint = default, PostProcessSteps postProcessFlags = default)
    {
        fixed (byte* bytesPointer = bytes)
        {
            scene = Assimp.aiImportFileFromMemory(bytesPointer, (uint)bytes.Length, postProcessFlags, hint.ToString());
        }
    }

    /// <summary>
    /// Imports a scene from data at the file path.
    /// </summary>
    public Scene(ReadOnlySpan<char> filePath, PostProcessSteps postProcessFlags = default)
    {
        scene = Assimp.aiImportFile(filePath.ToString(), postProcessFlags);
        if (scene is null)
        {
            string message = Assimp.aiGetErrorString();
            throw new Exception(message);
        }
    }

    /// <summary>
    /// Releases the imported scene.
    /// </summary>
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
